using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExePatch
{
  public partial class PatchForm : Form
  {
    public PatchForm()
    {
      InitializeComponent();
    }

    public PatchForm(uint baseAddress, uint memAddress, uint fileOffset, string filePath, int processId, bool suspend, byte[] binary)
      : this(baseAddress, filePath, processId, suspend)
    {
      this.memAddress = memAddress;
      this.fileOffset = fileOffset;
      this.binaryData = binary;
      txtOffset.Text  = (radProcess.Checked ? memAddress : fileOffset).ToString("X");
    }

    public PatchForm(uint baseAddress, string filePath, int processId, bool suspend, string asm)
      : this(baseAddress, filePath, processId, suspend)
    {
      txtOffset.Enabled = false;
      txtOffset.Text    = "Auto";
      this.asm          = asm;
    }

    PatchForm(uint baseAddress, string filePath, int processId, bool suspend) : this()
    {
      this.baseAddress   = baseAddress;
      txtFile.Text       = filePath;
      ProcessId          = processId;
      chkSuspend.Checked = suspend;

      if(ProcessId != 0)
      {
        radProcess.Checked = true;
        lblProcess.Text = "Process #" + ProcessId.ToString();
      }
    }

    public uint Address
    {
      get { return uint.Parse(txtOffset.Text, NumberStyles.HexNumber); }
    }

    public string FilePath
    {
      get { return txtFile.Text.Trim(); }
    }

    public bool PatchFile
    {
      get { return radFile.Checked; }
    }

    public int ProcessId
    {
      get; private set;
    }

    public bool ShouldSuspendProcess
    {
      get { return chkSuspend.Checked; }
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      btnPatch.Focus();
      CenterToParent();
    }

    void EnableOrDisableControls()
    {
      btnPatch.Enabled = radProcess.Checked && ProcessId != 0 || txtFile.TextLength != 0;
    }

    bool MultiPatch()
    {
      string error;
      int failedChunk;
      Program.Chunk[] chunks = Program.AssembleChunks(asm, baseAddress, out failedChunk, out error);
      if(chunks == null)
      {
        MessageBox.Show("Failed to assemble chunk " + failedChunk.ToString() + ": " + error, "Assembly failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      else
      {
        if(radFile.Checked)
        {
          using(FileStream file = new FileStream(txtFile.Text, FileMode.Open, FileAccess.ReadWrite))
          {
            foreach(Program.Chunk chunk in chunks)
            {
              file.Position = chunk.FileOffset;
              file.Write(chunk.Code, 0, chunk.Code.Length);
            }
          }
        }
        else
        {
          if(chkSuspend.Checked && !SuspendProcess())
          {
            MessageBox.Show("Unable to suspend the process.", "Cannot suspend process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
          }
          try
          {
            for(int i=0; i<chunks.Length; i++)
            {
              if(!WriteProcess(chunks[i].MemoryAddress, chunks[i].Code, false))
              {
                MessageBox.Show("Unable to write to the process memory." + (i == 0 ? null : "The process was partially patched."),
                                "Cannot write", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
              }
            }
          }
          finally
          {
            if(chkSuspend.Checked) ResumeProcess();
          }
        }
      }

      return true;
    }

    bool Patch()
    {
      uint offset;
      if(!uint.TryParse(txtOffset.Text, NumberStyles.HexNumber, null, out offset))
      {
        MessageBox.Show("Invalid offset. Enter a 32-bit hex number.", "Invalid offset", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      if(radFile.Checked)
      {
        using(FileStream file = new FileStream(txtFile.Text, FileMode.Open, FileAccess.ReadWrite))
        {
          file.Position = offset;
          file.Write(binaryData, 0, binaryData.Length);
        }
      }
      else if(!WriteProcess(offset, binaryData, chkSuspend.Checked))
      {
        MessageBox.Show("Unable to write to the process memory.", "Can not write", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    void ResumeProcess()
    {
      IntPtr hProcess = IntPtr.Zero;
      try
      {
        hProcess = Interop.OpenProcess(ProcessAccess.SuspendResume, false, ProcessId);
        if(hProcess != IntPtr.Zero) Interop.NtResumeProcess(hProcess);
      }
      finally
      {
        if(hProcess != IntPtr.Zero) Interop.CloseHandle(hProcess);
      }
    }

    bool SuspendProcess()
    {
      IntPtr hProcess = IntPtr.Zero;
      try
      {
        hProcess = Interop.OpenProcess(ProcessAccess.SuspendResume, false, ProcessId);
        return hProcess != IntPtr.Zero && Interop.NtSuspendProcess(hProcess) == 0;
      }
      finally
      {
        if(hProcess != IntPtr.Zero) Interop.CloseHandle(hProcess);
      }
    }

    bool WriteProcess(uint offset, byte[] data, bool suspend)
    {
      IntPtr hProcess = IntPtr.Zero;
      try
      {
        ProcessAccess access = ProcessAccess.OpMemory | ProcessAccess.WriteMemory;
        if(suspend) access |= ProcessAccess.SuspendResume;
        hProcess = Interop.OpenProcess(access, false, ProcessId);
        if(hProcess != IntPtr.Zero)
        {
          bool suspended = suspend && Interop.NtSuspendProcess(hProcess) == 0;
          IntPtr bytesWritten;
          bool success = Interop.WriteProcessMemory(hProcess, new IntPtr((int)offset), data, new IntPtr((uint)data.Length),
                                                    out bytesWritten);
          if(suspended) Interop.NtResumeProcess(hProcess);
          return success;
        }
      }
      finally
      {
        if(hProcess != IntPtr.Zero) Interop.CloseHandle(hProcess);
      }
      return false;
    }

    void btnBrowseFile_Click(object sender, EventArgs e)
    {
      using(OpenFileDialog ofd = new OpenFileDialog())
      {
        if(!string.IsNullOrEmpty(txtFile.Text))
        {
          try { ofd.InitialDirectory = Path.GetDirectoryName(txtFile.Text); }
          catch { }
        }

        ofd.ShowReadOnly = false;
        ofd.SupportMultiDottedExtensions = true;
        ofd.Title = "Select a file to patch...";
        ofd.Filter = "Executable files (*.exe)|*.exe|DLL files (*.dll)|*.dll|All files (*.*)|*";
        if(ofd.ShowDialog() == DialogResult.OK) txtFile.Text = ofd.FileName;
      }
    }

    void btnBrowseProcess_Click(object sender, EventArgs e)
    {
      using(ProcessForm form = new ProcessForm())
      {
        if(form.ShowDialog() == DialogResult.OK)
        {
          ProcessId          = form.ProcessId;
          lblProcess.Text    = form.ProcessName;
          radProcess.Checked = true;
          EnableOrDisableControls();
        }
      }
    }

    void btnPatch_Click(object sender, EventArgs e)
    {
      try
      {
        if(txtOffset.Enabled ? Patch() : MultiPatch())
        {
          DialogResult = DialogResult.OK;
          Close();
        }
      }
      catch(Exception ex)
      {
        Program.ShowErrorMessage(ex);
      }
    }

    void radProcess_CheckedChanged(object sender, EventArgs e)
    {
      chkSuspend.Enabled = radProcess.Checked;
      if(txtOffset.Enabled) txtOffset.Text = (radFile.Checked ? fileOffset : memAddress).ToString("X");
      EnableOrDisableControls();
    }

    void txtFile_TextChanged(object sender, EventArgs e)
    {
      if(txtFile.TextLength != 0) radFile.Checked = true;
      EnableOrDisableControls();
    }

    readonly byte[] binaryData;
    readonly string asm;
    readonly uint baseAddress = 0x400000, memAddress, fileOffset;
  }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AdamMil.Utilities;

namespace ExePatch
{
  partial class DisassemblyForm : Form
  {
    public DisassemblyForm()
    {
      InitializeComponent();
      cmbBits.SelectedIndex = 1;
    }

    public DisassemblyForm(uint baseAddress) : this()
    {
      this.baseAddress = baseAddress;
    }

    public bool Append
    {
      get { return chkAppend.Checked; }
    }

    public string Disassembly { get; private set; }

    #region Line
    struct Line
    {
      public Line(uint offset, string text)
      {
        Offset = offset;
        Text   = text;
      }

      public string Text;
      public uint Offset;
    }
    #endregion

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      try
      {
        byte[] binary;
        if(Clipboard.ContainsText() && BinaryUtility.TryParseHex(Clipboard.GetText(), out binary)) radClipboard.Checked = true;
      }
      catch { }
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      CenterToParent();
    }

    void EnableOrDisableControls()
    {
      btnDisassemble.Enabled = radClipboard.Checked || radProcess.Checked && processId != 0 || txtFile.TextLength != 0;
    }

    bool ReadProcess(uint offset, uint length, out byte[] binary)
    {
      IntPtr hProcess = IntPtr.Zero;
      try
      {
        hProcess = Interop.OpenProcess(ProcessAccess.ReadMemory, false, processId);
        if(hProcess != IntPtr.Zero)
        {
          binary = new byte[length];
          IntPtr bytesRead;
          Interop.ReadProcessMemory(hProcess, new IntPtr((int)offset), binary, new IntPtr((int)length), out bytesRead);
          return true;
        }
      }
      finally
      {
        if(hProcess != IntPtr.Zero) Interop.CloseHandle(hProcess);
      }

      binary = null;
      return false;
    }

    void UpdateOffset()
    {
      uint offset;
      if(uint.TryParse(txtStart.Text, NumberStyles.HexNumber, null, out offset))
      {
        if(radProcess.Checked && offset < baseAddress) offset += baseAddress;
        else if(radFile.Checked && offset >= baseAddress) offset -= baseAddress;
        else return;
        txtStart.Text = offset.ToString("X");
      }
    }

    void btnBrowse_Click(object sender, EventArgs e)
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
        ofd.Title = "Select a file to disassemble...";
        ofd.Filter = "Assembled files (*.bin;*.exe;*.dll)|*.bin;*.exe;*.dll|All files (*.*)|*";
        if(ofd.ShowDialog() == DialogResult.OK) txtFile.Text = ofd.FileName;
      }
    }

    void btnDisassemble_Click(object sender, EventArgs e)
    {
      string binPath = txtFile.Text;
      bool createdTempFile = false, labelAll = chkLabelAll.Checked;
      try
      {
        uint offset, length, origin;
        bool hasOrigin = true;
        if(!ParseNumber(txtStart.Text, "offset", out offset) || !ParseNumber(txtLength.Text, "length", out length) ||
           !ParseNumber(txtOrigin.Text, "origin", out origin))
        {
          return;
        }

        if(origin == 0 && StringUtility.IsNullOrSpace(txtOrigin.Text))
        {
          if(radClipboard.Checked) hasOrigin = false;
          else origin = radProcess.Checked ? offset : offset + baseAddress;
        }

        if(radProcess.Checked && (offset == 0 || length == 0))
        {
          MessageBox.Show("When disassembling from a process, the offset and length must be specified.", "Must specify region",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        uint dataOffset = offset;
        if(!radFile.Checked)
        {
          byte[] binary;
          if(radClipboard.Checked)
          {
            if(!Clipboard.ContainsText() || !BinaryUtility.TryParseHex(Clipboard.GetText(), out binary))
            {
              MessageBox.Show("Unable to find valid hex data on the clipboard.", "No data on clipboard",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
            }
          }
          else
          {
            if(!ReadProcess(dataOffset, length, out binary))
            {
              MessageBox.Show("Unable to read from the process.", "Error reading from process",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
            }
            dataOffset = 0;
            length = (uint)binary.Length;
          }

          if(!ValidateRegion(binary.Length, dataOffset, length)) return;
          if(length == 0) length = (uint)binary.Length - dataOffset;

          binPath = Path.GetTempFileName();
          createdTempFile = true;
          using(FileStream file = new FileStream(binPath, FileMode.Create, FileAccess.Write)) file.Write(binary, (int)dataOffset, (int)length);
          dataOffset = 0;
        }
        else
        {
          FileInfo info = new FileInfo(txtFile.Text);
          if(!info.Exists)
          {
            MessageBox.Show("The input file could not be found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }

          if(!ValidateRegion(info.Length, dataOffset, length)) return;

          if(length == 0)
          {
            length = (uint)Math.Min((long)uint.MaxValue, info.Length); // it'll just be compared against a threshold
          }
          else if(info.Length - dataOffset != length)
          {
            using(FileStream inFile = new FileStream(txtFile.Text, FileMode.Open, FileAccess.Read))
            {
              binPath = Path.GetTempFileName();
              createdTempFile = true;
              using(FileStream outFile = new FileStream(binPath, FileMode.Create, FileAccess.Write))
              {
                byte[] buffer = new byte[65536];
                inFile.Position = dataOffset;
                while(length != 0)
                {
                  int read = inFile.Read(buffer, 0, (int)Math.Min((uint)buffer.Length, length));
                  if(read == 0) break;
                  outFile.Write(buffer, 0, read);
                  length -= (uint)read;
                }
                if(!ValidateRegion(0, 0, length)) return; // make sure length == 0
                dataOffset = 0;
              }
            }
          }
        }

        if(length > 10000 &&
           MessageBox.Show("This will disassemble " + length.ToStringInvariant() + " bytes, which may take a long time! (Perhaps you " +
                           "forgot to specify the length.) Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
        {
          return;
        }

        bool success;
        ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(Program.ExeDirectory, "ndisasm.exe"));
        psi.Arguments = (chkAutosync.Checked ? "-a " : null) + "-b " + (16<<cmbBits.SelectedIndex).ToStringInvariant() + " " +
                        (dataOffset == 0 ? null : "-e " + dataOffset.ToStringInvariant() + " ") +
                        (origin == 0 ? null : "-o " + origin.ToStringInvariant() + " ") + Program.QuoteArgument(binPath);
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.UseShellExecute = false;
        psi.WindowStyle = ProcessWindowStyle.Hidden;
        using(Process proc = Process.Start(psi))
        {
          // read the lines from the disassembly
          List<Line> lines = new List<Line>();
          HashSet<uint> offsets = new HashSet<uint>(), targets = new HashSet<uint>();
          while(true)
          {
            string line = proc.StandardOutput.ReadLine();
            if(line == null) break;
            if(line.Length == 0 || line[0] == ' ') continue;

            int index = line.IndexOf(' ');
            uint location = uint.Parse(line.Substring(0, index), NumberStyles.HexNumber);
            while(line[index] == ' ') index++; // skip to the bytes
            while(line[index] != ' ') index++; // skip over the bytes
            while(line[index] == ' ') index++; // skip to the assembly
            line = removeRe.Replace(line.Substring(index), "");
            lines.Add(new Line(location, line));
            offsets.Add(location);
          }

          // replace offsets with label names
          for(int i=0; i<lines.Count; i++)
          {
            lines[i] = new Line(lines[i].Offset, targetRe.Replace(lines[i].Text, m =>
            {
              string hex = m.Groups[1].Value;
              uint target = uint.Parse(hex.Substring(hex[0] == '+' ? 3 : 2), NumberStyles.HexNumber);
              if(offsets.Contains(target))
              {
                targets.Add(target);
                return m.Value.Substring(0, m.Groups[1].Index - m.Index) + "loc_" + target.ToString("X") +
                       m.Value.Substring(m.Groups[1].Index + m.Groups[1].Length - m.Index);
              }
              else
              {
                return m.Value;
              }
            }));
          }

          StringBuilder sb = new StringBuilder();
          sb.Append("BITS ").Append((16<<cmbBits.SelectedIndex).ToStringInvariant()).AppendLine();
          if(hasOrigin)
          {
            string hex = origin.ToString("X");
            sb.Append("ORG ");
            if(!char.IsDigit(hex[0])) sb.Append('0');
            sb.Append(hex).Append("h");
            if(radFile.Checked && origin-offset != baseAddress)
            {
              sb.Append(" ; file offset = ");
              hex = offset.ToString("X");
              if(!char.IsDigit(hex[0])) sb.Append('0');
              sb.Append(hex).Append("h");
            }
            sb.AppendLine();
          }
          sb.AppendLine();

          foreach(Line line in lines)
          {
            if(labelAll || targets.Contains(line.Offset))
            {
              sb.Append("loc_").Append(line.Offset.ToString("X")).Append(":");
              if(labelAll) sb.Append(' ');
              else sb.AppendLine();
            }
            sb.AppendLine(hexRe.Replace(line.Text.Replace(",", ", "), m => // convert "x,y" to "x, y" and "0xabc" to "0ABCh"
            {
              string hex = m.Groups[2].Value.ToUpperInvariant();
              return (m.Groups[1].Success ? ", " : null) + (char.IsDigit(hex[0]) ? null : "0") + hex + "h";
            }));
          }
          Disassembly = sb.ToString();
          proc.WaitForExit();
          success = proc.ExitCode == 0;
        }

        if(success)
        {
          DialogResult = DialogResult.OK;
          Close();
        }
        else
        {
          MessageBox.Show("An error occurred during the disassembly.", "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      catch(Exception ex)
      {
        Program.ShowErrorMessage(ex);
      }
      finally
      {
        if(createdTempFile)
        {
          try { File.Delete(binPath); }
          catch { }
        }
      }
    }

    void btnSelectProcess_Click(object sender, EventArgs e)
    {
      using(ProcessForm form = new ProcessForm())
      {
        if(form.ShowDialog() == DialogResult.OK)
        {
          processId          = form.ProcessId;
          lblProcess.Text    = form.ProcessName;
          radProcess.Checked = true;
          EnableOrDisableControls();
        }
      }
    }

    void radFile_CheckedChanged(object sender, EventArgs e)
    {
      EnableOrDisableControls();
      UpdateOffset();
    }

    void radProcess_CheckedChanged(object sender, EventArgs e)
    {
      UpdateOffset();
    }

    void txtFile_TextChanged(object sender, EventArgs e)
    {
      if(txtFile.TextLength != 0) radFile.Checked = true;
      EnableOrDisableControls();
    }

    readonly uint baseAddress = 0x400000;
    int processId;

    static bool ParseNumber(string str, string name, out uint value)
    {
      value = 0;
      if(!StringUtility.IsNullOrSpace(str) && !uint.TryParse(str, NumberStyles.HexNumber, null, out value))
      {
        MessageBox.Show("Invalid " + name + ". Enter a 32-bit hex number.", "Invalid " + name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      return true;
    }

    static bool ValidateRegion(long size, uint offset, uint length)
    {
      uint end = offset + length;
      if(end > size || end < offset)
      {
        MessageBox.Show("The offset and/or length lie outside the data.", "Invalid offset or length",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      return true;
    }

    static readonly string[] jumpMneumonics = new string[] // in sorted order
    {
      "call", "ja", "jae", "jb", "jbe", "jc", "jcxnz", "jcxz", "je", "jg", "jge", "jl", "jle", "jmp", "jna", "jnae", "jnb",
      "jnbe", "jnc", "jne", "jng", "jnge", "jnl", "jnle", "jno", "jnp", "jns", "jnz", "jo", "jp", "jpe", "jpo", "js", "jz", 
    };

    static readonly Regex hexRe = new Regex(@"(, \+)?0x([0-9a-fA-F]+)", RegexOptions.Compiled);
    static readonly Regex removeRe = new Regex(@"(?:byte|word|dword) \+?(?=0x)", RegexOptions.Compiled);
    static readonly Regex targetRe = new Regex(
      @"(?:^(?:call|j(?:a|ae|b|be|c|cxnz|cxz|e|g|ge|l|le|mp|n(?:a|ae|b|be|c|e|g|ge|l|le|o|p|s|z)|o|p|pe|po|s|z))\s+(?:short|near|far)?\s*(?<target>\+?0x[0-9a-f]+))|
        \[(?<target>\+?0x[0-9a-f]+)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
  }
}

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
  #region Chunk
  sealed class Chunk
  {
    public Chunk(uint memAddress, uint fileOffset, byte[] code)
    {
      MemoryAddress = memAddress;
      FileOffset    = fileOffset;
      Code          = code;
    }

    public Chunk(uint memAddress, uint fileOffset, string error)
    {
      MemoryAddress = memAddress;
      FileOffset    = fileOffset;
      Error         = error;
    }

    public readonly uint MemoryAddress, FileOffset;
    public readonly byte[] Code;
    public readonly string Error;
  }
  #endregion

  static class Program
  {
    internal static string ExeDirectory
    {
      get { return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); }
    }

    internal static MainForm MainForm { get; private set; }

    internal static string StatusText
    {
      get { return MainForm.StatusText; }
      set { MainForm.StatusText = value; }
    }

    internal static byte[] Assemble(string asm, out string output)
    {
      string tmpFile = Path.GetTempFileName(), outFile = Path.GetTempFileName();
      string textOutput = "Unknown error.";
      byte[] assembledCode = null;
      try
      {
        asm = asm.Trim();
        if(asm.Length == 0)
        {
          assembledCode = new byte[0];
          textOutput = "";
        }
        else
        {
          File.WriteAllText(tmpFile, asm);
          ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(ExeDirectory, "nasm.exe"));
          psi.Arguments = "-Ox -f bin -o " + QuoteArgument(outFile) + " " + QuoteArgument(tmpFile);
          psi.CreateNoWindow = true;
          psi.RedirectStandardError = true;
          psi.UseShellExecute = false;
          psi.WindowStyle = ProcessWindowStyle.Hidden;
          using(Process proc = Process.Start(psi))
          {
            string stderr = proc.StandardError.ReadToEnd().Trim();
            proc.WaitForExit();
            int result = proc.ExitCode;

            if(!string.IsNullOrEmpty(stderr))
            {
              textOutput = stderr.Replace(tmpFile+":", "").Replace("\r", "");
            }
            else if(result == 0)
            {
              assembledCode = File.ReadAllBytes(outFile);
            }
          }
        }
      }
      catch(Exception ex)
      {
        textOutput = ex.GetType().Name + " " + ex.Message;
      }
      finally
      {
        try { File.Delete(tmpFile); }
        catch { }
        try { File.Delete(outFile); }
        catch { }
      }

      output = textOutput;
      return assembledCode;
    }

    internal static Chunk[] AssembleChunks(string asm, uint baseAddress)
    {
      StringBuilder sb = new StringBuilder();
      List<string> chunkAsm = new List<string>();
      using(StringReader reader = new StringReader(asm))
      {
        while(true)
        {
          string line = reader.ReadLine();
          if(line == null) break;
          line = line.Trim();
          if(line.Length == 0 || line[0] == ';') continue;

          uint memAddress, fileOffset;
          if(ParseOrgLine(line, baseAddress, false, out memAddress, out fileOffset))
          {
            chunkAsm.Add(sb.ToString());
            sb.Length = chunkAsm[0].Length;
          }

          sb.AppendLine(line);
        }

        if(sb.Length > (chunkAsm.Count == 0 ? 0 : chunkAsm[0].Length)) chunkAsm.Add(sb.ToString());
      }

      List<Chunk> chunks = new List<Chunk>(chunkAsm.Count);
      for(int i = chunkAsm.Count > 1 ? 1 : 0, j = 0; i<chunkAsm.Count; i++, j++)
      {
        uint memAddress, fileAddress;
        byte[] code = null;
        string error =  null;
        if(!ParseOrgLine(chunkAsm[i], baseAddress, chunkAsm.Count == 1, out memAddress, out fileAddress))
        {
          error = "Missing or invalid ORG line.";
        }
        else
        {
          code = Assemble(chunkAsm[i], out error);
          if(code != null) error = null;
        }

        if(error != null)
        {
          chunks.Add(new Chunk(memAddress, fileAddress, error));
        }
        else if(code.Length != 0)
        {
          chunks.Add(new Chunk(memAddress, fileAddress, code));
        }
      }

      return chunks.ToArray();
    }

    internal static bool ParseOrgLine(string text, uint baseAddress, bool allowDefaults, out uint memAddress, out uint fileOffset)
    {
      Match m = orgRe.Match(text);
      if(m.Success)
      {
        memAddress = uint.Parse(m.Groups[1].Value, m.Groups[2].Success ? NumberStyles.HexNumber : NumberStyles.Integer);
        if(m.Groups[3].Success)
        {
          fileOffset = uint.Parse(m.Groups[3].Value, m.Groups[4].Success ? NumberStyles.HexNumber : NumberStyles.Integer);
        }
        else
        {
          fileOffset = memAddress >= baseAddress ? memAddress - baseAddress : memAddress;
        }
        return true;
      }
      else if(allowDefaults && !anyOrgRe.IsMatch(text))
      {
        memAddress = 0x400000;
        fileOffset = 0;
        return true;
      }
      else
      {
        memAddress = 0;
        fileOffset = 0;
        return false;
      }
    }

    internal static string QuoteArgument(string text)
    {
      return text.IndexOf(' ') == -1 ? text : "\"" + text + "\"";
    }

    internal static void ShowErrorMessage(Exception ex)
    {
      MessageBox.Show(ex.GetType().Name + " - " + ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using(MainForm = new MainForm(args)) Application.Run(MainForm);
    }

    static readonly Regex orgRe = new Regex(@"^ORG ([0-9a-f]{1,8})(h)?\b(?:\s*;\s*file offset\s*(?:\=\s*)?([0-9a-f]{1,8})(h)?\b)?",
                                            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
    static readonly Regex anyOrgRe = new Regex("^ORG ", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
  }
}

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

    #region Chunk
    internal struct Chunk
    {
      public Chunk(uint memAddress, uint fileOffset, byte[] code)
      {
        MemoryAddress = memAddress;
        FileOffset    = fileOffset;
        Code          = code;
      }
      public readonly uint MemoryAddress, FileOffset;
      public readonly byte[] Code;
    }
    #endregion

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
              byte[] bin = assembledCode = File.ReadAllBytes(outFile);
              if(bin.Length > 100000)
              {
                textOutput = "The output is too large to display.";
              }
              else
              {
                const string HexChars = "0123456789ABCDEF";
                StringBuilder sb = new StringBuilder();
                for(int i=0; i<bin.Length; )
                {
                  bool sep = false;
                  for(int e=Math.Min(bin.Length, i+16); i<e; i++)
                  {
                    if(sep) sb.Append(' ');
                    else sep = true;
                    byte value = bin[i];
                    sb.Append(HexChars[value>>4]).Append(HexChars[value&0xF]);
                  }
                  if(i < bin.Length) sb.Append('\n');
                }
                textOutput = sb.ToString();
              }
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

    internal static Chunk[] AssembleChunks(string asm, uint baseAddress, out int failedChunk, out string error)
    {
      StringBuilder sb = new StringBuilder();
      List<string> chunkAsm = new List<string>();
      using(StringReader reader = new StringReader(asm))
      {
        while(true)
        {
          string line = reader.ReadLine();
          if(line == null) break;
          else if(line.Length == 0 || line[0] == ';') continue;

          uint memAddress, fileOffset;
          if(ParseOrgLine(line, baseAddress, out memAddress, out fileOffset))
          {
            chunkAsm.Add(sb.ToString());
            sb.Length = chunkAsm[0].Length;
          }

          sb.AppendLine(line);
        }

        if(sb.Length > (chunkAsm.Count == 0 ? 0 : chunkAsm[0].Length)) chunkAsm.Add(sb.ToString());
      }

      List<Chunk> chunks = new List<Chunk>(chunkAsm.Count);
      failedChunk = -1;
      error       = null;
      for(int i = chunkAsm.Count > 1 ? 1 : 0, j = 0; i<chunkAsm.Count; i++, j++)
      {
        uint memAddress, fileAddress;
        byte[] code = null;
        if(!ParseOrgLine(chunkAsm[i], baseAddress, out memAddress, out fileAddress))
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
          failedChunk = i;
          break;
        }
        else if(code.Length != 0)
        {
          chunks.Add(new Chunk(memAddress, fileAddress, code));
        }
      }

      return error == null ? chunks.ToArray() : null;
    }

    internal static bool ParseOrgLine(string text, uint baseAddress, out uint memAddress, out uint fileOffset)
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
      }
      else
      {
        memAddress  = 0;
        fileOffset = 0;
      }
      return m.Success;
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
  }
}

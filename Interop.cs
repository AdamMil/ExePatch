using System;
using System.Runtime.InteropServices;

namespace ExePatch
{
  [Flags]
  enum ProcessAccess : uint
  {
    Terminate=0x1, CreateThread=0x2, OpMemory=0x8,
    ReadMemory=0x10, WriteMemory=0x20, DuplicateHandle=0x40, CreateProcess=0x80,
    SetQuota=0x100, SetInformation=0x200, QueryInformation=0x400, SuspendResume=0x800,
    QueryLimitedInformation=0x1000,
    Syncronize=0x100000
  }

  [System.Security.SuppressUnmanagedCodeSecurity]
  static class Interop
  {
    [DllImport("kernel32.dll", ExactSpelling=true)]
    public static extern IntPtr CloseHandle(IntPtr handle);

    [DllImport("kernel32.dll", ExactSpelling=true)]
    public static extern IntPtr OpenProcess(ProcessAccess access, bool inheritHandle, int processId);

    [DllImport("kernel32.dll", ExactSpelling=true)]
    public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr pBaseAddress, [Out] byte[] buffer, IntPtr byteCount,
                                                out IntPtr bytesRead);

    [DllImport("kernel32.dll", ExactSpelling=true)]
    public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr pBaseAddress, [In] byte[] buffer, IntPtr byteCount,
                                                 out IntPtr bytesWritten);

    [DllImport("ntdll.dll", ExactSpelling=true)]
    public static extern int NtResumeProcess(IntPtr hProcess);

    [DllImport("ntdll.dll", ExactSpelling=true)]
    public static extern int NtSuspendProcess(IntPtr hProcess);
  }
}

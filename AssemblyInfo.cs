using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("ExePatch")]
[assembly: AssemblyDescription("A program to assist in patching executables and processes while reverse engineering.")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyProduct("ExePatch")]
[assembly: AssemblyCopyright("Copyright © Adam Milazzo 2014")]

[assembly: ComVisible(false)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

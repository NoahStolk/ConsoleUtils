using System;
using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	internal static class KernelUtils
	{
		[DllImport("kernel32")]
		internal static extern IntPtr GetStdHandle(StdHandle index);

		[DllImport("kernel32")]
		internal static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize, uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFontSize[] fonts);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref ConsoleFontInfoEx consoleCurrentFontEx);
	}
}
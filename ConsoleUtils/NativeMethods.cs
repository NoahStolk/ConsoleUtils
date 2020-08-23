using ConsoleUtils.Kernel;
using System;
using System.Runtime.InteropServices;

namespace ConsoleUtils
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr GetStdHandle(StdHandle index);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)] bool bMaximize, uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFontSize[] fonts);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref ConsoleFontInfoEx consoleCurrentFontEx);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool GetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput, ref ConsoleScreenBufferInfoEx csbe);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool SetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput, ref ConsoleScreenBufferInfoEx csbe);
	}
}
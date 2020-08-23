using ConsoleUtils.Kernel;
using System;
using System.Runtime.InteropServices;

namespace ConsoleUtils.Fonts
{
	public static class ConsoleFontUtils
	{
		private static readonly int tmpfTruetype = 4;
		private static readonly IntPtr invalidHandleValue = new IntPtr(-1);

		public static void SetConsoleFont(string fontName, short fontSize, int fontWeight)
		{
			unsafe
			{
				IntPtr hnd = NativeMethods.GetStdHandle(StdHandle.OutputHandle);
				if (hnd != invalidHandleValue)
				{
					ConsoleFontInfoEx info = new ConsoleFontInfoEx();
					info.cbSize = (uint)Marshal.SizeOf(info);

					ConsoleFontInfoEx newInfo = new ConsoleFontInfoEx();
					newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
					newInfo.fontFamily = tmpfTruetype;
					IntPtr ptr = new IntPtr(newInfo.faceName);
					Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

					newInfo.dwFontSize = new Coord(fontSize, fontSize);
					newInfo.fontWeight = fontWeight;
					NativeMethods.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
				}
			}
		}
	}
}
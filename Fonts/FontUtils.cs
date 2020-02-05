using ConsoleUtils.Kernel;
using System;
using System.Runtime.InteropServices;

namespace ConsoleUtils.Fonts
{
	public static class FontUtils
	{
		private static readonly int TmpfTruetype = 4;
		private static readonly IntPtr InvalidHandleValue = new IntPtr(-1);

		public static void SetConsoleFont(string fontName, short fontSize, int fontWeight)
		{
			unsafe
			{
				IntPtr hnd = KernelUtils.GetStdHandle(StdHandle.OutputHandle);
				if (hnd != InvalidHandleValue)
				{
					ConsoleFontInfoEx info = new ConsoleFontInfoEx();
					info.cbSize = (uint)Marshal.SizeOf(info);

					ConsoleFontInfoEx newInfo = new ConsoleFontInfoEx();
					newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
					newInfo.fontFamily = TmpfTruetype;
					IntPtr ptr = new IntPtr(newInfo.faceName);
					Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

					newInfo.dwFontSize = new Coord(fontSize, fontSize);
					newInfo.fontWeight = fontWeight;
					KernelUtils.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
				}
			}
		}
	}
}
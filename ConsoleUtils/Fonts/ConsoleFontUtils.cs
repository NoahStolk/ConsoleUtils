using ConsoleUtils.Kernel;
using System;
using System.Runtime.InteropServices;

namespace ConsoleUtils.Fonts
{
	public static class ConsoleFontUtils
	{
		private static readonly int _tmpfTruetype = 4;
		private static readonly IntPtr _invalidHandleValue = new IntPtr(-1);

		public static void SetConsoleFont(string fontName, short fontSize, int fontWeight)
		{
			unsafe
			{
				IntPtr hnd = NativeMethods.GetStdHandle(StdHandle.OutputHandle);
				if (hnd != _invalidHandleValue)
				{
					ConsoleFontInfoEx info = new ConsoleFontInfoEx();
					info._cbSize = (uint)Marshal.SizeOf(info);

					ConsoleFontInfoEx newInfo = new ConsoleFontInfoEx();
					newInfo._cbSize = (uint)Marshal.SizeOf(newInfo);
					newInfo._fontFamily = _tmpfTruetype;
					IntPtr ptr = new IntPtr(newInfo._faceName);
					Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

					newInfo._dwFontSize = new Coord { _x = fontSize, _y = fontSize };
					newInfo._fontWeight = fontWeight;
					NativeMethods.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
				}
			}
		}
	}
}
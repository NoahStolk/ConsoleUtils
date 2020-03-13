using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal unsafe struct ConsoleFontInfoEx
	{
		private const int faceSize = 32;

		internal uint cbSize;
		internal uint nFont;
		internal Coord dwFontSize;
		internal int fontFamily;
		internal int fontWeight;
		internal fixed char faceName[faceSize];
	}
}
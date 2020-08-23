using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct ConsoleScreenBufferInfoEx
	{
		internal int cbSize;
		internal Coord dwSize;
		internal Coord dwCursorPosition;
		internal ushort wAttributes;
		internal SmallRect srWindow;
		internal Coord dwMaximumWindowSize;
		internal ushort wPopupAttributes;
		internal bool bFullscreenSupported;
		internal ColorReference black;
		internal ColorReference darkBlue;
		internal ColorReference darkGreen;
		internal ColorReference darkCyan;
		internal ColorReference darkRed;
		internal ColorReference darkMagenta;
		internal ColorReference darkYellow;
		internal ColorReference gray;
		internal ColorReference darkGray;
		internal ColorReference blue;
		internal ColorReference green;
		internal ColorReference cyan;
		internal ColorReference red;
		internal ColorReference magenta;
		internal ColorReference yellow;
		internal ColorReference white;
	}
}
using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal unsafe struct ConsoleFontInfoEx
	{
		private const int _faceSize = 32;

		internal uint _cbSize;
		internal uint _nFont;
		internal Coord _dwFontSize;
		internal int _fontFamily;
		internal int _fontWeight;
		internal fixed char _faceName[_faceSize];
	}
}
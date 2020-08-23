using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct ColorReference
	{
		internal uint _colorDWORD;

		internal ColorReference(byte r, byte g, byte b)
			=> _colorDWORD = (uint)(r + (g << 8) + (b << 16));
	}
}
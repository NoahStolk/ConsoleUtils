using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct ColorReference
	{
		internal uint colorDWORD;

		internal ColorReference(byte r, byte g, byte b)
			=> colorDWORD = (uint)(r + (g << 8) + (b << 16));
	}
}
using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Coord
	{
		internal short _x;
		internal short _y;
	}
}
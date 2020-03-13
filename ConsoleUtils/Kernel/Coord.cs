using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Coord
	{
		internal short x;
		internal short y;

		internal Coord(short x, short y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
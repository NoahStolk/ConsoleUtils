using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct SmallRect
	{
		internal short _left;
		internal short _top;
		internal short _right;
		internal short _bottom;
	}
}
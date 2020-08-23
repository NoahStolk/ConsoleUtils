using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct SmallRect
	{
		internal short left;
		internal short top;
		internal short right;
		internal short bottom;
	}
}
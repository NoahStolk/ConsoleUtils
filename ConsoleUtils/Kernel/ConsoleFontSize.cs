using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ConsoleFontSize
	{
		internal uint index;
		internal short sizeX;
		internal short sizeY;
	}
}
using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ConsoleFontSize
	{
		internal uint _index;
		internal short _sizeX;
		internal short _sizeY;
	}
}
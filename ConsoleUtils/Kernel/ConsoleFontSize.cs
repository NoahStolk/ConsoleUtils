using System.Runtime.InteropServices;

namespace ConsoleUtils.Kernel
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ConsoleFontSize
	{
		public uint index;
		public short sizeX;
		public short sizeY;
	}
}
using ConsoleUtils.Kernel;
using System;
using System.Runtime.InteropServices;
using Cmd = System.Console;

namespace ConsoleUtils.Colors
{
	public static class ConsoleColorUtils
	{
		public static void WriteColor(string message, ConsoleColor color)
		{
			Cmd.ForegroundColor = color;
			Cmd.Write(message);
			Cmd.ResetColor();
		}

		public static void WriteLineColor(string message, ConsoleColor color)
			=> WriteColor($"{message}{Environment.NewLine}", color);

		public static void WriteColorMultiple(params MessagePart[] messageParts)
		{
			foreach (MessagePart mp in messageParts)
			{
				Cmd.ForegroundColor = mp.Color;
				Cmd.Write(mp.Message);
			}
			Cmd.ResetColor();
		}

		public static void WriteLineColorMultiple(params MessagePart[] messageParts)
		{
			WriteColorMultiple(messageParts);
			Cmd.WriteLine();
		}

		public static void ClearLine(int offset)
		{
			int currentLineCursor = Cmd.CursorTop + offset;
			Cmd.SetCursorPosition(0, Cmd.CursorTop);
			Cmd.Write(new string(' ', Cmd.BufferWidth));
			Cmd.SetCursorPosition(0, currentLineCursor - offset);
		}

		public static int ModifyConsoleColor(byte colorIndex, byte r, byte g, byte b)
		{
			ConsoleScreenBufferInfoEx csbe = new ConsoleScreenBufferInfoEx();
			csbe._cbSize = Marshal.SizeOf(csbe);
			IntPtr hConsoleOutput = NativeMethods.GetStdHandle(StdHandle.OutputHandle);
			if (hConsoleOutput == new IntPtr(-1))
				return Marshal.GetLastWin32Error();

			bool brc = NativeMethods.GetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
			if (!brc)
				return Marshal.GetLastWin32Error();

			switch (colorIndex)
			{
				case 0: csbe._black = new ColorReference(r, g, b); break;
				case 1: csbe._darkBlue = new ColorReference(r, g, b); break;
				case 2: csbe._darkGreen = new ColorReference(r, g, b); break;
				case 3: csbe._darkCyan = new ColorReference(r, g, b); break;
				case 4: csbe._darkRed = new ColorReference(r, g, b); break;
				case 5: csbe._darkMagenta = new ColorReference(r, g, b); break;
				case 6: csbe._darkYellow = new ColorReference(r, g, b); break;
				case 7: csbe._gray = new ColorReference(r, g, b); break;
				case 8: csbe._darkGray = new ColorReference(r, g, b); break;
				case 9: csbe._blue = new ColorReference(r, g, b); break;
				case 10: csbe._green = new ColorReference(r, g, b); break;
				case 11: csbe._cyan = new ColorReference(r, g, b); break;
				case 12: csbe._red = new ColorReference(r, g, b); break;
				case 13: csbe._magenta = new ColorReference(r, g, b); break;
				case 14: csbe._yellow = new ColorReference(r, g, b); break;
				case 15: csbe._white = new ColorReference(r, g, b); break;
			}

			++csbe._srWindow._bottom;
			++csbe._srWindow._right;
			brc = NativeMethods.SetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
			if (!brc)
				return Marshal.GetLastWin32Error();

			return 0;
		}
	}
}
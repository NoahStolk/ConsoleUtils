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
		{
			WriteColor($"{message}{Environment.NewLine}", color);
		}

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

		public static int ModifyConsoleColor(ConsoleColor color, byte r, byte g, byte b)
		{
			ConsoleScreenBufferInfoEx csbe = new ConsoleScreenBufferInfoEx();
			csbe.cbSize = Marshal.SizeOf(csbe);
			IntPtr hConsoleOutput = NativeMethods.GetStdHandle(StdHandle.OutputHandle);
			if (hConsoleOutput == new IntPtr(-1))
				return Marshal.GetLastWin32Error();

			bool brc = NativeMethods.GetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
			if (!brc)
				return Marshal.GetLastWin32Error();

			switch (color)
			{
				case ConsoleColor.Black: csbe.black = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkBlue: csbe.darkBlue = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkGreen: csbe.darkGreen = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkCyan: csbe.darkCyan = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkRed: csbe.darkRed = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkMagenta: csbe.darkMagenta = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkYellow: csbe.darkYellow = new ColorReference(r, g, b); break;
				case ConsoleColor.Gray: csbe.gray = new ColorReference(r, g, b); break;
				case ConsoleColor.DarkGray: csbe.darkGray = new ColorReference(r, g, b); break;
				case ConsoleColor.Blue: csbe.blue = new ColorReference(r, g, b); break;
				case ConsoleColor.Green: csbe.green = new ColorReference(r, g, b); break;
				case ConsoleColor.Cyan: csbe.cyan = new ColorReference(r, g, b); break;
				case ConsoleColor.Red: csbe.red = new ColorReference(r, g, b); break;
				case ConsoleColor.Magenta: csbe.magenta = new ColorReference(r, g, b); break;
				case ConsoleColor.Yellow: csbe.yellow = new ColorReference(r, g, b); break;
				case ConsoleColor.White: csbe.white = new ColorReference(r, g, b); break;
			}

			++csbe.srWindow.bottom;
			++csbe.srWindow.right;
			brc = NativeMethods.SetConsoleScreenBufferInfoEx(hConsoleOutput, ref csbe);
			if (!brc)
				return Marshal.GetLastWin32Error();

			return 0;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using Cmd = System.Console;

namespace ConsoleUtils.Colors
{
	public static class ConsoleColorUtils
	{
		public static List<ConsoleColor> ConsoleColors = new List<ConsoleColor>();

		static ConsoleColorUtils()
		{
			((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor))).ToList().ForEach(c => ConsoleColors.Add(c));
		}

		public static void WriteColor(string message, ConsoleColor color)
		{
			Cmd.ForegroundColor = color;
			Cmd.Write(message);
			Cmd.ResetColor();
		}

		public static void WriteLineColor(string message, ConsoleColor color)
		{
			WriteColor($"{message}\n", color);
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
	}
}
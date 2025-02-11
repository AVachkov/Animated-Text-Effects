using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace Animix
{
    public static class AnimatedTextEffects
    { 
        public static void Documentation()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("AnimatedTextEffects Documentation");
            Console.WriteLine("===============================");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - WriteHello() - Writes 'Hello!' with a typewriter effect.");
            Console.WriteLine("2 - WriteGoodbye() - Writes 'Goodbye!' at the bottom of the console.");
            Console.WriteLine("3 - WriteStartMsg() - Countdown with 'Starting in 3... 2... 1...'.");
            Console.WriteLine("4 - TypeWriterEffect([text to write]*, [speed in MS]*, forecolor) - Writes text with typewriter effect.");
            Console.WriteLine("5 - ShakeText([text to write]*, range*, duration*, forecolor) - Shakes text within a range for a duration.");
            Console.WriteLine("6 - RotateText([text to write]*, forecolor) - Rotates text upside down.");
            Console.WriteLine("7 - PulseText([text to write]*, [speed in MS], timeInSec) - Pulses text with different colors.");
            Console.WriteLine("8 - Beep() - Plays a beep sound.");
            Console.WriteLine("9 - TravelTheConsole([speed in MS]*, singleColor) - Moves a character across the console.");
            Console.WriteLine("10 - END");
            Console.WriteLine("Press [ENTER] to see documentation again.");
            Console.ResetColor();
        }
        public static void WriteHello()
        {
            Console.Write("H"); Thread.Sleep(200); Console.Write("e"); Thread.Sleep(200);
            Console.Write("l"); Thread.Sleep(200); Console.Write("l"); Thread.Sleep(200);
            Console.Write("o"); Thread.Sleep(200); Console.Write("!"); Thread.Sleep(600);
        }
        public static void WriteGoodbye()
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);
            Console.Write("G"); Thread.Sleep(200); Console.Write("o"); Thread.Sleep(200);
            Console.Write("o"); Thread.Sleep(200); Console.Write("d"); Thread.Sleep(200);
            Console.Write("b"); Thread.Sleep(200); Console.Write("y"); Thread.Sleep(200);
            Console.Write("e"); Thread.Sleep(200); Console.Write("!"); Thread.Sleep(400);
            Console.WriteLine();
        }
        public static void WriteStartMsg()
        {
            Console.Write("S"); Thread.Sleep(200); Console.Write("t"); Thread.Sleep(200);
            Console.Write("a"); Thread.Sleep(200); Console.Write("r"); Thread.Sleep(200);
            Console.Write("t"); Thread.Sleep(200); Console.Write("i"); Thread.Sleep(200);
            Console.Write("n"); Thread.Sleep(200); Console.Write("g"); Thread.Sleep(200);
            Console.Write(" "); Thread.Sleep(50); Console.Write("i"); Thread.Sleep(200);
            Console.Write("n"); Console.Write(" "); Thread.Sleep(200); Console.Write("3");
            Thread.Sleep(200);
            Console.Write("."); Thread.Sleep(300); Console.Write("."); Thread.Sleep(400);
            Console.Write("."); Thread.Sleep(500); Console.Write("2"); Thread.Sleep(200);
            Console.Write("."); Thread.Sleep(400); Console.Write("."); Thread.Sleep(400);
            Console.Write("."); Thread.Sleep(500); Console.Write("1"); Thread.Sleep(1000);
        }
        public static void TypeWriterEffect(string text, int speedInMS, ConsoleColor optionalColorParam = ConsoleColor.White)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = optionalColorParam;
            foreach (var ch in text)
            {
                Console.Write(ch);
                if (ch != ' ')
                    Thread.Sleep(speedInMS);
            }

            Console.ResetColor();
        }
        public static void ShakeText(string text, int range, int durationInMS,
            ConsoleColor optionalColorParam = ConsoleColor.White)
        {
            if (range > Console.BufferWidth)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Range cannot be greater than Buffer Width ({Console.BufferWidth})");
                Console.ResetColor();
                return;
            }

            if (range < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Range cannot be negative number ({Console.BufferWidth})");
                Console.ResetColor();
                return;
            }

            if (durationInMS < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Duration must be positive number!");
                Console.ResetColor();
                return;
            }

            Console.CursorVisible = false;
            Console.ForegroundColor = optionalColorParam;

            int defaultCursorLeft = Console.CursorLeft;
            int defaultCursorTop = Console.CursorTop;

            var r = new Random();
            var startTime = DateTime.Now;

            int consoleWidth = Console.WindowWidth;

            range = Math.Max(1, range);

            while ((DateTime.Now - startTime).TotalMilliseconds < durationInMS)
            {
                double elapsedTime = (DateTime.Now - startTime).TotalMilliseconds;
                int reducedIntensity = (int)(range * (1 - (elapsedTime / durationInMS)));

                int randomMovement = r.Next(-reducedIntensity, reducedIntensity);
                int newCursorLeft = defaultCursorLeft + randomMovement;

                if (newCursorLeft < 0)
                    newCursorLeft = 0;

                if (newCursorLeft >= consoleWidth)
                    newCursorLeft = consoleWidth - 1;

                Console.CursorLeft = newCursorLeft;

                Console.Write(text);
                Thread.Sleep(50);

                Console.CursorLeft = defaultCursorLeft;

                Console.Write(new string(' ', range));
            }
            Console.CursorLeft = defaultCursorLeft;
            Console.CursorTop = defaultCursorTop;

            Console.WriteLine(text);

            Console.ResetColor();
        }
        public static void RotateText(string text, ConsoleColor optionalColorParam = ConsoleColor.White)
        {
            Dictionary<char, char> rotatedChars = new Dictionary<char, char>
            {
                {'a', 'ɐ'}, {'b', 'q'}, {'c', 'ɔ'}, {'d', 'p'}, {'e', 'ǝ'},
                {'f', 'ʇ'}, {'g', 'ƃ'}, {'h', 'ɥ'}, {'i', 'ᴉ'}, {'j', 'ɾ'},
                {'k', 'ʞ'}, {'l', 'ʃ'}, {'m', 'ɯ'}, {'n', 'u'}, {'o', 'o'},
                {'p', 'd'}, {'q', 'b'}, {'r', 'ɹ'}, {'s', 's'}, {'t', 'ʇ'},
                {'u', 'n'}, {'v', 'ʌ'}, {'w', 'ʍ'}, {'x', 'x'}, {'y', 'ʎ'},
                {'z', 'z'}, {'A', '∀'}, {'B', 'ᗺ'}, {'C', 'Ɔ'}, {'D', 'ᗡ'},
                {'E', 'Ǝ'}, {'F', 'Ⅎ'}, {'G', '⅁'}, {'H', 'H'}, {'I', 'I'},
                {'J', 'Ⴑ'}, {'K', 'ʞ'}, {'L', '˥'}, {'M', 'W'}, {'N', 'ᴎ'},
                {'O', 'O'}, {'P', 'Ԁ'}, {'Q', 'Ό'}, {'R', 'ᴚ'}, {'S', 'S'},
                {'T', '⊥'}, {'U', '∩'}, {'V', 'Λ'}, {'W', 'M'}, {'X', 'X'},
                {'Y', '⅄'}, {'Z', 'Z'}, {'0', '0'}, {'1', 'Ɩ'}, {'2', '↊'},
                {'3', 'Ɛ'}, {'4', 'ㄣ'}, {'5', 'ϛ'}, {'6', '9'}, {'7', 'ㄥ'},
                {'8', '8'}, {'9', '6'}, {'.', '˙'}, {',', '\''}, {'?', '¿'},
                {'!', '¡'}, {'"', '„'}, {'(', ')'}, {')', '('}, {'[', ']'},
                {']', '['}, {'{', '}'}, {'}', '{'}, {'<', '>'}, {'>', '<'},
                { ' ', ' ' }
            };

            foreach (var ch in text)
            {
                if ((int)ch < 0 || (int)ch > 127 || !rotatedChars.ContainsKey(ch))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not supported character table.\nUse ASCII table only.");
                    Console.ResetColor();
                    return;
                }
            }

            Console.CursorVisible = false;

            string reversedText = "";
            var sb = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            reversedText = sb.ToString();

            for (int i = 0; i < reversedText.Length; i++)
            {
                if (rotatedChars.ContainsKey(reversedText[i]))
                {
                    var rotatedChar = rotatedChars.FirstOrDefault(c => c.Key == reversedText[i]);

                    reversedText = reversedText.Remove(i, 1);
                    reversedText = reversedText.Insert(i, rotatedChar.Value.ToString());
                }
            }
            Console.WriteLine(reversedText);
        }
        public static void PulseText(string text, int speedInMS = 100, int timeInSec = 8)
        {
            if (speedInMS < 0 || timeInSec < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Time must be positive number!");
                Console.ResetColor();
                return;
            }

            ConsoleColor[] colors =
            {
                ConsoleColor.Black, ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White,
                ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Black
            };

            Console.CursorVisible = false;

            int defaultCursorLeft = Console.CursorLeft;
            int defaultCursorTop = Console.CursorTop;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed.TotalSeconds < timeInSec)
            {
                foreach (var color in colors)
                {
                    Console.SetCursorPosition(defaultCursorLeft, defaultCursorTop);
                    Console.ForegroundColor = color;
                    Console.Write(text);
                    Thread.Sleep(speedInMS);
                    Console.SetCursorPosition(defaultCursorLeft, defaultCursorTop);
                    Console.Write(new string(' ', text.Length));
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(defaultCursorLeft, defaultCursorTop);
            Console.WriteLine(text);
        }
        public static void Beep() => Console.Beep();
        public static void TravelTheConsole(int speedInMS, bool singleColor = true)
        {
            List<ConsoleColor> colors = new List<ConsoleColor>();

            for (int i = 0; i <= 15; i++)
            {
                colors.Add((ConsoleColor)i);
            }

            Random r = new Random();
            int consoleWidth = Console.BufferWidth - 1;
            int consoleHeight = Console.BufferHeight - 1;
            int j = 0;
            Console.CursorVisible = false;
            bool movingRight = true;

            WriteStartMsg();
            for (int i = 0; i < consoleWidth + consoleHeight; i++)
            {
                for (int k = 0; k <= consoleWidth; k++)
                {
                    Console.Clear();
                    if (j >= consoleHeight)
                        break;

                    Console.SetCursorPosition(movingRight ? k : consoleWidth - k, j);
                    if (!singleColor)
                        Console.ForegroundColor = colors[r.Next(colors.Count)];

                    Console.Write(movingRight ? '>' : '<');
                    Console.ResetColor();
                    Thread.Sleep(speedInMS);
                }
                if (j < consoleHeight)
                    j++;
                movingRight = !movingRight;
            }
        }
    }
}

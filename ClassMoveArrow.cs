namespace Provodnik
{
    internal class ClassMoveArrow
    {
        static public int action;
        public void Move(ClassArrow arrow, List<string> directories)
        {
            ConsoleKeyInfo PressedKey = Console.ReadKey();
            switch (PressedKey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (arrow.y < arrow.max)
                    {
                        Console.SetCursorPosition(0, arrow.y);
                        Console.WriteLine(arrow.arrow.Replace("->", arrow.empty));
                        Console.SetCursorPosition(0, ++arrow.y);
                        Console.WriteLine(arrow.arrow);
                    }
                    else if (directories.Count == 1)
                    {
                        Console.SetCursorPosition(0, arrow.min);
                        Console.WriteLine(arrow.arrow.Replace("->", arrow.empty));
                        Console.SetCursorPosition(0, arrow.min);
                        Console.WriteLine(arrow.arrow);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (arrow.y > arrow.min)
                    {
                        Console.SetCursorPosition(0, arrow.y);
                        Console.WriteLine(arrow.arrow.Replace("->", arrow.empty));
                        Console.SetCursorPosition(0, --arrow.y);
                        Console.WriteLine(arrow.arrow);
                    }
                    break;
                case ConsoleKey.Enter:
                    action = 1;
                    break;
                case ConsoleKey.Escape:
                    action = -1;
                    break;
            }
        }
    }
}

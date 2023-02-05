using System.IO;
using System;

namespace Provodnik
{
    static internal class ClassActions
    {
        public static void Enter(string path, ClassArrow arrow, List<string> directories)
        {
            ClassMoveArrow moveArrow = new ClassMoveArrow();
            path = directories[arrow.y - arrow.min];
            Program.path = path;
            Draw(path, arrow, directories);
            moveArrow.Move(arrow, directories);
        }
        public static void Escape(string path, ClassArrow arrow, List<string> directories)
        {
            ClassMoveArrow moveArrow = new ClassMoveArrow();
            if (path.Length > 3)
            {
                path = path.Replace(path.Split("\\").Last(), "");
                if (path.Length > 3)
                {
                    path = path.Remove(path.Length - 1);
                }
                Program.path = path;
            }
            else if (path.Length <= 3)
            {
                Console.Clear();
                Program.Drivers(arrow, directories);
            }
            Draw(path, arrow, directories);
            moveArrow.Move(arrow, directories);
        }

        private static void Draw(string path, ClassArrow arrow, List<string> directories) 
        {
            Console.Clear();
            Program.Header();
            ClassSearch.ScanDirectory(path, directories);
            arrow.max = directories.Count + 1;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(path);
            arrow.y = 3;
        }
    }
}

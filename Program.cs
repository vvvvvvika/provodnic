using System;

namespace Provodnik
{
    internal class Program
    {
        static private string name = "Проводник";
        static public string path = "";
        static void Main(string[] args)
        {
            List<string> directories = new();
            ClassArrow arrow = new ClassArrow();

            Drivers(arrow, directories);

            ClassMoveArrow moveArrow = new ClassMoveArrow();
            while (true)
            {
                moveArrow.Move(arrow, directories);
                if (ClassMoveArrow.action == 1)
                {
                    ClassActions.Enter(path, arrow, directories);
                    ClassMoveArrow.action = 0;
                }
                else if (ClassMoveArrow.action == -1)
                {
                    ClassActions.Escape(path, arrow, directories);
                    ClassMoveArrow.action = 0;
                }
            }

        }

        static public void Drivers(ClassArrow arrow, List<string> directories)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length, 0);
            Console.WriteLine(name);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo disk in allDrives)
            {
                if (disk.IsReady == true)
                {
                    Console.WriteLine($"  {disk.Name} Свободно {Convert.ToDouble(disk.TotalFreeSpace / 1024 / 1024 / 1024)} GB " +
                        $"из {Convert.ToDouble(disk.TotalSize / 1024 / 1024 / 1024)} GB");
                    directories.Add(disk.Name);
                }
            }
            arrow.y = 3;

            Console.SetCursorPosition(0, arrow.y);
            Console.WriteLine(arrow.arrow);
            arrow.max = allDrives.Length + 1;
        }
        static public void Header()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length, 0);
            Console.WriteLine(name);
            Console.WriteLine("\tНазвание\t\t\t\tДата создания\t\tТип");
        }

    }
}
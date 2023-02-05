using System.Diagnostics;

namespace Provodnik
{
    internal class ClassSearch
    {
        public static void ScanDirectory(string path, List<string> directories)
        {
            if (path.Contains("."))
            {
                var proc = new Process();
                proc.StartInfo.FileName = path;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            else
            {
                directories.Clear();
                int i = 2;
                foreach (string direct in Directory.GetDirectories(path))
                {
                    Print(direct, i);
                    i++;
                    directories.Add(direct);
                }
                foreach (string direct in Directory.GetFiles(path))
                {
                    Print(direct, i);
                    i++;
                    directories.Add(direct);
                }
                if (directories.Count == 0)
                {
                    Console.WriteLine("Папка пуста...");
                }
            }
        }

        static private void Print(string direct, int i)
        {
            Console.SetCursorPosition(2, i);
            Console.WriteLine(Path.GetFileName(direct));
            Console.SetCursorPosition(45, i);
            Console.WriteLine(File.GetCreationTime(direct));
            Console.SetCursorPosition(72, i);
            Console.WriteLine(Path.GetExtension(direct));
        }
    }
}

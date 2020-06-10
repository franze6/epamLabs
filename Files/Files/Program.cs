using System;
using System.IO;
using System.Text;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var allText = File.ReadAllLines("text.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter("text.txt"))
                {
                    foreach (var num in allText)
                    {
                        sw.WriteLine(Math.Pow(int.Parse(num), 2));
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
            string text = "";
            string path = @"C:\temp";
            Directory.CreateDirectory(Path.Combine(path, "K1"));
            WriteFile(Path.Combine(path, "K1", "t1.txt"), "Какойтов Какойт Какойтович, 999 года рождения, место жительства Материк", false);
            WriteFile(Path.Combine(path, "K1", "t2.txt"), "Качков Арнольд Олимпович, 2099 года рождения, место жительства г. Воскресенск", false);
            Directory.CreateDirectory(Path.Combine(path, "K2"));
            text = ReadAllFile(Path.Combine(path, "K1", "t1.txt"));
            WriteFile(Path.Combine(path, "K2", "t3.txt"), text, false);
            text = ReadAllFile(Path.Combine(path, "K1", "t2.txt"));
            WriteFile(Path.Combine(path, "K2", "t3.txt"), text, true);
            AllInfoAboutFile(Path.Combine(path, "K1", "t1.txt"));
            AllInfoAboutFile(Path.Combine(path, "K1", "t2.txt"));
            AllInfoAboutFile(Path.Combine(path, "K2", "t3.txt"));
            try
            {
                if (!File.Exists(Path.Combine(path, "K2", "t2.txt")) && File.Exists(Path.Combine(path, "K1", "t2.txt")))
                    File.Move(Path.Combine(path, "K1", "t2.txt"), Path.Combine(path, "K2", "t2.txt"));
                if (!File.Exists(Path.Combine(path, "K2", "t1.txt")) && File.Exists(Path.Combine(path, "K1", "t1.txt")))
                    File.Copy(Path.Combine(path, "K1", "t1.txt"), Path.Combine(path, "K2", "t1.txt"));
                Directory.Move(Path.Combine(path, "K2"), Path.Combine(path, "All"));
                Directory.Delete(Path.Combine(path, "K1"), true);
            }
            catch (Exception e)
            {
                DisplayError(e.Message);
            }
            foreach (var file in Directory.EnumerateFiles(Path.Combine(path, "All")))
            {
                AllInfoAboutFile(file);
            }


            Console.ReadKey();

        }
        public static void WriteFile(string filepath, string message, bool append)
        {
            using (StreamWriter sw = new StreamWriter(filepath, append, Encoding.UTF8))
            {
                sw.WriteLine(message);
            }
        }
        public static string ReadAllFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
        public static void AllInfoAboutFile(string path)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                FileInfo fileInfo = new FileInfo(path);
                Console.WriteLine("/ " + fileInfo.FullName);
                Console.WriteLine("| Атрибуты: " + fileInfo.Attributes);
                Console.WriteLine("| Размер: " + fileInfo.Length + " байт");
                Console.WriteLine(@"\ Создано: " + fileInfo.CreationTime);
                Console.WriteLine("----------");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                DisplayError(e.Message);
            }

        }
        public static void DisplayError(string exeption)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exeption);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

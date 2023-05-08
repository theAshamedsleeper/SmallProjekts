using System;
using System.IO;

namespace CreatingAFile
{
    internal class Program
    {
        private static bool closeProg = false;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Do you want to make a file or delete a file." +
                "\nWrite: 1.    Delete: 2.      ReadFile: 3      Close Prog: 4.");
                string which = Console.ReadLine();
                switch (which)
                {
                    case "1":
                        MakeFile();
                        break;
                    case "2":
                        DeleFile();
                        break;
                    case "3":
                        ReadFile();
                        break;
                    case "4":
                        closeProg = true;
                        break;
                }
            } while (closeProg == false); ;
        }
        private static void MakeFile()
        {
            #region MakeFile
            try
            {
                Console.WriteLine("You want to creat a .txt write the name of the file\n" +
                    "------------------------------------------");
                string fileName = Console.ReadLine();
                fileName = fileName + ".txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (FileStream fs = File.Create(fileName))
                {
                    Console.WriteLine($"A file with the name {fileName} has been made");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Do you want to want to write some text in the file" +
                    "\nYes: 1.      No: 2.");
                string question = Console.ReadLine();
                switch (question)
                {
                    case "1":
                        using (StreamWriter SW = File.CreateText(fileName))
                        {
                            SW.Write(Console.ReadLine());
                        }
                        break;
                    case "2":
                        break;

                }

            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
            #endregion
        }
        private static void DeleFile()
        {
            #region Delete File
            try
            {
                Console.WriteLine("Type the name of the .txt file you want to delete.\n" +
                    "------------------------------------------");
                string fileName = Console.ReadLine();
                fileName = fileName + ".txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    Console.WriteLine($"A file with the name {fileName} has been removed");
                }
                else
                {
                    Console.WriteLine("File could not be found");
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
            #endregion
        }
        private static void ReadFile()
        {
            #region Reads a .txt file
            Console.WriteLine("Write the name of the file you want to read the content of");
            string fileName = Console.ReadLine() + ".txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                Console.WriteLine("------------------------------------");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine("\n" + s + "\n");
                }


            }
            #endregion
        }
    }
}

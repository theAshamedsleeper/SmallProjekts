using System;

namespace palindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a palindrome checker. \nyou have to write a palindrome" +
                "A palindrome is a word, phrase, number, or other sequence of \ncharacters that reads the same forward and backward." +
                "\nNow write a palindrome!" +
                "\n--------------------------------------------------------------------");
            string pali = Console.ReadLine().ToLower();
            int i = 0;
            char[] name = new char[pali.Length];

            foreach (char c in pali)
            {
                if (name[i] != ' ')
                {
                    i++;
                    continue;
                }
                else
                {
                    name[i] = c;
                    i++;
                }
            }





            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }
    }
}

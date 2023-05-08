using System;
using System.Collections.Generic;

namespace palindromeChecker
{
    internal class Program
    {
        private static string orginalWord;
        private static string reversWord;
        private static bool haveComplet = false;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("This is a palindrome checker. \nyou have to write a palindrome" +
                    "A palindrome is a word, phrase, number, or other sequence of \ncharacters that reads the same forward and backward." +
                    "\nNow write a palindrome!" +
                    "\n--------------------------------------------------------------------");
                string pali = Console.ReadLine().ToLower();
                int i = 0;
                List<char> name = new List<char>();
                char[] cc = new char[pali.Length];
                bool isSym = false;
                bool isPun = false;
                //Removes all the unnecessary stuff from the word
                foreach (char c in pali)
                {

                    cc[i] = c;
                    if (cc[i] != ' ')
                    {
                        if (char.IsSymbol(cc[i]))
                        {
                            isSym = true;
                            i++;
                        }
                        else if (char.IsPunctuation(cc[i]))
                        {
                            isPun = true;
                            i++;
                        }
                        if (isSym == false && isPun == false)
                        {
                            name.Add(c);
                            i++;
                            isSym = false;
                            isPun = false;
                        }
                        isSym = false;
                        isPun = false;
                    }
                    else { i++; }
                }
                //Console.WriteLine(string.Concat(name));

                orginalWord = string.Concat(name);
                int b = orginalWord.Length;
                char[] bb = new char[b];
                foreach (char ch in orginalWord)
                {
                    b--;
                    bb[b] = ch;
                }
                //Console.WriteLine(string.Concat(bb));

                reversWord = string.Concat(bb);

                if (reversWord.Equals(orginalWord))
                {
                    Console.WriteLine("\nYOU DID IT !!!!!!\nVery good job.");
                    haveComplet = true;
                }
                else
                {
                    Console.WriteLine("\nI am sorry, but it is not an palindrome try again.\nPress enter to try again");
                    Console.ReadLine();
                }
            }
            while (!haveComplet);
            Console.WriteLine("--------------------------------------------------------------------\nPress enter to close");
            Console.ReadLine();
        }
    }
}

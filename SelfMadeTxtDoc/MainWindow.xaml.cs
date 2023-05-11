using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace SelfMadeTxtDoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //max length of a string is 2.147.483.648 or 2^31
        private List<string> wordAmount = new List<string>();
        private string words;
        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            words = InputField.Text;
            wordAmount.Add(words);
            CharactersCount.Text = "Characters: " + words.Count();
        }
        private void SearchForWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchWord = SearchForWord.Text;
            searchWordList.Add(searchWord);
            //string[] word = words.Split(' ');

            
            //foreach (string s in word)
            //{
            //    if (string.Compare(s, searchWord, StringComparison.OrdinalIgnoreCase) == 0)
            //    {
            //        int index n
            //        InputField.SelectAll();
            //    }
            //    else
            //    {

            //    }
            //}
        }
        private void SearchDocBut_Click(object sender, RoutedEventArgs e)
        {
            int index = words.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase);

            while (index >= 0)
            {
                InputField.Select(index, searchWord.Length);

                index = words.IndexOf(searchWord, index + searchWord.Length, StringComparison.OrdinalIgnoreCase);

            }
        }
        private void SaveDocBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog.Title = "Save Text File";
                saveFileDialog.ShowDialog();

                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    File.WriteAllText(saveFileDialog.FileName, words);
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        private void NewDocBut_Click(object sender, RoutedEventArgs e)
        {
            string w = "";
            words = w;
            InputField.Text = words;
            wordAmount.Clear();

        }

        private void OpenDocBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Open Text File";
                openFileDialog.ShowDialog();

                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    string filePath = openFileDialog.FileName;
                    words = File.ReadAllText(filePath);
                    InputField.Text = words;

                }
            }
            catch (Exception MyExcep)
            {

                Console.WriteLine(MyExcep.ToString());
            }
        }
        private string searchWord;
        private List<string>searchWordList = new List<string>();

        
    }
}

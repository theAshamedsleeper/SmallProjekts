using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            string w ="";
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
    }
}

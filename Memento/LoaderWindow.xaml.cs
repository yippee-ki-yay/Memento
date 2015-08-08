using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Memento
{
    /// <summary>
    /// A window for seting the path of the Q/A file and picking a format for your text
    /// </summary>
    public partial class LoaderWindow : Window
    {
        private QuestionManager qm;
        private string filePath;

        public LoaderWindow(QuestionManager manager)
        {
            InitializeComponent();
            this.qm = manager;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            filePath = qm.openQuestions();
            fileText.Text = filePath;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            //we check if the file path is valid and depending on the format chosen we parse the file
            if(filePath != "")
            {
                if(qaCheck.IsChecked.Value)
                    if(qm.parseOriginal(filePath))
                     {
                        this.Close();
                     }
                     else
                     {
                         Console.WriteLine(filePath + " failed to parse with original formating");
                     }

                if (standardCheck.IsChecked.Value)
                    if (qm.parseStandard(filePath))
                    {
                        this.Close();
                    }
                    else
                    {
                        Console.WriteLine(filePath + " failed to parse with standard formating");
                    }
            }
        }
    }
}

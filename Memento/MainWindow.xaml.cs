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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuestionManager qm;
        private Tuple<string, string> curr;

        public MainWindow()
        {
            InitializeComponent();
            nextButton.IsEnabled = false;
            showButton.IsEnabled = false;
  
            qm = new QuestionManager();

        }

        private void NextQa_Click(object sender, RoutedEventArgs e)
        {
            curr = qm.getSequentail();
            
            pitanjeText.Text = curr.Item1;
            odogovorText.Text = "";
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            odogovorText.Text = curr.Item2;
        }

        private void Loader_Click(object sender, RoutedEventArgs e)
        {
            LoaderWindow loaderWindow = new LoaderWindow(qm);
            loaderWindow.ShowDialog();
            nextButton.IsEnabled = true;
            showButton.IsEnabled = true;
            curr = qm.getSequentail();
            pitanjeText.Text = curr.Item1;
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

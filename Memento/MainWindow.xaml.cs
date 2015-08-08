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
        QuestionManager qm;
        BesaParser bp;
        Boolean nenad_pars;
        Boolean besa_pars;
        Tuple<string, string> curr;

        public MainWindow()
        {
            InitializeComponent();
            nextButton.IsEnabled = false;
            showButton.IsEnabled = false;
            //two ways of parsing files
            nenad_pars = false;
            besa_pars = false;
            bp = new BesaParser();
            qm = new QuestionManager();
            /*
            qm.loadFile("wut");
            curr = qm.getRandom();
            pitanjeText.Text = curr.Item1;*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(nenad_pars)
                curr = qm.getRandom();
            if(besa_pars)
                curr = bp.getRandom();
            
            pitanjeText.Text = curr.Item1;
            odogovorText.Text = "";
           
        }

        
        
        private void besaParse_Click(object sender, RoutedEventArgs e)
        {
            if (!bp.parseFile())
                return;

            besa_pars = true;
            nextButton.IsEnabled = true;
            showButton.IsEnabled = true;

            curr = bp.getRandom();
            pitanjeText.Text = curr.Item1;
        }

        private void nenadParse_Click(object sender, RoutedEventArgs e) {

            if (!qm.loadFile(1))
                qm.loadFile(1);

            nenad_pars = true;
            nextButton.IsEnabled = true;
            showButton.IsEnabled = true;
          
            curr = qm.getRandom();
            pitanjeText.Text = curr.Item1;

        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            odogovorText.Text = curr.Item2;
        }

        private void Loader_Click(object sender, RoutedEventArgs e)
        {
            LoaderWindow loaderWindow = new LoaderWindow();
            loaderWindow.ShowDialog();
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

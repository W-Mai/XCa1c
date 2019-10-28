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

namespace Clac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private string NowOperator = "";
        private int Result = 0;
        public MainWindow() {
            InitializeComponent();
        }

        private void BtNumberClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            ContentBox.Text += button.Content;
        }

        private void BtOpClick(object sender, RoutedEventArgs e) {

        }

        private void BtClearClick(object sender, RoutedEventArgs e) {

        }

    }
}

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

    public partial class MainWindow : Window {
        private const string NOOPERATOR = "NULL";
        private string ContenOfInputVal = "0";
        private string NowOperatorVal = NOOPERATOR;
        private double Result = 0.0f;
        private List<string> OPList= new List<string>{ "btPlus", "btMinus", "btMultiply", "btDivide" };

        public string ContentOfInput {
            get => ContenOfInputVal; set {
                ContenOfInputVal = value;
                ContentBox.Text = value;
            }
        }

        public string NowOperator { get => NowOperatorVal; set { NowOperatorVal = value; ShowOperator(value); } }

        public MainWindow() {
            InitializeComponent();
            reset();
        }

        private void reset() {
            ContentOfInput = "0";
            NowOperator = (string)btPlus.Content;
            Result = 0.0f;
        }

        private void BtNumberClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            if(NowOperator != NOOPERATOR) {
                if(button.Name != "btDot" && ContentOfInput == "0")
                    ContentOfInput = "";
                ContentOfInput += button.Content;
            }
                

        }

        private void BtOpClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            
            if(OPList.Exists(exist=>exist == button.Name)){
                NowOperator = (string)button.Content;
            }
        }

        // Finished.
        private void BtClearClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            switch (button.Name) {
                case "btClear":
                    reset();
                    break;
                case "btBack":
                    if (ContentOfInput.Length == 1) { ContentOfInput = "0"; break; };
                    ContentOfInput = ContentOfInput.Substring(0, ContentOfInput.Length - 1);
                    break;
            }
        }

        //Finished.
        private void ShowOperator(string op) {
            OpShow.Content = op;
        }
    }
}

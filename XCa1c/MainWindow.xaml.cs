using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Clac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private const string ERRORMSG = "ERROR";
        private const string NOOPERATOR = "NULL";

        private string ContentOfInputVal = "0";
        private string NowOperatorVal = NOOPERATOR;
        private double Result = 0.0f;
        private bool ERRORINFO = false;
        private bool NEEDCLEAR = true;

        private readonly List<string> OPList = new List<string> { "btPlus", "btMinus", "btMultiply", "btDivide" };

        public string ContentOfInput { get => ContentOfInputVal;
            set {
                ContentOfInputVal = value;
                ContentBox.Text = value;

                if (ContentBox.Text.Length >= 10)
                    ContentBox.FontSize = 30;
                else if (ContentBox.Text.Length<=10)ContentBox.FontSize = 60;
            }
        }

        public string NowOperator { get => NowOperatorVal; set { NowOperatorVal = value; ShowOperator(value); } }

        //Finished.
        public MainWindow() {
            InitializeComponent();
            reset();
        }

        //Finished.
        private void reset() {
            ContentOfInput = "0";
            NowOperator = (string)btPlus.Content;
            Result = 0.0f;
            ERRORINFO = false;
            NEEDCLEAR = true;
        }

        //Finished.
        private void BtNumberClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            if (!ERRORINFO && NowOperator != NOOPERATOR) {
                if (NEEDCLEAR) {
                    ContentOfInput = "0";
                    NEEDCLEAR = false;
                }
                if (button.Name != "btDot" && ContentOfInput == "0")
                    ContentOfInput = "";
                ContentOfInput += button.Content;
            }
        }

        //Finished.
        private void BtOpClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            if (ERRORINFO) return; try {
                if (OPList.Exists(exist => exist == button.Name)) {
                    Result = EvalExpr(Result.ToString(), NowOperator, ContentOfInput);
                    ContentOfInput = ERRORINFO ? ERRORMSG : Result.ToString();
                    NowOperator = (string)button.Content;
                } else if (button.Name == "btEqual") {
                    double result = EvalExpr(Result.ToString(), NowOperator, ContentOfInput);
                    reset();
                    ContentOfInput = ERRORINFO ? ERRORMSG : result.ToString();
                } else if (button.Name == "btInverse") {
                    ContentOfInput = (-Convert.ToDouble(ContentOfInput)).ToString();
                }
            } catch {
                ERRORINFO = true;
                ContentOfInput = ERRORMSG;
            }
            NEEDCLEAR = true;
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
                    ContentOfInput = ContentOfInput[0..^1];
                    break;
            }
        }

        //Finished.
        private void ShowOperator(string op) {
            OpShow.Content = op;
        }

        //Finished.
        private double EvalExpr(string a, string op, string b) {
            double dA = Convert.ToDouble(a), dB = Convert.ToDouble(b);
            switch (op) {
                case "＋":
                    return dA + dB;
                case "－":
                    return dA - dB;
                case "×":
                    Console.WriteLine("Fuck");
                    return dA * dB;
                case "÷":
                    if (Math.Abs(dB - 0) < 1e-10) ERRORINFO = true;
                    return dA / dB;
            }
            ERRORINFO = true;
            return 0.0f;
        }


     

        private void InputViewChanged(object sender, System.Windows.Data.DataTransferEventArgs e) {
            TextBlock textBlock = (TextBlock)sender;
            
            MessageBox.Show("");
        }
    }
}

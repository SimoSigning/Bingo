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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> BingoNumberList = new List<int>();
        List<int> BingoPladeNumberList = new List<int>();
        List<int> BingoPladeMarkedList = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            if(BingoNumberList.Count < 100)
            {
                Random ranGen = new Random();
                bool AlreadyHasNumber = true;
                int GeneratedNumber;
                do
                {
                    GeneratedNumber = ranGen.Next(0, 100);
                    if(!BingoNumberList.Contains(GeneratedNumber))
                    {
                        AlreadyHasNumber = false;
                    }
                }
                while (AlreadyHasNumber == true);
                BingoNumberList.Add(GeneratedNumber);
                NumberList.Items.Clear();
                for (int i = 0; i < BingoNumberList.Count; i++)
                {
                    NumberList.Items.Add(BingoNumberList[i]);
                }
            }
            else
            {
                InfoLabel.Content = "Du har genereret antal tilladte tal og der burde være blevet bingo.";
            }
            TestLabel.Content = BingoNumberList.Count;
        }

        private void GenererPlade_Click(object sender, RoutedEventArgs e)
        {
            BingoPladeNumberList.Clear();
            Random ranGen = new Random();
            List<Button> Btns = new List<Button>() {Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9, Btn10,  Btn11, Btn12, Btn13, Btn14, Btn15, Btn16, Btn17, Btn18 };
            int incrementer = 0;
            while(incrementer < Btns.Count)
            {
                int RanNumber = ranGen.Next(0, 100);
                BingoPladeNumberList.Add(RanNumber);
                Btns[incrementer].Content = RanNumber;
                incrementer++;
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            BingoPladeMarkedList.Add(int.Parse(Btn1.Content.ToString()));
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn18_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

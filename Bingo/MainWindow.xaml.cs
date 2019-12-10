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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            if(BingoNumberList.Count < 10)
            {
            Random ranGen = new Random();
            bool AlreadyHasNumber = true;
            int GeneratedNumber = 0;
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
    }
}

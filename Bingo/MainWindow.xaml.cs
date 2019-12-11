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
        bool HasGeneratedPlade = false;
        bool HarIkkeBingo = false;
        bool HasMarkedANumber = false;
        bool HasGeneratedANumber = false;
        bool Bingo = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            if(HasGeneratedPlade == true)
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
                    HasGeneratedANumber = true;
                    NumberList.Items.Clear();
                    for (int i = 0; i < BingoNumberList.Count; i++)
                    {
                        NumberList.Items.Add(BingoNumberList[BingoNumberList.Count-1-i]);
                    }
                }
                else
                {
                    InfoLabel.Content = "Du har genereret antal tilladte tal og der burde være blevet bingo.";
                }
                TestLabel.Content = BingoNumberList.Count;
            }
            else
            {
                InfoLabel.Content = "Generer en plade først";
            }
        }
        private void GenererPlade_Click(object sender, RoutedEventArgs e)
        {
            if(HasGeneratedPlade == false && Bingo == true)
            {
                Bingo = false;
                BingoPladeNumberList.Clear();
                HasGeneratedPlade = true;
                ResetColors();
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
            else
            {
                InfoLabel.Content = "Du har allerede genereret en plade. Få bingo først.";
            }

        }
        private void BingoBtn_Click(object sender, RoutedEventArgs e)
        {
            if(HasMarkedANumber == true && HasGeneratedPlade == true && HasGeneratedANumber == true)
            {
                for (int i = 0; i < BingoPladeMarkedList.Count; i++)
                {
                    if(!BingoNumberList.Contains(BingoPladeMarkedList[i]))
                    {
                        HarIkkeBingo = true;
                        break;
                    }
                }
                if(HarIkkeBingo == true)
                {
                    InfoLabel.Content = "Du har ikke bingo";
                    HarIkkeBingo = false;
                }
                else
                {
                    InfoLabel.Content = "Tillykke, du har intet vundet";
                    Bingo = true;
                }
            }
            else
            {
                InfoLabel.Content = "Du kan kun have bingo hvis du faktisk spiller spillet";
            }
        }
        private void ResetColors()
        {
            Btn1.Background = Brushes.Gray;
            Btn2.Background = Brushes.Gray;
            Btn3.Background = Brushes.Gray;
            Btn4.Background = Brushes.Gray;
            Btn5.Background = Brushes.Gray;
            Btn6.Background = Brushes.Gray;
            Btn7.Background = Brushes.Gray;
            Btn8.Background = Brushes.Gray;
            Btn9.Background = Brushes.Gray;
            Btn10.Background = Brushes.Gray;
            Btn11.Background = Brushes.Gray;
            Btn12.Background = Brushes.Gray;
            Btn13.Background = Brushes.Gray;
            Btn14.Background = Brushes.Gray;
            Btn15.Background = Brushes.Gray;
            Btn16.Background = Brushes.Gray;
            Btn17.Background = Brushes.Gray;
            Btn18.Background = Brushes.Gray;
        }
        //vi skal i høj grad finde en måde at gøre det smartere på m.h.t at lave bingoplade med buttons.
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if(HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn1.Content.ToString()));
                Btn1.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn2.Content.ToString()));
                Btn2.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn3.Content.ToString()));
                Btn3.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn4.Content.ToString()));
                Btn4.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn5.Content.ToString()));
                Btn5.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn6.Content.ToString()));
                Btn6.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn7.Content.ToString()));
                Btn7.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn8.Content.ToString()));
                Btn8.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn9.Content.ToString()));
                Btn9.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn10.Content.ToString()));
                Btn10.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn11_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn11.Content.ToString()));
                Btn11.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn12.Content.ToString()));
                Btn12.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn13_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn13.Content.ToString()));
                Btn13.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn14_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn14.Content.ToString()));
                Btn14.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn15_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn15.Content.ToString()));
                Btn15.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn16_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn16.Content.ToString()));
                Btn16.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn17_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn17.Content.ToString()));
                Btn17.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn18_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                BingoPladeMarkedList.Add(int.Parse(Btn18.Content.ToString()));
                Btn18.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
    }
}

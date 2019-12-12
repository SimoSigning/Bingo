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
        List<bool> BingoPladeMarkedList = new List<bool>();
        List<int> BingoPladeMarkedNumberList = new List<int>();
        bool HasGeneratedPlade = false;
        bool HarIkkeBingo = false;
        bool HasMarkedANumber = false;
        bool HasGeneratedANumber = false;
        bool Bingo = false;
        bool[] IsPushed = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
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
            if(HasGeneratedPlade == false || Bingo == true)
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
                    BingoPladeMarkedList.Add(false);
                    Btns[incrementer].Content = RanNumber;
                    incrementer++;
                    /*Det er her alle tal der ligger på pladen sættes ind. Muligvis skal man også lave knap association her. Det kan gøres via multidimensionel array eller bare 2 arrays.
                     fordi den looper knapperne kronologisk og tallene loades ind i samme kronologiske rækkefølge, vil knap og tal følges ad i et loop.
                     Det betyder at når man laver en ændring i et index fundet i et array, kan man lave en ændring på et index der er svarende til i det andet array.*/
                }
            }
            else
            {
                InfoLabel.Content = "Du har allerede genereret en plade. Få bingo først.";
            }

        }
        private void BingoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HasMarkedANumber == true && HasGeneratedPlade == true && HasGeneratedANumber == true && BingoPladeNumberList.Count == BingoPladeMarkedList.Count)
            {
      /*          for (int i = 0; i < BingoPladeMarkedList.Count; i++)
                {
                    if(!BingoNumberList.Contains(BingoPladeMarkedList[i]))
                    {
                        HarIkkeBingo = true;
                        break;
                    }
                }*/
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
        //Endnu et eksempel på dette kommer med at kunne fjerne markering. Det kan meget simpelt gøres med en boolean men det bliver 18 bools o_O.
        /*
         Eventuelt kan man lave en klasse som har properties for hver knap der fortæller om knappen er marked eller ej.

            funktionaliteten er at når en knap er marked, er knappens værdi i markedlist listen når den ikke er marked skal den ikke være i listen.
            Hvis et tal eksistere på flere knapper, så vil arrayet være fyldt med flere af samme tal, så når man fjerner dette tal fra arrayet vil det
            ikke kun være tallet der tilhøre knappen men det ene tal der er på alle knapper.
            Den skal kunne opfatte hvilken knap tallet der skal fjernes er associeret med.
             */
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if(HasGeneratedPlade == true)
            {
                
                if(IsPushed[0] == false)
                {
                    IsPushed[0] = true;
                    Btn1.Background = Brushes.Green;
                }
                else
                {
                    IsPushed[0] = false;
                    Btn1.Background = Brushes.Gray;
                    //følgende fremgangsmåde vil dog kun virke hvis alle tal er unikke og ikke kan gentages.
                }
                HasMarkedANumber = true;
            }
        }
        /*    
         int VareAntal = int.Parse(AntalOrdre.Text);
            object[] VarerDescObjects = new object[VareAntal];
            object[] VarerAntalObject = new object[VareAntal];
            string[] getAllVareDescriptions = new string[VareAntal];
            int[] getAllVareAntal = new int[VareAntal];
            for (int i = 0; i < VarerDescObjects.Length; i++)
            {
                string CurrVare = "Varer0" + i.ToString();
                string CurrAntal = "Antal0" + i.ToString();
                VarerDescObjects[i] = this.FindName(CurrVare);
                VarerAntalObject[i] = this.FindName(CurrAntal);
                if(VarerDescObjects[i].GetType() == typeof(TextBox))
                {
                    getAllVareDescriptions[i] = ((TextBox)VarerDescObjects[i]).Text;
                }
                if(VarerAntalObject[i].GetType() == typeof(TextBox))
                {
                    try
                    {
                        getAllVareAntal[i] = int.Parse(((TextBox)VarerAntalObject[i]).Text);
                    }
                    catch
                    {
                        IndtastVareErrorLabel.Content = "Antal kan kun være heltal";
                    }
                }
            } 
        */
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn2.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn3.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn4.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn5.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn6.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn7.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn8.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn9.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn10.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn11_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn11.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn12.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn13_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn13.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn14_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn14.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn15_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn15.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn16_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn16.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn17_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn17.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
        private void Btn18_Click(object sender, RoutedEventArgs e)
        {
            if (HasGeneratedPlade == true)
            {
                Btn18.Background = Brushes.Green;
                HasMarkedANumber = true;
            }
        }
    }
}

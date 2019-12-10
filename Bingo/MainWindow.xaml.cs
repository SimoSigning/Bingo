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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void NumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            Random ranGen = new Random();
            bool AlreadyHasNumber = true;
            int GeneratedNumber = 0;
            do
            {
                GeneratedNumber = ranGen.Next(0, 10);
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
    }
}

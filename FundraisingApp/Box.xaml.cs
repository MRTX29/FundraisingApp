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

namespace FundraisingApp
{
    /// <summary>
    /// Interaction logic for Box.xaml
    /// </summary>
    public partial class Box : Page
    {
        public Box()
        {
            InitializeComponent();
        }



        private void OnObliczClicked(object sender, RoutedEventArgs e)
        {
            int val500 = GetValueFromTextBox(value500);
            int val200 = GetValueFromTextBox(value200);
            int val100 = GetValueFromTextBox(value100);
            int val50 = GetValueFromTextBox(value50);
            int val20 = GetValueFromTextBox(value20);
            int val10 = GetValueFromTextBox(value10);
            int val5 = GetValueFromTextBox(value5);
            int val2 = GetValueFromTextBox(value2);
            int val1 = GetValueFromTextBox(value1);
            int val50gr = GetValueFromTextBox(value50gr);
            int val20gr = GetValueFromTextBox(value20gr);
            int val10gr = GetValueFromTextBox(value10gr);
            int val5gr = GetValueFromTextBox(value5gr);
            int val2gr = GetValueFromTextBox(value2gr);
            int val1gr = GetValueFromTextBox(value1gr);

            decimal totalSum = (500 * val500) + (200 * val200) + (100 * val100) + (50 * val50) +
                               (20 * val20) + (10 * val10) + (5 * val5) + (2 * val2) + (1 * val1) +
                               (0.5m * val50gr) + (0.2m * val20gr) + (0.1m * val10gr) + (0.05m * val5gr) +
                               (0.02m * val2gr) + (0.01m * val1gr);

            valueTotalSum.Text = $"Suma: {totalSum} zł";
        }

        private int GetValueFromTextBox(TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}

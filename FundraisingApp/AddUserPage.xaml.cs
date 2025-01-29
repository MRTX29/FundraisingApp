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
    /// Logika interakcji dla klasy AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = UsernameTextBox.Text;
            string Password = PasswordBox.Password;
            string Role;
            if (PersonCollectingMoney.IsChecked == true)
            {
                Role = "Osoba kwestująca";
            }
            else if (PersonCountingMoney.IsChecked == true)
            {
                Role = "Osoba podliczająca";
            }

        }

    }
}

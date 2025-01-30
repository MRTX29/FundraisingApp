using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace FundraisingApp
{
    public partial class AddUserPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly IUserService _userService;
        private readonly User _currentUser;

        public AddUserPage(MainWindow mainWindow, User currentUser)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _currentUser = currentUser;

            _userService = App.Services!.GetRequiredService<IUserService>();
        }

        private void NavigateToMainDashboard_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new MainDashboardPage(_mainWindow, _currentUser));
        }

        private async void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string login = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            UserRole role;
            if (PersonCollectingMoney.IsChecked == true)
            {
                role = UserRole.Collector;
            }
            else if (PersonCountingMoney.IsChecked == true)
            {
                role = UserRole.Counter;
            }
            else
            {
                role = UserRole.Collector;
            }

            try
            {
                var newUser = await _userService.CreateUserAsync(login, password, role);
                MessageBox.Show($"Użytkownik '{newUser.Username}' dodany pomyślnie!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd tworzenia użytkownika: {ex.Message}");
            }
        }
    }
}

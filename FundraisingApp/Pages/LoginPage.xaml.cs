using FundraisingAppProcessor.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace FundraisingApp
{
    public partial class LoginPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly IUserService _userService;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            _userService = App.Services!.GetRequiredService<IUserService>();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            var user = await _userService.ValidateUserAsync(username, password);
            if (user == null)
            {
                MessageBox.Show("Niepoprawne dane logowania!");
                return;
            }

            _mainWindow.SetLoggedInUser(user);
        }
    }
}
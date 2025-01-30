using FundraisingAppProcessor.Models;
using System.Windows;

namespace FundraisingApp
{
    public partial class MainWindow : Window
    {
        private User? _loggedInUser;

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage(this));
        }

        public void SetLoggedInUser(User user)
        {
            _loggedInUser = user;

            LogoutButton.Visibility = Visibility.Visible;

            UserRoleText.Text = $"Zalogowany jako: {user.Username} ({user.Role})";

            MainFrame.Navigate(new MainDashboardPage(this, user));
        }

        public void PerformLogout()
        {
            _loggedInUser = null;
            LogoutButton.Visibility = Visibility.Collapsed;
            UserRoleText.Text = string.Empty;

            MainFrame.Navigate(new LoginPage(this));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            PerformLogout();
        }
    }
}

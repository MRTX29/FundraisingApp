using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FundraisingApp
{
    public partial class MainDashboardPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly IMoneyBoxService _moneyBoxService;

        private User _loggedInUser;

        // For admin
        public ObservableCollection<MoneyBoxDisplay> AdminBoxes { get; set; }
            = new ObservableCollection<MoneyBoxDisplay>();

        // For counter
        public ObservableCollection<MoneyBoxDisplay> CounterBoxes { get; set; }
            = new ObservableCollection<MoneyBoxDisplay>();

        public MainDashboardPage(MainWindow mainWindow, User user)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _loggedInUser = user;

            _moneyBoxService = App.Services!.GetRequiredService<IMoneyBoxService>();

            DataContext = this;

            // Show the correct section for the role
            AdminSection.Visibility = Visibility.Collapsed;
            CollectorSection.Visibility = Visibility.Collapsed;
            CounterSection.Visibility = Visibility.Collapsed;

            switch (user.Role)
            {
                case UserRole.Admin:
                    AdminSection.Visibility = Visibility.Visible;
                    LoadBoxesAsync();
                    break;
                case UserRole.Collector:
                    CollectorSection.Visibility = Visibility.Visible;
                    break;
                case UserRole.Counter:
                    CounterSection.Visibility = Visibility.Visible;
                    LoadCounterBoxesAsync();
                    break;
            }
        }

        private async void LoadBoxesAsync()
        {
            AdminBoxes.Clear();
            var list = await _moneyBoxService.GetAllMoneyBoxesAsync();

            foreach (var box in list)
            {
                var display = new MoneyBoxDisplay
                {
                    Id = box.Id,
                    Name = "Puszka " + box.Id,
                    DateReturnedText = box.DateReturned?.ToString("dd.MM.yyyy HH:mm") ?? "—",

                    ButtonText = box.ApprovedByAdmin ? "Zatwierdzono" : "Zatwierdź",
                    IsEnabled = !box.ApprovedByAdmin
                };

                AdminBoxes.Add(display);
            }
        }

        private async void LoadCounterBoxesAsync()
        {
            CounterBoxes.Clear();
            var list = await _moneyBoxService.GetAllMoneyBoxesAsync();
            foreach (var box in list)
            {
                if (box.ApprovedByAdmin)
                {
                    CounterBoxes.Add(new MoneyBoxDisplay
                    {
                        Id = box.Id,
                        Name = "Puszka " + box.Id,
                        DateReturnedText = box.DateReturned?.ToString("dd.MM.yyyy HH:mm") ?? "—"
                    });
                }
            }
            CounterBoxesControl.ItemsSource = CounterBoxes;
        }


        private async void OnAddBoxClick(object sender, RoutedEventArgs e)
        {
            var newBox = await _moneyBoxService.CreateMoneyBoxAsync(DateTime.Now);
            MessageBox.Show($"Utworzono nową puszkę z ID={newBox.Id}");
        }

        // Admin "Zatwierdź"
        private async void OnApproveBoxClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn?.CommandParameter is int boxId)
            {
                await _moneyBoxService.ApproveMoneyBoxAsync(boxId);
                MessageBox.Show($"Puszka {boxId} zatwierdzona!");
                LoadBoxesAsync();
            }
        }

        // Counter "Podlicz"
        private void OnCountBoxClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn?.CommandParameter is int boxId)
            {
                _mainWindow.MainFrame.Navigate(new Box(_mainWindow, _loggedInUser, boxId));
            }
        }

        private void OnAddUserClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new AddUserPage(_mainWindow, _loggedInUser));
        }
    }
    public class MoneyBoxDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DateReturnedText { get; set; } = string.Empty;
        public string ButtonText { get; set; } = "Zatwierdź";
        public bool IsEnabled { get; set; } = true;
    }
}

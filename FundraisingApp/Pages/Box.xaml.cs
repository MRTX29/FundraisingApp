using FundraisingAppProcessor.Services;
using FundraisingAppProcessor.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace FundraisingApp
{
    public partial class Box : Page
    {
        private readonly User _loggedUser;
        private readonly MainWindow _mainWindow;
        private readonly IMoneyBoxService _moneyBoxService;

        private int _currentBoxId;

        public Box(MainWindow mainWindow, User user, int boxId = 0)
        {
            InitializeComponent();
            _loggedUser = user;
            _mainWindow = mainWindow;
            _moneyBoxService = App.Services!.GetRequiredService<IMoneyBoxService>();
            _currentBoxId = boxId;

            // Show box ID in the title
            if (_currentBoxId > 0)
                BoxTitleText.Text = $"Puszka (ID={_currentBoxId})";
            else
                BoxTitleText.Text = "Puszka (Nowa)";

            if (_currentBoxId > 0)
            {
                LoadBoxData();
            }
        }

        private async void LoadBoxData()
        {
            var box = await _moneyBoxService.GetMoneyBoxByIdAsync(_currentBoxId);
            if (box == null)
            {
                MessageBox.Show("Box not found in DB!");
                return;
            }

            value500.Text = box.Denominations.Count500.ToString();
            value200.Text = box.Denominations.Count200.ToString();
            value100.Text = box.Denominations.Count100.ToString();
            value50.Text = box.Denominations.Count50.ToString();
            value20.Text = box.Denominations.Count20.ToString();
            value10.Text = box.Denominations.Count10.ToString();
            value5.Text = box.Denominations.Count5.ToString();
            value2.Text = box.Denominations.Count2.ToString();
            value1.Text = box.Denominations.Count1.ToString();
            value50gr.Text = box.Denominations.Count50gr.ToString();
            value20gr.Text = box.Denominations.Count20gr.ToString();
            value10gr.Text = box.Denominations.Count10gr.ToString();
            value5gr.Text = box.Denominations.Count5gr.ToString();
            value2gr.Text = box.Denominations.Count2gr.ToString();
            value1gr.Text = box.Denominations.Count1gr.ToString();
            valueOtherCurrencies.Text = box.Denominations.OtherCurrencies ?? "";

            decimal totalSum =
                500m * box.Denominations.Count500 +
                200m * box.Denominations.Count200 +
                100m * box.Denominations.Count100 +
                 50m * box.Denominations.Count50 +
                 20m * box.Denominations.Count20 +
                 10m * box.Denominations.Count10 +
                  5m * box.Denominations.Count5 +
                  2m * box.Denominations.Count2 +
                  1m * box.Denominations.Count1 +
                 0.50m * box.Denominations.Count50gr +
                 0.20m * box.Denominations.Count20gr +
                 0.10m * box.Denominations.Count10gr +
                 0.05m * box.Denominations.Count5gr +
                 0.02m * box.Denominations.Count2gr +
                 0.01m * box.Denominations.Count1gr;

            valueTotalSum.Text = $"Suma: {totalSum} zł";

            if (totalSum > 0)
            {
                DisableControls();
            }
        }

        private async void OnObliczClicked(object sender, RoutedEventArgs e)
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

            decimal totalSum =
                500m * val500 +
                200m * val200 +
                100m * val100 +
                 50m * val50 +
                 20m * val20 +
                 10m * val10 +
                  5m * val5 +
                  2m * val2 +
                  1m * val1 +
                 0.50m * val50gr +
                 0.20m * val20gr +
                 0.10m * val10gr +
                 0.05m * val5gr +
                 0.02m * val2gr +
                 0.01m * val1gr;

            valueTotalSum.Text = $"Suma: {totalSum} zł";

            if (_currentBoxId <= 0)
            {
                var newBox = await _moneyBoxService.CreateMoneyBoxAsync(System.DateTime.Now);
                _currentBoxId = newBox.Id;
            }

            var newDenominations = new Denominations
            {
                Count500 = val500,
                Count200 = val200,
                Count100 = val100,
                Count50 = val50,
                Count20 = val20,
                Count10 = val10,
                Count5 = val5,
                Count2 = val2,
                Count1 = val1,
                Count50gr = val50gr,
                Count20gr = val20gr,
                Count10gr = val10gr,
                Count5gr = val5gr,
                Count2gr = val2gr,
                Count1gr = val1gr,
                OtherCurrencies = valueOtherCurrencies.Text
            };

            await _moneyBoxService.UpdateDenominationsAsync(_currentBoxId, newDenominations);
            MessageBox.Show("Zapisano liczenie w bazie!");
        }

        private void DisableControls()
        {
            value500.IsEnabled = false;
            value200.IsEnabled = false;
            value100.IsEnabled = false;
            value50.IsEnabled = false;
            value20.IsEnabled = false;
            value10.IsEnabled = false;
            value5.IsEnabled = false;
            value2.IsEnabled = false;
            value1.IsEnabled = false;
            value50gr.IsEnabled = false;
            value20gr.IsEnabled = false;
            value10gr.IsEnabled = false;
            value5gr.IsEnabled = false;
            value2gr.IsEnabled = false;
            value1gr.IsEnabled = false;
            valueOtherCurrencies.IsEnabled = false;
            ButtonSaveAndCalculate.IsEnabled = false;
        }

        private int GetValueFromTextBox(TextBox tb)
        {
            return int.TryParse(tb.Text, out int result) ? result : 0;
        }

        private void OnBackClicked(object sender, RoutedEventArgs e)
        {
            _mainWindow.SetLoggedInUser(_loggedUser);
        }
    }
}

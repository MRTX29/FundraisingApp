using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class AdminDashboardPage : Page
    {
        public ObservableCollection<CollectionBox> CollectionBoxes { get; set; }

        public AdminDashboardPage()
        {
            InitializeComponent();

            // Example data
            CollectionBoxes = new ObservableCollection<CollectionBox>
            {
                new CollectionBox { Name = "Puszka 1", Date = "12.10.2022 14:35", ButtonText = "Zatwierdź", ButtonColor = "#007BFF", IsEnabled = true },
                new CollectionBox { Name = "Puszka 2", Date = "15.10.2022 16:35", ButtonText = "Zatwierdzono", ButtonColor = "#666666", IsEnabled = false },
                new CollectionBox { Name = "Puszka 3", Date = "18.10.2022 20:35", ButtonText = "Zatwierdź", ButtonColor = "#007BFF", IsEnabled = true },
                new CollectionBox { Name = "Puszka 4", Date = "22.10.2022 21:35", ButtonText = "Zatwierdź", ButtonColor = "#007BFF", IsEnabled = true },
                new CollectionBox { Name = "Puszka 5", Date = "18.10.2022 20:35", ButtonText = "Zatwierdź", ButtonColor = "#007BFF", IsEnabled = true },
                new CollectionBox { Name = "Puszka 6", Date = "22.10.2022 21:35", ButtonText = "Zatwierdź", ButtonColor = "#007BFF", IsEnabled = true }
            };

            DataContext = this;
        }



        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmCollectionBox_Click(object sender, RoutedEventArgs e)
        {

        }

    }

    public class CollectionBox
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string ButtonText { get; set; }
        public string ButtonColor { get; set; }
        public bool IsEnabled { get; set; }
    }
}
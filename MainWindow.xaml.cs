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
using ShopProductManagerApp.Logic;

namespace ShopProductManagerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IProduct> _products = new List<IProduct>();
        public MainWindow()
        {
            InitializeComponent();

            Username.Text = AuthService.Instance.ActiveUser.Login;
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Неправильное значение для цены!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product addedProduct = new Product
            {
                Name = NameTextBox.Text,
                Price = price
            };

            _products.Add(addedProduct);

            ProductList.ItemsSource = null;
            ProductList.ItemsSource = _products;

            NameTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;
        }
    }
}

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
        private readonly AppDbContext _dbContext = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();

            Username.Text = AuthService.Instance.ActiveUser.Login;

            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductList.ItemsSource = _dbContext.Products.ToList();
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
                MessageBox.Show("Неправильное значение для цены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product newProduct = new Product
            {
                ProductName = NameTextBox.Text,
                Price = price,
                Description = DescriptionTextBox.Text
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            LoadProducts();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Product selectedProduct)
            {
                if (MessageBox.Show($"Удалить товар '{selectedProduct.ProductName}'?", "Подтверждение",
                                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _dbContext.Products.Remove(selectedProduct);
                    _dbContext.SaveChanges();
                    LoadProducts();
                }
            }
        }

    }
}

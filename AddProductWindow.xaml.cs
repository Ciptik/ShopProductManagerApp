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
using System.Windows.Shapes;
using ShopProductManagerApp.Logic;

namespace ShopProductManagerApp
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly ShopDBEntities _dbContext = new ShopDBEntities();
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            string productDescription = ProductDescriptionTextBox.Text;

            if (!decimal.TryParse(ProductPriceTextBox.Text, out decimal produtcPrice))
            {
                MessageBox.Show("Неправильное значение для цены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Products newProduct = new Products
            {
                ProductName = productName,
                Price = produtcPrice,
                Description = productDescription
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            this.Close();
        }
    }
}

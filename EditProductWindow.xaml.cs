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

namespace ShopProductManagerApp
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private readonly ShopDBEntities _dbContext = new ShopDBEntities();
        public EditProductWindow()
        {
            InitializeComponent();

            ProductNameTextBox.Text = Session.selectedProduct.ProductName;
            ProductPriceTextBox.Text = Session.selectedProduct.Price.ToString();
            ProductDescriptionTextBox.Text = Session.selectedProduct.Description;
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

            var currentProduct = _dbContext.Products.FirstOrDefault(
                p => p.ProductName == Session.selectedProduct.ProductName && 
                     p.Price == Session.selectedProduct.Price && 
                     p.Description == Session.selectedProduct.Description
            );

            currentProduct.ProductName = productName;
            currentProduct.Price = produtcPrice;
            currentProduct.Description = productDescription;

            _dbContext.SaveChanges();

            this.Close();
        }
    }
}

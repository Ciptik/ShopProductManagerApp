using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
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
using Microsoft.Win32;
using ShopProductManagerApp.Logic;

namespace ShopProductManagerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _dbContext = new AppDbContext(); // Один контекст на всё окно
        private ObservableCollection<Product> _products;

        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = new ObservableCollection<Product>(_dbContext.Products.ToList());
            ProductList.ItemsSource = _products;
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
                    var productToDelete = _dbContext.Products.Find(selectedProduct.ProductID);
                    _dbContext.Products.Remove(productToDelete);
                    _dbContext.SaveChanges();
                    LoadProducts();
                }
            }
        }
        private void ProductList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var product = (Product)e.Row.DataContext;
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        private void ExportProductButton_Click(object sender, RoutedEventArgs e)
        {
            var data = _dbContext.Products.ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    var properties = data.FirstOrDefault().GetType().GetProperties();

                    foreach (var property in properties)
                    {
                        if (property.Name == "ProductID") continue;

                        writer.Write(property.Name + ";");
                    }

                    writer.WriteLine();

                    foreach (var item in data)
                    {
                        foreach (var property in properties)
                        {
                            if (property.Name == "ProductID") continue;

                            writer.Write(property.GetValue(item) + ";");
                        }

                        writer.WriteLine();
                    }
                }
            }
        }

        private void ImportProductButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "CSV files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true) {
                try
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                    {
                        string[] headers = reader.ReadLine().Split(';');

                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(';');

                            Product product = new Product();

                            for (int i = 0; i < headers.Length; i++)
                            {
                                var propertyInfo = typeof(Product).GetProperty(headers[i]);

                                if (propertyInfo == null) continue;

                                if (propertyInfo.PropertyType == typeof(int)) {
                                    propertyInfo.SetValue(product, int.Parse(values[i]));
                                } else if (propertyInfo.PropertyType == typeof(decimal)) {
                                    propertyInfo.SetValue(product, decimal.Parse(values[i]));
                                } else {
                                    propertyInfo.SetValue(product, values[i]);
                                }
                            }

                            var existingProduct = _dbContext.Products.FirstOrDefault(p =>
                                p.ProductName == product.ProductName &&
                                p.Description == product.Description &&
                                p.Price == product.Price
                            );

                            if (existingProduct != null) return;

                            _dbContext.Products.Add(product);
                            _dbContext.SaveChanges();
                            LoadProducts();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

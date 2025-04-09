using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        private readonly ShopDBEntities _dbContext = new ShopDBEntities(); // Один контекст на всё окно

        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
            string roleName = _dbContext.Rol.FirstOrDefault(r => r.RoleID == AuthService.Instance.ActiveUser.RoleID).RoleName;
            UsernameTextBox.Text = AuthService.Instance.ActiveUser.Login + " (" + roleName + ")";
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

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = NameTextBox.Text.ToLower();
            ProductList.ItemsSource = _dbContext.Products
                .Where(p => p.ProductName.ToLower().Contains(currentText))
                .ToList();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!RoleChecker.IsUserAdmin(AuthService.Instance.ActiveUser.RoleID))
            {
                MessageBox.Show("Вам нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            AddProductWindow addProductWindow = new AddProductWindow();

            addProductWindow.ShowDialog();

            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!RoleChecker.IsUserAdmin(AuthService.Instance.ActiveUser.RoleID))
            {
                MessageBox.Show("Вам нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (sender is Button button && button.Tag is Products selectedProduct)
            {
                Session.selectedProduct = selectedProduct;

                EditProductWindow editProductWindow = new EditProductWindow();

                editProductWindow.ShowDialog();

                MainWindow mainWindow = new MainWindow();

                mainWindow.Show();

                this.Close();
            }
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!RoleChecker.IsUserAdmin(AuthService.Instance.ActiveUser.RoleID))
            {
                MessageBox.Show("Вам нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (sender is Button button && button.Tag is Products selectedProduct)
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
            if (!RoleChecker.IsUserAdmin(AuthService.Instance.ActiveUser.RoleID))
            {
                MessageBox.Show("Вам нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (e.EditAction == DataGridEditAction.Commit)
            {
                var product = (Products)e.Row.DataContext;
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
            if (!RoleChecker.IsUserAdmin(AuthService.Instance.ActiveUser.RoleID))
            {
                MessageBox.Show("Вам нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

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

                            Products product = new Products();

                            for (int i = 0; i < headers.Length; i++)
                            {
                                var propertyInfo = typeof(Products).GetProperty(headers[i]);

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

                            if (existingProduct == null)
                            {
                                _dbContext.Products.Add(product);
                                _dbContext.SaveChanges();
                                LoadProducts();
                            }
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

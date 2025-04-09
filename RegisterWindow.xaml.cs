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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            RoleComboBox.Items.Add("Manager");
            RoleComboBox.Items.Add("Admin");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string role = RoleComboBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (role == "")
            {
                MessageBox.Show("Выберите роль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(role))
            {
                if (AuthService.Instance.AddUser(role, username, password))
                {
                    MessageBox.Show("Пользователь успешно зарегистрирован! Теперь выполните вход!", "Успех", MessageBoxButton.OK);
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин уже существует. Пожалуйста, выберите другой.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OpenLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

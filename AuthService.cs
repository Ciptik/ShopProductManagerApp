using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace ShopProductManagerApp.Logic
{
    public class AuthService
    {
        private static AuthService _instance;
        private readonly ShopDBEntities _dbContext;
        public Users ActiveUser { get; private set; }

        private AuthService()
        {
            _dbContext = new ShopDBEntities();
        }

        public static AuthService Instance => _instance ?? (_instance = new AuthService());

        public bool AddUser(string role, string login, string password)
        {
            if (_dbContext.Users.Any(u => u.Login == login))
            {
                return false;
            }

            var selectRoleId = _dbContext.Rol.FirstOrDefault(r => r.RoleName == role);

            if (selectRoleId == null)
            {
                MessageBox.Show($"Вы неправильно выбрали роль. Поддерживается Manager либо Admin", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            Users newUser = new Users
            {
                RoleID = selectRoleId.RoleID,
                Login = login,
                Pass = password
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CheckData(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login && u.Pass == password);

            if (user == null)
            {
                return false;
            }

            ActiveUser = user;
            return true;
        }
    }
}

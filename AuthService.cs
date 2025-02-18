using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using ShopProductManagerApp.Model;

namespace ShopProductManagerApp.Logic
{
    public class AuthService
    {
        private static AuthService _instance;
        private readonly AppDbContext _dbContext;
        public User ActiveUser { get; private set; }

        private AuthService()
        {
            _dbContext = new AppDbContext();
        }

        public static AuthService Instance => _instance ?? (_instance = new AuthService());

        public bool AddUser(string login, string password)
        {
            if (_dbContext.Users.Any(u => u.Login == login))
            {
                return false;
            }

            User newUser = new User
            {
                Login = login,
                Pass = User.HashPassword(password)
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CheckData(string login, string password)
        {
            string hashedPassword = User.HashPassword(password);
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login && u.Pass == hashedPassword);

            if (user == null)
            {
                return false;
            }

            ActiveUser = user;
            return true;
        }
    }
}

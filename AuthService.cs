using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopProductManagerApp.Model;

namespace ShopProductManagerApp.Logic
{
    // Singleton
    public class AuthService
    {
        private static AuthService _instance;
        private List<User> _users;
        public User ActiveUser { get; private set; }

        private AuthService()
        {
            _users = new List<User>()
        {
            new User("admin", "1234")
        };
        }

        public static AuthService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthService();
                }
                return _instance;
            }
        }

        public bool AddUser(string login, string password)
        {
            if (_users.Any(u => u.Login == login))
            {
                return false;
            }

            _users.Add(new User(login, password));
            return true;
        }

        public bool CheckData(string login, string password)
        {
            var user = _users.FirstOrDefault(u => u.Login == login && u.Password == password);
            ActiveUser = user;
            return user != null;
        }
    }
}

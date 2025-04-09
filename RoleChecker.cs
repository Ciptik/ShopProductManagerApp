using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopProductManagerApp
{
    public static class RoleChecker
    {
        private static readonly ShopDBEntities _dbContext = new ShopDBEntities();

        public static bool IsUserAdmin(int? roleId)
        {
            var roleName = _dbContext.Rol.FirstOrDefault(r => r.RoleID == roleId)?.RoleName;
            return roleName == "Admin";
        }
    }
}

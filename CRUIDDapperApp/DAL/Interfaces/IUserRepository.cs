using CRUIDDapperApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUIDDapperApp.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(User user);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid userId);
        User GetUserById(Guid userId);
        Guid GetUserIdByContext(User user);

        //IEnumerable<User> GetUsersByCategoryId(int categoryId);
    }
}

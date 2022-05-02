using PracticeWebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWebApi.Data.Repositories
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserId(int userId);
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int userId);
    }
}

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
        Task<User> AddUser(User user);
        Task DeleteUser(int userId);
    }
}

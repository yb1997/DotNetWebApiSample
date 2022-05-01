using PracticeWebApi.Business.Models;

namespace PracticeWebApi.Business.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetById(int id);
        User GetByName(string name);
        User UpdateUser(User user);
        void DeleteUser(int id);
    }
}

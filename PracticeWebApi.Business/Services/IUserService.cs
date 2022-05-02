using PracticeWebApi.Business.Models;

namespace PracticeWebApi.Business.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int userId);
        User AddNewUser(User userInfo);
        User UpdateUser(User user);
        void DeleteUser(int id);
    }
}

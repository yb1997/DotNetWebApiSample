using PracticeWebApi.Business.Models;
using PracticeWebApi.Data.Repositories;

namespace PracticeWebApi.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            var users = _userRepo.GetAllUsers();
            List<User> usersList = new List<User>();

            foreach (var user in users)
            {
                usersList.Add(new User
                {
                    UserId = user.UserId,
                    BirthDate = user.BirthDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }

            return usersList;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

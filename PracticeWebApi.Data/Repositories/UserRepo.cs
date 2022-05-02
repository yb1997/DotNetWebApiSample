using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PracticeWebApi.Common;
using PracticeWebApi.Data.DbContexts;
using PracticeWebApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace PracticeWebApi.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly MainDataContext ctx;
        private readonly AppConfig appConfig;
        readonly string conStr;
        public UserRepo(MainDataContext ctx, IOptions<AppConfig> options)
        {
            this.ctx = ctx;
            appConfig = options.Value;

            conStr = appConfig.ConnectionStrings.DefaultConnection;
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var con = new SqlConnection(conStr))
            {
                var users = con.Query<User>("select * from [User]");
                return users;
            }
        }

        public User GetUserByUserId(int userId)
        {
            using (var con = new SqlConnection(conStr))
            {
                var user = con.QuerySingle(
                    $"select * from [User] where UserId = {userId}"
                );

                return user;
            }
        }

        public User AddUser(User user)
        {
            using (var con = new SqlConnection(conStr))
            {
                var sproc = "AddNewUser";
                var procParams = new { 
                    @FirstName = user.FirstName,
                    @LastName = user.LastName,
                    @BirthDate = user.BirthDate
                };

                var newUser = con.QuerySingle<User>(
                    sproc, 
                    procParams, 
                    commandType: CommandType.StoredProcedure
                );
                return newUser;
            }
        }

        public User UpdateUser(User user)
        {
            using (var con = new SqlConnection(conStr))
            {
                var sproc = "UpdateUser";
                var procParams = new
                {
                    @UserId = user.UserId,
                    @FirstName = user.FirstName,
                    @LastName = user.LastName,
                    @BirthDate = user.BirthDate
                };
                var updatedUser = con.QuerySingle<User>
                (
                    sproc,
                    procParams,
                    commandType: CommandType.StoredProcedure
                );
                return updatedUser;
            }
        }

        public void DeleteUser(int userId)
        {
            using (var con = new SqlConnection(conStr))
            {
                var query = $"delete from [User] where UserId = @userId";

                var queryParams = new { userId };

                con.Execute(query, queryParams);
            }
        }
    }
}

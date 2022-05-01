using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PracticeWebApi.Common;
using PracticeWebApi.Data.DbContexts;
using PracticeWebApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace PracticeWebApi.Data.Repositories
{
    public class UserRepo: IUserRepo
    {
        private readonly MainDataContext ctx;
        private readonly AppConfig appConfig;
        public UserRepo(MainDataContext ctx, IOptions<AppConfig> options)
        {
            this.ctx = ctx;
            appConfig = options.Value;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var conStr = appConfig.ConnectionStrings.DefaultConnection;

            using (var con = new SqlConnection(conStr))
            {
                var users = con.Query<User>("select * from [Auth].[User]");
                return users;
            }
        }

        public async Task<User> AddUser(User user)
        {
            var entity = ctx.Users.Add(user).Entity;
            await ctx.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteUser(int userId)
        {
            var entityToRemove = ctx.Users.FindAsync();
        }
    }
}

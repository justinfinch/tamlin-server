using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamlin.MCServer.Domain.Security;
using Dapper;

namespace Tamlin.MCServer.Data.Users
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _dbConnection;

        public UserRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public User GetByUsername(string userName)
        {
            var user = _dbConnection.Query<User>("select * from [mcuser] where [cuserid] = @UserName", new { UserName = userName }).FirstOrDefault();

            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamlin.MCServer.Domain.Security;

namespace Tamlin.MCServer.Data.Users
{
    public interface IUserRepo
    {
        User GetByUsername(string userName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamlin.MCServer.Domain.Security;

namespace Tamlin.MCServer.Business.Security
{
    public interface IUserCache
    {
        Guid Add(User user);
        User Get(Guid key);
    }
}

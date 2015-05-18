using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Security;

namespace Tamlin.MCServer.Web.Security
{
    public class AuthenticatedUser : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}

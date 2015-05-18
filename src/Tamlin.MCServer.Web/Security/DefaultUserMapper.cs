using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Tamlin.MCServer.Web.Security
{
    public class DefaultUserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            
            return new AuthenticatedUser()
            {
                UserName = "justin"
            };
        }
    }
}

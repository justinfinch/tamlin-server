using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Tamlin.MCServer.Business.Security;

namespace Tamlin.MCServer.Web.Security
{
    public class DefaultUserMapper : IUserMapper
    {
        private readonly IUserCache _userCache;

        public DefaultUserMapper(IUserCache userCache)
        {
            _userCache = userCache;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var user = _userCache.Get(identifier);
            if (user == null)
                return null;

            return new AuthenticatedUser()
            {
                UserName = user.cuserid
            };
        }
    }
}

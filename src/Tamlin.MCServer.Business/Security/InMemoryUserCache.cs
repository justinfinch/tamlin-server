using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamlin.MCServer.Domain.Security;

namespace Tamlin.MCServer.Business.Security
{
    public class InMemoryUserCache : IUserCache
    {

        private readonly Dictionary<Guid, User> _userCache;

        public InMemoryUserCache()
        {
            _userCache = new Dictionary<Guid,User>();
        }

        public Guid Add(User user)
        {
            var emptyKvp = default(KeyValuePair<Guid, User>);

            var existingEntries = _userCache.Where(kvp => kvp.Value.cuserid == user.cuserid);
            var key = existingEntries.Any() ? existingEntries.First().Key : Guid.NewGuid();

            if (!_userCache.ContainsKey(key))
            {
                _userCache.Add(key, user);
            }

            return key;
        }

        public User Get(Guid key)
        {
            if (!_userCache.ContainsKey(key))
                return null;

            return _userCache[key];
        }
    }
}

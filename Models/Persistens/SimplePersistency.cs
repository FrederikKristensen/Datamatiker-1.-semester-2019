using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lplplp.Models;

namespace lplplp.Models.Persistens
{
    class SimplePersistency : IPersistency
    {
        private static List<User> _users = new List<User>();

        public async Task<IList<User>> LoadUsers ()
        {
            if (_users.Count == 0)
            {
                _users.Add(new User(Username: "dummyuser", Password: "dummy"));
            }
            return _users;
        }

        public void SaveUsers(IList<User> users)
        {
            _users.Clear();
            foreach (User user in users)
            {
                _users.Add(user);
            }
        }
    }
}

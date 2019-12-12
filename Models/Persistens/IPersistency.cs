using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models.Persistens
{
    interface IPersistency
    {
        Task<IList<User>> LoadUsers();

        void SaveUsers(IList<User> users);
    }
}

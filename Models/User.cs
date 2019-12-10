using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models
{
    class User
    {
        private string _userName;
        private string _passWord;

        public User()
        {
        }
        public User (string Username, string Password)
        {
            _userName = Username;
            _passWord = Password;
        }
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _passWord; }
            set { _passWord = value; }
        }
        public bool CheckInformation()
        {
            if (!Username.Equals("") && !Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}

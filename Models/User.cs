using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string passWord;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }

        public User()
        {
        }
        public User (string UserName, string PassWord)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
        }
        public bool CheckInformation()
        {
            if (!this.UserName.Equals("") && !this.PassWord.Equals(""))
                return true;
            else
                return false;
        }
    }
}

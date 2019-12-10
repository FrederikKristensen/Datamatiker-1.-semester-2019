using lplplp.Common;
using lplplp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace lplplp.ViewModel
{
    class MainViewModelLogin : INotifyPropertyChanged
    {
        //private User _nyBruger;
        private SharedKnowledgeClass _shared;
        //private List<User> _users;
        private RelayCommand _userLogin;
        private string _loginSuccess = "";

        public MainViewModelLogin()
        {
            _userLogin = new RelayCommand(CheckUserInfo);
            _shared = SharedKnowledgeClass.Instance;
            //_nyBruger = new User(Username: "dummy", Password: "dummy");

            //Users = new List<User>();
            //_users.Add(new User(Username: "Rasmus", Password: "1234"));
        }

        private void CheckUserInfo()
        {
            foreach (User obj in Shared.Users)
            {
                if (CheckList(obj.Username, Shared.UserNow) && (CheckList(obj.Password, Shared.PassNow)))
                {
                    LoginSuccess = "lplplp.Kort";
                }
            }
        }

        private bool CheckList(string s1, string s2)
        {
            if (s1.Equals(s2)) { return true; }
            return false;
        }

        public string LoginSuccess
        {
            get { return _loginSuccess; }
            set 
            { 
                _loginSuccess = value;
                OnPropertyChanged();
            }
        }

        //public List<User> Users
        //{
        //    get { return _users; }
        //    set { _users = value; }
        //}
        public SharedKnowledgeClass Shared
        {
            get { return _shared; }
        }
        //public User NyBruger
        //{
        //    get { return _nyBruger; }
        //}


        public RelayCommand UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged
                ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

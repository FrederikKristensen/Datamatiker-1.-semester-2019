using lplplp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lplplp.Common
{
    class SharedKnowledgeClass : INotifyPropertyChanged
    {
        private List<User> _users;
        private User _nyBruger;
        private string _userNow;
        private string _passNow;

        public SharedKnowledgeClass()
        {
            _nyBruger = new User(Username: "dummy", Password: "dummy");

            Users = new List<User>();
            _users.Add(new User(Username: "Rasmus", Password: "1234"));
            _users.Add(new User(Username: "Michael", Password: "1234"));
            _users.Add(new User(Username: "Ask", Password: "1234"));
            _users.Add(new User(Username: "Michelle", Password: "1234"));
            _users.Add(new User(Username: "Frederik", Password: "1234"));
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public User NyBruger
        {
            get { return _nyBruger; }
        }

        // Singleton
        private static SharedKnowledgeClass _instance = new SharedKnowledgeClass();

        public static SharedKnowledgeClass Instance
        {
            get { return _instance; }
        }
        // Slut Singleton

        public string UserNow
        {
            get { return _userNow; }
            set
            {
                _userNow = value;
                OnPropertyChanged();
            }
        }
        public string PassNow
        {
            get { return _passNow; }
            set
            {
                _passNow = value;
                OnPropertyChanged();
            }
        }
    }
}


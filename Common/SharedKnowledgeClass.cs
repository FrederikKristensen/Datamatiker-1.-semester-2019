using lplplp.Models;
using lplplp.Models.Persistens;
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

        private IPersistency _persistens = new FilePersistency();

        private RelayCommand _addUserCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _loadCommand;

        public SharedKnowledgeClass()
        {
            _nyBruger = new User();
            {
                Users = new List<User>();
                _users.Add(new User(Username: "Rasmus", Password: "1234"));
                _users.Add(new User(Username: "Michael", Password: "1234"));
                _users.Add(new User(Username: "Ask", Password: "1234"));
                _users.Add(new User(Username: "Michelle", Password: "1234"));
                _users.Add(new User(Username: "Frederik", Password: "1234"));

                Save();
            }
            _loadCommand = new RelayCommand(Load);
            _saveCommand = new RelayCommand(Save);
            _addUserCommand = new RelayCommand(AddUser);
        }
        private void Save()
        {
            _persistens.SaveUsers(_users);
        }
        private async void Load()
        {
            IList<User> users = await _persistens.LoadUsers();

            _users.Clear();
            foreach (User user in users)
            {
                _users.Add(user);
            }

        }
        private void AddUser()
        {
            _users.Add(_nyBruger);
            _nyBruger = new User();
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
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
        public User NyBruger
        {
            get { return _nyBruger; }
            set { _nyBruger = value; }
        }
        public RelayCommand SaveCommand => _saveCommand;
        public RelayCommand LoadCommand => _loadCommand;
        public RelayCommand AddUserCommand
        {
            get { return _addUserCommand; }
            set { _addUserCommand = value; }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        // Singleton
        private static SharedKnowledgeClass _instance = new SharedKnowledgeClass();

        public static SharedKnowledgeClass Instance
        {
            get { return _instance; }
        }
        // Slut Singleton
    }
}


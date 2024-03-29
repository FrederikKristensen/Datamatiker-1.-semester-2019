﻿using lplplp.Common;
using lplplp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace lplplp.ViewModel
{
	class MainViewModelLogin : INotifyPropertyChanged
	{
		private IPersistency _persistens = new FilePersistency(); // Kobling til persistens

		private SharedKnowledgeClass _shared;
		private List<User> _users;
		private RelayCommand _userLogin;
		private RelayCommand _saveCommand;
		private RelayCommand _loadCommand;

		private string _loginSuccess = "";

        
		public MainViewModelLogin()
		{
			_userLogin = new RelayCommand(CheckUserInfo);
			_shared = SharedKnowledgeClass.Instance;

            Users = new List<User>();
            _users.Add(new User(Username: "Rasmus", Password: "1234", 100));
            _loadCommand = new RelayCommand(Load);
            _saveCommand = new RelayCommand(Save);
        }
        private void CheckUserInfo()
        {
            foreach (User obj in Shared.Users)
            {
                if (CheckList(obj.Username, Shared.UserNow) && (CheckList(obj.Password, Shared.PassNow)))
                {
                    Shared.UserCurrent = obj;
                    Shared.UserNow = "";
                    Shared.PassNow = "";

                    Frame login = (Frame)Window.Current.Content;
                    login.Navigate(typeof(lplplp.View.Kort));
                    // LoginSuccess = "lplplp.Kort";
                    LoginPopUp();
                }
            }
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
        private async void LoginPopUp()
        {
            try
            {
                ContentDialog dialogue = new ContentDialog()
                {
                    Title = "Log in",
                    Content = "Signed in successfully",
                    CloseButtonText = "Ok",
                };
                await dialogue.ShowAsync();
            }
            catch (Exception)
            {
                throw;
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
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public SharedKnowledgeClass Shared
        {
            get { return _shared; }
        }
        //public User NyBruger
        //{
        //    get { return _nyBruger; }
        //}

		public RelayCommand SaveCommand => _saveCommand;
		public RelayCommand LoadCommand => _loadCommand;

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

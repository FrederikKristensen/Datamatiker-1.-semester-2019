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
		private int _highScore;

		public User()
		{
		}

		public User(string Username, string Password, int HighScore)
		{
			_userName = Username;
			_passWord = Password;
			_highScore = HighScore;
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

		public int HighScore
		{
			get { return _highScore; }
			set
			{
				_highScore = value;
			}
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

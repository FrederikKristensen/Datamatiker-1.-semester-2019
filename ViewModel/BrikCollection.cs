using lplplp.Common;
using lplplp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vendespil_0._1;

namespace lplplp.ViewModel
{
	class BrikCollection : INotifyPropertyChanged
	{
		#region Instance fields
		private int userScore = 0;
		private string userName = "Julemanden";

		private ObservableCollection<Brik> brikker;
		private Brik _selectedBrik;
		private int _numberOfBriksTurned = 0;
		private int totalBriksTurned = 0;
		private RelayCommand _vendBrikCommand;
		private NumberGenerator Ngenerator = new NumberGenerator();
		private Brik _image1 = null;
		private Brik _image2 = null;

		List<string> newImages = new List<string>();
		#endregion

		#region Constructor
		public BrikCollection()
		{
			brikker = new ObservableCollection<Brik>();
			for (int i = 1; i < 17; i++)
			{
				brikker.Add(new Brik(i));
			}
			for (int i = 1; i < 3; i++)
			{
				for (int j = 1; j < 9; j++)
				{
					newImages.Add("Assets\\BrikForside" + j + ".png");
				}
			}
			foreach (Brik brik in brikker)
			{
				int randomImageNumber = Ngenerator.Next(1, (17 - brik.Position));
				brik.ImageSourceForside = newImages[randomImageNumber - 1];
				newImages.RemoveAt(randomImageNumber - 1);
			}
			_selectedBrik = new Brik();
			_vendBrikCommand = new RelayCommand(async () => await VendSelectedBrikAsync());
		}
		#endregion

		#region Properties

		public RelayCommand VendBrik
		{
			get { return _vendBrikCommand; }
			set { _vendBrikCommand = value; }
		}
		public ObservableCollection<Brik> Brikker
		{
			get { return brikker; }
			set
			{
				brikker = value;
				OnPropertyChanged();
			}
		}

		public Brik Image1
		{
			get { return _image1; }
			set
			{
				_image1 = value;
				OnPropertyChanged();
			}
		}
		public Brik Image2
		{
			get { return _image2; }
			set
			{
				_image2 = value;
				OnPropertyChanged();
			}
		}
		public Brik SelectedBrik
		{
			get { return _selectedBrik; }
			set
			{
				_selectedBrik = value;
				OnPropertyChanged();
			}
		}

		public int NumberOfBriksTurned
		{
			get { return _numberOfBriksTurned; }
			set
			{
				_numberOfBriksTurned = value;
				OnPropertyChanged();
			}

		}

		public int UserScore
		{
			get { return userScore; }
			set
			{
				userScore = value;
				OnPropertyChanged();
			}
		}
		public string UserName
		{
			get { return userName; }
			set
			{
				userName = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Methods

		public async Task<int> IsBrikFaceDown()
		{
			if (SelectedBrik.IsFaceDown)
			{

				ChangeImage(SelectedBrik, SelectedBrik.ImageSourceForside);
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public async Task VendSelectedBrikAsync()
		{
			if (SelectedBrik.IsFaceDown)
			{
				Task<int> briksTurned = IsBrikFaceDown();
				NumberOfBriksTurned += await briksTurned;
				SelectedBrik.IsFaceDown = false;
				if (NumberOfBriksTurned == 1)
				{
					Image1 = SelectedBrik;
				}
				if (NumberOfBriksTurned == 2)
				{
					UserScore += 1;
					Image2 = SelectedBrik;
					bool identicalImages = Image1.ImageSourceForside.Equals(Image2.ImageSourceForside);
					if (identicalImages)
					{
						UserScore += 1;
						Image1 = null;
						Image2 = null;
						NumberOfBriksTurned = 0;
						totalBriksTurned += 1;
						TestForEndGame();
					}
					else
					{
						//Thread.Sleep(2000);
						ChangeImage(Image1, Image1.ImageSourceBagside);
						ChangeImage(Image2, Image2.ImageSourceBagside);
						Image1 = null;
						Image2 = null;
						NumberOfBriksTurned = 0;
					}
				}
			}
		}

		public void TestForEndGame()
		{
			if (totalBriksTurned == 8)
			{
				UserScore = 0;
			}

		}
		public void ChangeImage(Brik brik, string newImage)
		{
			brik.ImageSourceCurrent = newImage;
			brik.IsFaceDown = !SelectedBrik.IsFaceDown;
			OnPropertyChanged();
		}
		#endregion

		#region Code for OnPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

	}
}


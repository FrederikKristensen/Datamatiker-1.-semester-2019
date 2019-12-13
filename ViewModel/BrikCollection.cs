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
		//private string userName;
		List<string> newImages = new List<string>();

		private SharedKnowledgeClass shared;

		private ObservableCollection<Brik> brikker;
		private Brik _selectedBrik;
		private int _numberOfBriksTurned = 0;
		private int totalBriksTurned = 0;

		private NumberGenerator Ngenerator = new NumberGenerator();
		private Brik _image1 = null;
		private Brik _image2 = null;

		private RelayCommand _vendBrikCommand;
		private RelayCommand _ikkeEnsBrikkerCommand;

		#endregion

		#region Constructor
		public BrikCollection()
		{
			shared = SharedKnowledgeClass.Instance;
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
			_vendBrikCommand = new RelayCommand(VendSelectedBrik);
			_ikkeEnsBrikkerCommand = new RelayCommand(IkkeEnsBrikker);
		}
		#endregion

		#region Properties
		public RelayCommand IkkeEnsBrikkerCommand
		{
			get { return _ikkeEnsBrikkerCommand; }
			set { _ikkeEnsBrikkerCommand = value; }
		}
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

		public string UserName
		{
			get { return Shared.UserCurrent.Username; }
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

		//public string UserName
		//{
		//	get { return userName; }
		//	set
		//	{
		//		userName = value;
		//		OnPropertyChanged();
		//	}
		//}

		public SharedKnowledgeClass Shared
		{
			get { return shared; }
		}
		#endregion

		#region Methods

		//public bool IsBrikFaceDown()
		//{
		//	if (SelectedBrik.IsFaceDown)
		//	{
		//		return 1;
		//	}
		//	else
		//	{
		//		return 0;
		//	}
		//}

		public void VendSelectedBrik()
		{
			if (SelectedBrik.IsFaceDown & NumberOfBriksTurned == 0)
			{
				Image1 = SelectedBrik;
				NumberOfBriksTurned = NumberOfBriksTurned + 1;
				SelectedBrik.IsFaceDown = false;
				ChangeImage(SelectedBrik, SelectedBrik.ImageSourceForside);
			} else
			if (SelectedBrik.IsFaceDown && NumberOfBriksTurned == 1)
			{
				Image2 = SelectedBrik;
				ChangeImage(SelectedBrik, SelectedBrik.ImageSourceForside);
				NumberOfBriksTurned = NumberOfBriksTurned + 1;
				SelectedBrik.IsFaceDown = false;

			}
			if (NumOfBriksTurned())
			{
				UserScore += 1;
				if (IdentImages())
				{
					UserScore += 1;
					NumberOfBriksTurned = 0;
					totalBriksTurned += 1;
					Image1 = new Brik();
					Image2 = new Brik();
					TestForEndGame();
				} else if (!NumOfBriksTurned())
				{
					
				}
			}

			//if (SelectedBrik.IsFaceDown)
			//{
			//	if (NumberOfBriksTurned <= 1)
			//	{
			//		Image1 = SelectedBrik;
			//	}
			//	ChangeImage(SelectedBrik, SelectedBrik.ImageSourceForside);
			//	NumberOfBriksTurned += 1;
			//	SelectedBrik.IsFaceDown = false;
			//	if (NumOfBriksTurned())
			//	{
			//		UserScore += 1;
			//		Image2 = SelectedBrik;
			//		if (IdentImages())
			//		{
			//			UserScore += 1;
			//			Image1 = new Brik();
			//			Image2 = new Brik();
			//			NumberOfBriksTurned = 0;
			//			totalBriksTurned += 1;
			//			IkkeEnsBrikker();
			//			TestForEndGame();
			//		}
			//	}
			//}
		}

		public bool NumOfBriksTurned()
		{
			return NumberOfBriksTurned >= 2 ? true : false;
		}

		public bool IdentImages()
		{
			return Image1.ImageSourceForside.Equals(Image2.ImageSourceForside);
		}

		public void IkkeEnsBrikker()
		{
			ChangeImage(Image1, Image1.ImageSourceBagside);
			ChangeImage(Image2, Image2.ImageSourceBagside);
			Image1 = new Brik();
			Image2 = new Brik();
			NumberOfBriksTurned = 0;
		}

		public void TestForEndGame()
		{
			if (totalBriksTurned == 8)
			{
				Shared.UpdateHighScore(UserScore);
				Shared.Save();
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


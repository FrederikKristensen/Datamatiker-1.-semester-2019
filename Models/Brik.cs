using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vendespil_0._1
{
    class Brik : INotifyPropertyChanged
    {
        private int _position;
        private string _imageSourceForside;
        private string _imageSourceBagside;
        private string _imageSourceCurrent;

        private bool _isFaceDown;

        public Brik(int position)
        {
            _position = position;
            _imageSourceBagside = "Assets/BrikBagside1.png";
            _imageSourceCurrent = ImageSourceBagside;
            _isFaceDown = true;
        }

        //public void DeleteImage()
        //{
        //    ImageSourceForside = "Assets/BrikForsideBlank";
        //    OnPropertyChanged();
        //}
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public string ImageSourceBagside
        {
            get { return _imageSourceBagside; }
            set
            {
                _imageSourceBagside = value;
                OnPropertyChanged();
            }
        }

        public string ImageSourceForside
        {
            get { return _imageSourceForside; }
            set
            {
                _imageSourceForside = value;
                OnPropertyChanged();
            }
        }

        public string ImageSourceCurrent
        {
            get { return _imageSourceCurrent; }
            set
            {
                _imageSourceCurrent = value;
                OnPropertyChanged();
            }
        }


        public bool IsFaceDown
        {
            get { return _isFaceDown; }
            set
            {
                _isFaceDown = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return base.ToString() + ": " + Position; ;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Brik()
        {
        }

    }


}

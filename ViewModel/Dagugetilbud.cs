using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using lplplp.Model;

namespace lplplp.Viewmodel
{
    class Dagugetilbud : INotifyPropertyChanged
    {
        private ObservableCollection<Tilbud> _tilbudliste;
        private Tilbud _valgttilbud;

        #region Propeties
        public Tilbud Valgttilbud
        {
            get { return _valgttilbud; }
            set
            {
                _valgttilbud = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tilbud> Tilbudliste
        {
            get { return _tilbudliste; }
        }
        #endregion

        #region Konstruktør
        public Dagugetilbud()
        {
            _tilbudliste = new ObservableCollection<Tilbud>();

            Tilbudliste.Add(new Tilbud(30, " Føtex", " Cookie", "../Assets/Chocolate_Chip_Cookies_-_kimberlykv.jpg"));
            Tilbudliste.Add(new Tilbud(70, " Netto", " Bolig", "../Assets/download.jpg"));
            Tilbudliste.Add(new Tilbud(130, " Føtex", " Kat", "../Assets/relaxing-cat.jpg"));
            Tilbudliste.Add(new Tilbud(300, " Fakta", " Bedstemor", "../Assets/relaxing-cat.jpg"));
            Tilbudliste.Add(new Tilbud(250, " Lidl", " Advokado", "../Assets/relaxing-cat.jpg"));
            Tilbudliste.Add(new Tilbud(150, " Irma", " Enhjørning", "../Assets/relaxing-cat.jpg"));

            _valgttilbud = new Tilbud();
        }
        #endregion

        #region OnPropertyChanged
        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
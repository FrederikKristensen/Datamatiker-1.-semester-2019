using lplplp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.ViewModel
{
    class ButikkerViewModel : INotifyPropertyChanged
    {
        #region Konstanter
        private string ButikH = "10:00-19:00";
        private string ButikW = "10:00-17:00";
        private string ResturantK = "10:00-20:00";
        private string ResturantL = "10:00-22:00";
        #endregion

        #region Instansfelter
        private ObservableCollection<Butik> _butikker;
        private Butik _valgtButik;
        #endregion

        #region Konstruktør
        public ButikkerViewModel()
        {
            _butikker = new ObservableCollection<Butik>();
            _butikker.Add(new Butik("Apoteket RO´s Torv", 1, ButikH, ButikW, ButikW, "+45 46 32 23 00", "https://www.apoteket.dk/apoteker/roskilde-svane-apotek/apoteket-ros-torv", "https://www.facebook.com/pages/category/Pharmacy---Drugstore/Apoteket-ROs-torv-1089266301092022/", "-", "-", "../Assets/apotek.png"));
            _butikker.Add(new Butik("Arnold Busck", 2, ButikH, ButikW, ButikW, "+45 46 34 12 46", "https://www.arnoldbusck.dk/butikker/roskilde", "https://www.facebook.com/pages/category/Bookstore/Arnold-Busck-Roskilde-1643600719241642/", "https://www.instagram.com/arnoldbusck/?hl=da", "-", "../Assets/Busck.png"));
            _butikker.Add(new Butik("Bash burger & grill", 3, ResturantL, ResturantL, ResturantL, "+45 29 28 80 09", "http://bashburger.dk/", "https://www.facebook.com/bashburger.dk/", "https://www.instagram.com/bashburger.dk/?hl=da", "-", "../Assets/Bash.png"));
            _butikker.Add(new Butik("Bolia", 4, ButikH, ButikW, ButikW, "+45 30 36 89 95", "https://www.bolia.com/da-dk/mod-os/butikker/find-butikker/bolia-roskilde-ros-torv/", "https://www.facebook.com/pages/Bolia-Ros-Torv/639245362773042?nr", "xx", "xx", "../Assets/Bolia.png"));
            _butikker.Add(new Butik("Bonde Boutique", 5, ButikH, ButikW, ButikW, "+45 46 36 12 55", "https://www.bondeboutique.dk/", "https://www.facebook.com/bondeboutique/", "https://www.instagram.com/bondeboutique/", "-", "../Assets/Bonde.png"));
            _butikker.Add(new Butik("BR", 6, ButikH, ButikW, ButikW, "+ 45 87 78 84 60", "xx", "xx", "xx", "xx", "../Assets/BR.png"));
            _butikker.Add(new Butik("Burger King", 7, ResturantK, ResturantK, ResturantK, "+45 46 37 30 00", "xx", "xx", "xx", "xx", "../Assets/BurgerKing.png"));
            _butikker.Add(new Butik("By Mo", 8, ButikH, ButikW, ButikW, "+45 62 26 44 24", "xx", "xx", "xx", "xx", "../Assets/ByMo.png"));
            _butikker.Add(new Butik("Børne-Foto", 9, ButikH, ButikW, ButikW, "+45 40 27 94 64", "xx", "xx", "xx", "xx", "../Assets/Børne.png"));
            _butikker.Add(new Butik("Café Vivaldi", 10, ResturantL, ResturantL, ResturantL, "+45 46 37 40 40", "xx", "xx", "xx", "xx", "../Assets/Vivaldi.png"));
            _butikker.Add(new Butik("Centerinformation", 11, ButikH, ButikW, ButikW, "+45 46 38 06 80", "xx", "xx", "xx", "xx", "../Assets/Information.png"));
            _butikker.Add(new Butik("Companys", 12, ButikH, ButikW, ButikW, "+45 46 36 62 61", "xx", "xx", "xx", "xx", "../Assets/Companys.jfif"));
            _butikker.Add(new Butik("Copenhagen Luxe", 13, ButikH, ButikW, ButikW, "+45 42 64 63 80", "xx", "xx", "xx", "xx", "../Assets/CopenhagenLuxe.png"));
            _butikker.Add(new Butik("D´let", 14, "10:00-19:30 (Bemærk buffet fra kl 11:00)", "10:00-19:30 (Bemærk buffet fra kl 11:00)", "11:00-19:30 (Bemærk buffet fra kl 12:00)", "+45 31 39 91 01", "xx", "xx", "xx", "xx", "../Assets/Dlet.png"));
            _butikker.Add(new Butik("Danske Lægers Vaccinations Service", 15, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/DanskeLægers.png"));
            _butikker.Add(new Butik("Deichmann", 16, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Deichmann.jfif"));
            _butikker.Add(new Butik("Espresso House", 17, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/EspressoHouse.jfif"));
            _butikker.Add(new Butik("Flying Tiger Copenhagen", 18, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/FlyingTiger.jpg"));
            _butikker.Add(new Butik("Frellsen", 19, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Frellsen.png"));
            _butikker.Add(new Butik("Føtex", 20, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Føtex.png"));
            _butikker.Add(new Butik("GameStop+", 21, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/gamestopplus.png"));
            _butikker.Add(new Butik("Glitter", 22, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Glitter.png"));
            _butikker.Add(new Butik("H&M", 23, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/HogM.png"));
            _butikker.Add(new Butik("Helsemin", 24, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Helsemin.png"));
            _butikker.Add(new Butik("Home", 25, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Home.jfif"));
            _butikker.Add(new Butik("Hotel Chocolat", 26, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/HotelChocolat.png"));
            _butikker.Add(new Butik("Humac", 27, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Humac.png"));
            _butikker.Add(new Butik("Hunkemöller", 28, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Hunkemoller.jfif"));
            _butikker.Add(new Butik("Hæle & Nøglebar", 29, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/HæleogNøgler.png"));
            _butikker.Add(new Butik("Imerco Home", 30, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Imerco.png"));
            _butikker.Add(new Butik("Joe & the Juice", 31, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/JoeAndTheJuice.png"));
            _butikker.Add(new Butik("Kings & Queens", 32, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/KingsAndQueens.png"));
            _butikker.Add(new Butik("Kino", 33, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Kino.png"));
            _butikker.Add(new Butik("Kristlig fagbevægelse", 34, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Krifa.png"));
            _butikker.Add(new Butik("Matas", 35, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Matas.png"));
            _butikker.Add(new Butik("Message", 36, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Message.png"));
            _butikker.Add(new Butik("Mr. Møllbach", 37, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Møllbach.png"));
            _butikker.Add(new Butik("Müllers Guldsmedje", 38, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Mullers.png"));
            _butikker.Add(new Butik("Name it", 39, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/NameIt.png"));
            _butikker.Add(new Butik("Neye", 40, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Neye.png"));
            _butikker.Add(new Butik("Nice Thai Massage", 41, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/NiceThai.png"));
            _butikker.Add(new Butik("No8", 42, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/No8.jfif"));
            _butikker.Add(new Butik("Normal", 43, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Normal.png"));
            _butikker.Add(new Butik("Only", 44, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Only.png"));
            _butikker.Add(new Butik("Panduro", 45, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Panduro.png"));
            _butikker.Add(new Butik("Peace of Cake", 46, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/PeaceOfCake.png"));
            _butikker.Add(new Butik("PhonePower", 47, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/PhonePower.png"));
            _butikker.Add(new Butik("Pieces", 48, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Pieces.png"));
            _butikker.Add(new Butik("Pilgrim", 49, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Pilgrim.png"));
            _butikker.Add(new Butik("Postbutik", 50, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Post.png"));
            _butikker.Add(new Butik("Profil Optik", 51, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/ProfilOptik.jfif"));
            _butikker.Add(new Butik("Queens Nails", 52, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Queens.png"));
            _butikker.Add(new Butik("Resturant Flammen", 53, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Flammen.png"));
            _butikker.Add(new Butik("Ristorente La Rustica", 54, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/LaRustica.jpg"));
            _butikker.Add(new Butik("Rituals", 55, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Rituals.jfif"));
            _butikker.Add(new Butik("Roskilde Vin", 56, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/RoskildeVin.png"));
            _butikker.Add(new Butik("Salon Unique", 57, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/SalonUnique.png"));
            _butikker.Add(new Butik("Sams", 58, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Sams.png"));
            _butikker.Add(new Butik("Samsøe & Samsøe", 59, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Samsøe.png"));
            _butikker.Add(new Butik("SATS", 60, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/SATS.png"));
            _butikker.Add(new Butik("Schack & Thorsted", 61, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Schack.png"));
            _butikker.Add(new Butik("Skoringen", 62, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Skoringen.png"));
            _butikker.Add(new Butik("SODA", 63, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Soda.png"));
            _butikker.Add(new Butik("Sport 24", 64, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Sport24.png"));
            _butikker.Add(new Butik("Sportsmaster", 65, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/SportMaster.jfif"));
            _butikker.Add(new Butik("Suitmeup", 66, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/SuitMeUp.jfif"));
            _butikker.Add(new Butik("Swarovski", 67, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Swarovski.png"));
            _butikker.Add(new Butik("Søstrene Grene", 68, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/SøstreneGrene.png"));
            _butikker.Add(new Butik("Tamaris", 69, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Tamaris.png"));
            _butikker.Add(new Butik("The Bagel House", 70, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/TheBagelHouse.jfif"));
            _butikker.Add(new Butik("The Spot Cafe", 71, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/TheSpotCafe.png"));
            _butikker.Add(new Butik("Thiele", 72, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Thiele.jfif"));
            _butikker.Add(new Butik("Trendkids", 73, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/TrendKids.png"));
            _butikker.Add(new Butik("Trendstar", 74, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Trendstar.jpg"));
            _butikker.Add(new Butik("Triumph", 75, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/triumph.png"));
            _butikker.Add(new Butik("Tøjeksperten", 76, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/TøjEksperten.jpg"));
            _butikker.Add(new Butik("Vero Moda", 77, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/VeroModa.png"));
            _butikker.Add(new Butik("Vila", 78, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Vila.png"));
            _butikker.Add(new Butik("Zhiki Sushi", 79, "xx", "xx", "xx", "xx", "xx", "xx", "xx", "xx", "../Assets/Zhiki.png"));

            _valgtButik = new Butik();
        }
        #endregion

        #region Properties
        public Butik ValgtButik
        {
            get { return _valgtButik; }
            set
            {
                _valgtButik = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Butik> Butikker
        {
            get { return _butikker; }
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

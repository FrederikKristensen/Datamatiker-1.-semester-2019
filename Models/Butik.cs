using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models
{
    class Butik
    {
        private string _navn;
        private int _nummer;
        private string _åbningstiderH;
        private string _åbningstiderW;
        private string _åbningstiderS;
        private string _telefon;
        private string _website;
        private string _facebook;
        private string _instagram;
        private string _youtube;
        private string _logo;

        public string Navn
        {
            get { return _navn; }
            set
            {
                _navn = value;
            }
        }

        public int Nummer
        {
            get { return _nummer; }
            set { _nummer = value; }
        }

        public string Logo
        {
            get { return _logo; }
        }

        public string ÅbningstiderH
        {
            get { return _åbningstiderH; }
            set { _åbningstiderH = value; }
        }

        public string ÅbningstiderW
        {
            get { return _åbningstiderW; }
            set { _åbningstiderW = value; }
        }

        public string ÅbningstiderS
        {
            get { return _åbningstiderS; }
            set { _åbningstiderS = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }

        public string Facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        public string Instagram
        {
            get { return _instagram; }
            set { _instagram = value; }
        }

        public string Youtube
        {
            get { return _youtube; }
            set { _youtube = value; }
        }

        public Butik(string Navn, int Nummer, string ÅbningstiderH, string ÅbningstiderW, string ÅbningstiderS, string Telefon, string Website, string Facebook, string Instagram, string Youtube, string Logo)
        {
            _navn = Navn;
            _nummer = Nummer;
            _åbningstiderH = ÅbningstiderH;
            _åbningstiderW = ÅbningstiderW;
            _åbningstiderS = ÅbningstiderS;
            _telefon = Telefon;
            _website = Website;
            _facebook = Facebook;
            _instagram = Instagram;
            _youtube = Youtube;
            _logo = Logo;
        }

        public Butik()
        {

        }

        public override string ToString()
        {
            return Navn + Nummer + ÅbningstiderH + ÅbningstiderW + ÅbningstiderS + Telefon + Website + Facebook + Instagram + Youtube + Logo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Model
{
    class Tilbud
    {
        private int _pris;
        private string _butikNavn;
        private string _produktNavn;
        private string _produktBillede;

        #region propeties 
        public int Pris
        {
            get { return _pris; }
        }
        public string ButikNavn
        {
            get { return _butikNavn; }
        }
        public string ProduktNavn
        {
            get { return _produktNavn; }
        }
        public string ProduktBillede
        {
            get { return _produktBillede; }
        }
        #endregion

        #region Konstruktør
        public Tilbud(int Pris, string ButikNavn, string ProduktNavn, string ProduktBillede)
        {
            _pris = Pris;
            _butikNavn = ButikNavn;
            _produktNavn = ProduktNavn;
            _produktBillede = ProduktBillede;
        }

        public Tilbud()
        {

        }
        #endregion
    }
}

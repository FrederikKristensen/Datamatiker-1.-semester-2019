using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models
{
    class Kunst
    {
        private string _tittel;
        private string _kunstner;
        private string _omKunstner;
        private string _placering;
        private string _beskrivelse;
        private string _billede;

        public string Tittel
        {
            get { return _tittel; }
        }

        public string Kunstner
        {
            get { return _kunstner; }
        }

        public string OmKunstner
        {
            get { return _omKunstner; }
        }

        public string Placering
        {
            get { return _placering; }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
        }

        public string Billede
        {
            get { return _billede; }
        }


        public Kunst(string Tittel, string Kunstner, string OmKunstner, string Placering, string Beskrivelse, string Billede)
        {
            _tittel = Tittel;
            _kunstner = Kunstner;
            _omKunstner = OmKunstner;
            _placering = Placering;
            _beskrivelse = Beskrivelse;
            _billede = Billede;
        }

        public Kunst()
        {

        }
    }
}

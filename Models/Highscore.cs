using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Models
{
   class Highscore
   {
      private string _name;
      private int _score;
      private int _rank;

      public Highscore(int rank, string name, int score)
      {
         _rank = rank;
         _name = name;
         _score = score;
      }

      public Highscore()
      {

      }
      public string Name
      {
         get { return _name; }
      }

      public int Score
      {
         get { return _score; }
      }

      public int Rank
      {
         get { return _rank; }
         set { _rank = value; }
      }
   }
}

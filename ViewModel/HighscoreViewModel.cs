using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using lplplp.Common;
using lplplp.Models;
using Windows.UI.Xaml.Data;

namespace lplplp.ViewModel
{
   class HighscoreViewModel : INotifyPropertyChanged
   {
      private List<Highscore> highScores;
      //private ObservableCollection<Highscore> highscores;
      private SharedKnowledgeClass shared;
      private int userScore = 0;
      private List<Highscore> sortedHighScores;

      public HighscoreViewModel()
      {
         shared = SharedKnowledgeClass.Instance;
         highScores = new List<Highscore>();
         //highscores = new ObservableCollection<Highscore>();
         sortedHighScores = new List<Highscore>();
         HentUsers();

         //_highscores.Add(new Highscore(2,"Peter", 11));
         //_highscores.Add(new Highscore(3,"Jacob", 12));
         //_highscores.Add(new Highscore(1, "Sanne Salomonsen", 10));

      }

      public List<Highscore> SortedHighScores
      {
         get { return sortedHighScores; }
         set { sortedHighScores = value; }
      }

      private void HentUsers()
      {
         foreach (User user in Shared.Users)
         {
            HighScores.Add(new Highscore(1, user.Username, user.HighScore));
         }
         
         HighScores.Sort((x, y) => x.Score.CompareTo(y.Score));
         int rankCounter = 1;
         foreach(Highscore user in HighScores)
         {
            user.Rank = rankCounter;
            rankCounter++;
         }

         //List<Highscore> SortedHighScores = HighScores.OrderBy(o => o.Rank).ToList();

         //Highscore tempHighScore = new Highscore(1000, "Dummy", 1000);
         //int j = HighScores.Count+1;
         //for (int i = 1; i < j; i++)
         //{
         //   tempHighScore = new Highscore(1000, "Dummy", 1000);
         //   foreach (Highscore obj in HighScores)
         //   {
         //      if (obj.Score < tempHighScore.Score)
         //      {
         //         tempHighScore = obj;
         //      }
         //   }
         //   SortedHighScores.Add(new Highscore(i, tempHighScore.Name, tempHighScore.Score));
         //   HighScores.Remove(tempHighScore);
         //}

      }



      //public ObservableCollection<Highscore> Highscores
      public List<Highscore> HighScores
      {
         get { return highScores; }
            set { highScores = value;
            }
      }

      public SharedKnowledgeClass Shared
      {
         get { return shared; }
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



      //public void NewHighscore() //Hurr durr indsæt
      //{
      //   highscores.Add(new Highscore(0, Shared.UserCurrent.Username, Shared.UserCurrent.HighScore));
      //}

      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}


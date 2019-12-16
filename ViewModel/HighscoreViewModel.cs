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
      private ObservableCollection<Highscore> highscores;
      private SharedKnowledgeClass shared;
      private int userScore = 0;
      private List<Highscore> sortedHighScores;

      public HighscoreViewModel()
      {
         highscores = new ObservableCollection<Highscore>();
         shared = SharedKnowledgeClass.Instance;
         sortedHighScores = new List<Highscore>();
         HentUsers();

         //_highscores.Add(new Highscore(2,"Peter", 11));
         //_highscores.Add(new Highscore(3,"Jacob", 12));
         //_highscores.Add(new Highscore(1, "Sanne Salomonsen", 10));

      }

      public void HentUsers()
      {
         int rankCounter = 1;
         foreach (User preben in Shared.Users)
         {
            highscores.Add(new Highscore(rankCounter, preben.Username, preben.HighScore));
            rankCounter++;

         }
         Highscore tempHighScore = new Highscore(1000, "Dummy", 1000);

         for (int i = 0; i < Highscores.Count; i++)
         {

            foreach (Highscore obj in Highscores)
            {
               if (obj.Score < tempHighScore.Score)
               {
                  tempHighScore = obj;

               }
            }
            sortedHighScores.Add(tempHighScore);
            Highscores.Remove(tempHighScore);
         }

      }



      public ObservableCollection<Highscore> Highscores
      {
         get { return highscores; }
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


      public void NewHighscore() //Hurr durr indsæt
      {
         highscores.Add(new Highscore(0, Shared.UserCurrent.Username, Shared.UserCurrent.HighScore));
      }

      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}


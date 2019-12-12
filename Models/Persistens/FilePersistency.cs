using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using lplplp.Models;

namespace lplplp.Models.Persistens
{
    class FilePersistency : IPersistency
    {
        private const string FileName = "UserLoginData.txt";
        private StorageFolder _folder = ApplicationData.Current.LocalFolder;

        public async Task<IList<User>> LoadUsers()
        {
            IList<User> liste;
            var fileExists = await _folder.TryGetItemAsync(FileName);
            if (fileExists == null)
            {
                liste = new List<User>();
            }
            else
            {
                StorageFile datafile = await _folder.GetFileAsync(FileName);
                string jstring = await FileIO.ReadTextAsync(datafile);
                liste = JsonConvert.DeserializeObject<IList<User>>(jstring);
            }
            return liste;
        }

        public async void SaveUsers(IList<User> users)
        {
            string jstring = JsonConvert.SerializeObject(users);
            var datafile = await _folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(datafile, jstring);
        }
    }
}

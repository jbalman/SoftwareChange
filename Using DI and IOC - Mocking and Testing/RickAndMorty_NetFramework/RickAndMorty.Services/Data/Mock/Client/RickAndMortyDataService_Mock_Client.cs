using RickAndMorty.Services.Data.Models;
using System.Collections.Generic;
using System.IO;

namespace RickAndMorty.Services.Data.Mock.Client
{
    public class RickAndMortyDataService_Mock_Client
    {
        string _jsonDataFolder;
        public RickAndMortyDataService_Mock_Client(string JsonDataFolder)
        {
            _jsonDataFolder = JsonDataFolder;
        }

        public IEnumerable<Character> GetCharacters()
        {
            string characters = System.IO.Path.Combine(_jsonDataFolder, "characters.json");
            return GetObjects<Character>(characters);
        }
        public IEnumerable<Location> GetLocations()
        {
            string locations = System.IO.Path.Combine(_jsonDataFolder, "locations.json");
            return GetObjects<Location>(locations);
        }
        public IEnumerable<Episode> GetEpisodes()
        {
            string episodes = System.IO.Path.Combine(_jsonDataFolder, "episodes.json");
            return GetObjects<Episode>(episodes);
        }

        private IEnumerable<T> GetObjects<T>(string fileName)
        {
            List<T> objects = new List<T>();
            string json = File.ReadAllText(fileName);
            objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
            return objects;
        }
    }
}

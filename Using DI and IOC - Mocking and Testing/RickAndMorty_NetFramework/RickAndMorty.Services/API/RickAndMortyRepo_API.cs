using Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Repositories.API
{
    public class RickAndMortyRepo_API : IRickAndMortyRepo
    {
        private static List<Character> _characters;
        public List<Character> Characters
        {
            get
            {
                return _characters;
            }
        }
        private static List<Episode> _episodes;
        private static List<Location> _locations;
        public RickAndMortyRepo_API()
        {
        }

        public ICharacter GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEpisode GetEpisodeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ILocation GetLocationById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

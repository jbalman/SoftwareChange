using System;
using System.Collections.Generic;
using RickAndMorty.Contracts;

namespace RickAndMorty.Implementations
{
    public class Character : ICharacter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public ILocation origin { get; set; }
        public ILocation location { get; set; }
        public Uri image { get; set; }
        public IEnumerable<IEpisode> episodes { get; set; }
        public Uri url { get; set; }
        public DateTime created { get; set; }
    }
}

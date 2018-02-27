using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;

namespace RickAndMorty.Implementations
{
    public class Location : ILocation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimension { get; set; }
        public IEnumerable<ICharacter> residents { get; set; }
        public Uri url { get; set; }
        public DateTime created { get; set; }
    }
}

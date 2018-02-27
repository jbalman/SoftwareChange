using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Implementations
{
    public class Episode : IEpisode
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime air_date { get; set; }
        public string episode { get; set; }
        public IEnumerable<ICharacter> characters { get; set; }
        public Uri url { get; set; }
        public DateTime created { get; set; }
    }
}

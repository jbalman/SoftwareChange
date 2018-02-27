using System;
using System.Collections.Generic;

namespace RickAndMorty.Contracts
{
    public interface ICharacter
    {
        int id { get; set; }
        string name { get; set; }
        string status { get; set; }
        string species { get; set; }
        string type { get; set; }
        string gender { get; set; }
        ILocation origin { get; set; }
        ILocation location { get; set; }
        Uri image { get; set; }
        IEnumerable<IEpisode> episodes { get; set; }
        Uri url { get; set; }
        DateTime created { get; set; }
    }
}

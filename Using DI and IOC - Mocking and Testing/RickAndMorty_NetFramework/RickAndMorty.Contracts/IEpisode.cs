using System;
using System.Collections.Generic;

namespace RickAndMorty.Contracts
{
    public interface IEpisode
    {
        int id { get; set; }
        string name { get; set; }
        DateTime air_date { get; set; }
        string episode { get; set; }
        IEnumerable<ICharacter> characters { get; set; }
        Uri url { get; set; }
        DateTime created { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRickAndMortyRepo
    {
        ICharacter GetCharacterById(int id);
        ILocation GetLocationById(int id);
        IEpisode GetEpisodeById(int id);
    }
}

using System.Collections.Generic;
using System.Linq;

namespace RickAndMorty.Contracts
{
    public interface IDataService
    {
        IEnumerable<ICharacter> GetAllCharacters();
        ICharacter GetCharacterById(int id);

        IEnumerable<ILocation> GetAllLocations();
        ILocation GetLocationById(int id);
        
        IEnumerable<IEpisode> GetAllEpisodes();
        IEpisode GetEpisodeById(int id);
    }
}

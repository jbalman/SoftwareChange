using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Contracts
{
    public interface IQueryEvaluator
    {
        IEnumerable<ICharacter> GetCharacters(IEnumerable<Tuple<string, string, string>> queryCommands);
        IEnumerable<ILocation> GetLocations(IEnumerable<Tuple<string, string, string>> queryCommands);
        IEnumerable<IEpisode> GetEpisodes(IEnumerable<Tuple<string, string, string>> queryCommands);

    }
}

using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;

namespace RickAndMorty.Engines
{
    public class QueryEvaluator : IQueryEvaluator
    {
        IEnumerable<ICharacter> _characters;
        IEnumerable<ILocation> _locations;
        IEnumerable<IEpisode> _episodes;

        public QueryEvaluator(IEnumerable<ICharacter> Characters,
                            IEnumerable<ILocation> Locations,
                            IEnumerable<IEpisode> Episodes)
        {
            _characters = Characters;
            _locations=Locations;
            _episodes = Episodes;
        }
        public IEnumerable<ICharacter> GetCharacters(IEnumerable<Tuple<string, string, string>> queryCommands)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEpisode> GetEpisodes(IEnumerable<Tuple<string, string, string>> queryCommands)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILocation> GetLocations(IEnumerable<Tuple<string, string, string>> queryCommands)
        {
            throw new NotImplementedException();
        }
    }
}

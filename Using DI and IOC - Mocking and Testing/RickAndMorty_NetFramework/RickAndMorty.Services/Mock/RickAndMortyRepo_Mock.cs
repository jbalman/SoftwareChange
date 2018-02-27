using Contracts;
using System;

namespace Repositories
{
    class RickAndMortyRepo_Mock : IRickAndMortyRepo
    {
        public ICharacter GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        public IEpisode GetEpisodeById(int id)
        {
            throw new NotImplementedException();
        }

        public ILocation GetLocationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using Ninject.Syntax;
using RickAndMorty.Services.Data.Mock.Client;
using RickAndMorty.Services.Data.Models;
using System.Collections.Generic;

namespace RickAndMorty.Services.Data.Mock
{
    public class RickAndMortyDataService_Mock : RickAndMortyDataServiceBase
    {

        public RickAndMortyDataService_Mock(IResolutionRoot Kernel) :base(Kernel)
        {
            RickAndMortyDataService_Mock_Client _client = new RickAndMortyDataService_Mock_Client(_configurationService.GetMockJsonDataFolder());

            IEnumerable<Character> _apiCharacters = _client.GetCharacters();
            IEnumerable<Location> _apiLocations = _client.GetLocations();
            IEnumerable<Episode> _apiEpisodes = _client.GetEpisodes();

            BuildCollections(_apiCharacters, _apiLocations, _apiEpisodes);
        }
    }
}

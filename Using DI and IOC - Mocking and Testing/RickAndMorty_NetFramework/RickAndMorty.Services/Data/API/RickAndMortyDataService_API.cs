using Ninject.Syntax;
using RickAndMorty.Services.Data.Api.Client;
using RickAndMorty.Services.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Data.Api
{
    public class RickAndMortyDataService_Api : RickAndMortyDataServiceBase
    {
        public RickAndMortyDataService_Api(IResolutionRoot Kernel) : base(Kernel)
        {
            RickAndMortyDataService_API_Client _client = new RickAndMortyDataService_API_Client(_configurationService.GetRootApiUrl());

            IEnumerable<Character> _apiCharacters = null;
            IEnumerable<Location> _apiLocations = null;
            IEnumerable<Episode> _apiEpisodes = null;
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                _apiCharacters = _client.GetCharacters();
            });
            tasks[1] = Task.Run(() =>
            {
                _apiLocations = _client.GetLocations();
            });
            tasks[2] = Task.Run(() =>
            {
                _apiEpisodes = _client.GetEpisodes();
            });
            Task.WaitAll(tasks);

            BuildCollections(_apiCharacters, _apiLocations, _apiEpisodes);
        }
    }
}

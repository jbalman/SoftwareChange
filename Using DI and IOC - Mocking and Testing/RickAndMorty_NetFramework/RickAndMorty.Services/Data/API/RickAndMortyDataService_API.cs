using Ninject;
using Ninject.Syntax;
using RickAndMorty.Contracts;
using RickAndMorty.Services.Data.Api.Client;
using RickAndMorty.Services.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Data.Api
{
    public class RickAndMortyDataService_API : IDataService
    {
        public readonly List<ICharacter> Characters;
        public readonly List<IEpisode> Episodes;
        public readonly List<ILocation> Locations;

        private readonly IConfigurationService _configurationService;

        public RickAndMortyDataService_API(IResolutionRoot Kernel)
        {
            _configurationService = Kernel.Get<IConfigurationService>();
            RickAndMortyDataService_API_Client _client = new RickAndMortyDataService_API_Client(_configurationService.GetRootApiUrl());

            Characters = new List<ICharacter>();
            Episodes = new List<IEpisode>();
            Locations = new List<ILocation>();

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

            //create characters
            foreach (Character apiChr in _apiCharacters)
            {
                ICharacter chr = Kernel.Get<ICharacter>();
                Characters.Add(chr);
                chr.id = apiChr.id;
                chr.name = apiChr.name;
                chr.status = apiChr.status;
                chr.species = apiChr.species;
                chr.type = apiChr.type;
                chr.gender = apiChr.gender;
                chr.origin = Locations.FirstOrDefault(x => x.url.ToString().Equals(apiChr.origin.url));
                chr.location = Locations.FirstOrDefault(x => x.url.ToString().Equals(apiChr.location.url));
                chr.image = new Uri(apiChr.image);
                chr.episodes = null;
                chr.url = new Uri(apiChr.url);
                chr.created = DateTime.Parse(apiChr.created);
            }

            //create episodes
            foreach (Episode apiEpi in _apiEpisodes)
            {
                IEpisode epi = Kernel.Get<IEpisode>();
                Episodes.Add(epi);
                epi.id = apiEpi.id;
                epi.name = apiEpi.name;
                epi.air_date = DateTime.Parse(apiEpi.air_date);
                epi.episode = apiEpi.episode;
                epi.characters = from c in Characters
                                 from ac in apiEpi.characters
                                 where c.url.ToString().Equals(ac)
                                 select c;
                epi.url = new Uri(apiEpi.url);
                epi.created = DateTime.Parse(apiEpi.created);
            }

            //upcate character episodes
            foreach (Character apiChr in _apiCharacters)
            {
                ICharacter chr = Characters.FirstOrDefault(x => x.id.Equals(apiChr.id));
                chr.episodes = from e in Episodes
                                  from ae in apiChr.episodes
                                  where e.url.ToString().Equals(ae)
                                  select e;
            }

            //create locations
            foreach (Location apiLoc in _apiLocations)
            {
                ILocation loc = Kernel.Get<ILocation>();
                loc.id = apiLoc.id;
                loc.name = apiLoc.name;
                loc.type = apiLoc.type;
                loc.dimension = apiLoc.dimension;
                loc.residents = from c in Characters
                                from ar in apiLoc.residents
                                where c.url.ToString().Equals(ar)
                                select c;
                loc.url = new System.Uri(apiLoc.url);
                loc.created = DateTime.Parse(apiLoc.created);
                Locations.Add(loc);
            }
        }

        public ICharacter GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEpisode GetEpisodeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ILocation GetLocationById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

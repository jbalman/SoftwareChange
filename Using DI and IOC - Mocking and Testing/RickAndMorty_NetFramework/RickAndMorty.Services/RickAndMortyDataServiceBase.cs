using Ninject;
using Ninject.Syntax;
using RickAndMorty.Contracts;
using RickAndMorty.Services.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RickAndMorty.Services
{
    public abstract class RickAndMortyDataServiceBase : IDataService
    {
        protected List<ICharacter> Characters;
        protected List<IEpisode> Episodes;
        protected List<ILocation> Locations;
        protected IResolutionRoot _kernel;
        protected IConfigurationService _configurationService;

        public RickAndMortyDataServiceBase(IResolutionRoot Kernel)
        {
            _kernel = Kernel;
            _configurationService = Kernel.Get<IConfigurationService>();
            Characters = new List<ICharacter>();
            Episodes = new List<IEpisode>();
            Locations = new List<ILocation>();
        }

        public void BuildCollections(IEnumerable<Character> apiCharacters, IEnumerable<Location> apiLocations, IEnumerable<Episode> apiEpisodes)
        {
            //create characters
            foreach (Character apiChr in apiCharacters)
            {
                ICharacter chr = _kernel.Get<ICharacter>();
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
            foreach (Episode apiEpi in apiEpisodes)
            {
                IEpisode epi = _kernel.Get<IEpisode>();
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
            foreach (Character apiChr in apiCharacters)
            {
                ICharacter chr = Characters.FirstOrDefault(x => x.id.Equals(apiChr.id));
                chr.episodes = from e in Episodes
                               from ae in apiChr.episodes
                               where e.url.ToString().Equals(ae)
                               select e;
            }

            //create locations
            foreach (Location apiLoc in apiLocations)
            {
                ILocation loc = _kernel.Get<ILocation>();
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

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            return this.Characters;
        }

        public IEnumerable<IEpisode> GetAllEpisodes()
        {
            return this.Episodes;
        }

        public IEnumerable<ILocation> GetAllLocations()
        {
            return this.Locations;
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

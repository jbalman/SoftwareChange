using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using RickAndMorty.Contracts;
using RickAndMorty.Services.Configuration;
using RickAndMorty.Services.Data.Api;
using RickAndMorty.Services.Data.Api.Client;
using RickAndMorty.Services.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RickAndMorty.Tests
{
    namespace IOC
    {
        using RickAndMorty.Implementations;

        public class BindingModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IConfigurationService>().To<ConfigurationService>();
                this.Bind<ICharacter>().To<Character>();
                this.Bind<IEpisode>().To<Episode>();
                this.Bind<ILocation>().To<Location>();
                this.Bind<IDataService>().To<RickAndMortyDataService_Mock>();
            }
        }
    }

    [TestClass]
    public class RickAndMortyDataService_APIClient_Tests
    {
        private static RickAndMortyDataService_API_Client _client;
        private static StandardKernel Kernel = null;

        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            Kernel = new StandardKernel(new IOC.BindingModule());
            IConfigurationService configurationService = Kernel.Get<IConfigurationService>();
            _client = new RickAndMortyDataService_API_Client(configurationService);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            _client = null;
        }

        [TestMethod]
        public void When_GetCharacters_ShouldReturn_Characters()
        {
            IEnumerable<Character> characters = _client.GetCharacters();
            Assert.IsNotNull(characters);
            Assert.IsTrue(characters.Count() > 0);
        }

        [TestMethod]
        public void When_GetEpisodes_ShouldReturn_Episodes()
        {
            IEnumerable<Episode> episodes = _client.GetEpisodes();
            Assert.IsNotNull(episodes);
            Assert.IsTrue(episodes.Count() > 0);
        }

        [TestMethod]
        public void When_GetLocations_ShouldReturn_Locations()
        {
            IEnumerable<Location> locations = _client.GetLocations();
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Count() > 0);
        }
    }
}


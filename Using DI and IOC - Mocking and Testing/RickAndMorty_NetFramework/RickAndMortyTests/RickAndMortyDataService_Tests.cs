using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using RickAndMorty.Contracts;
using RickAndMorty.Services.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RickAndMorty.Tests
{
    namespace IOC
    {
        using RickAndMorty.Implementations;
        using RickAndMorty.Services.Data.Api;
        using RickAndMorty.Services.Data.Mock;

        public class BindingModule : NinjectModule
        {
            private readonly string _testDir=null;

            public BindingModule()
            { }
            public BindingModule(string TestDir)
            {
                _testDir = TestDir;
            }

            public override void Load()
            {
                this.Bind<IConfigurationService>().ToMethod(c=>
                {
                    return new ConfigurationService(string.Empty, _testDir);
                });
                this.Bind<ICharacter>().To<Character>();
                this.Bind<IEpisode>().To<Episode>();
                this.Bind<ILocation>().To<Location>();
                this.Bind<IDataService>().To<RickAndMortyDataService_Api>();
                this.Bind<IDataService>().To<RickAndMortyDataService_Mock>();
            }
        }
    }

    [TestClass]
    public class RickAndMortyDataService_Tests
    {
        private static IEnumerable<IDataService> _dataServices;
        private static StandardKernel _kernel = null;
        private static TestContext _ctx = null;

        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            _ctx = ctx;
            string _mockJsonDataFolder = _ctx.TestDir;
            _mockJsonDataFolder = Path.GetFullPath(Path.Combine("..", "..","..","RickAndMorty.Services","Data","Mock","Client"));
            _kernel = new StandardKernel(new IOC.BindingModule(_mockJsonDataFolder));
            _dataServices = _kernel.GetAll<IDataService>();
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
        }

        [TestMethod]
        public void When_GetCharacters_ShouldReturn_Characters()
        {
            foreach (IDataService svc in _dataServices)
            {
                string message = $"Testing When_GetCharacters_ShouldReturn_Characters with DataService {svc.GetType()}";
                _ctx.WriteLine($"Start: {message}");
                IEnumerable<ICharacter> characters = svc.GetAllCharacters();
                Assert.IsNotNull(characters, $"Failed: {message}");
                Assert.IsTrue(characters.Count() == 0, $"Failed: {message}");
            }
        }

        [TestMethod]
        public void When_GetEpisodes_ShouldReturn_Episodes()
        {
            foreach (IDataService svc in _dataServices)
            {
                string message=$"Testing When_GetEpisodes_ShouldReturn_Episodes with DataService {svc.GetType()}";
                _ctx.WriteLine($"Start: {message}");
                IEnumerable<IEpisode> episodes = svc.GetAllEpisodes();
                Assert.IsNotNull(episodes, $"Failed: {message}");
                Assert.IsTrue(episodes.Count() > 0, $"Failed: {message}");
            }
        }

        [TestMethod]
        public void When_GetLocations_ShouldReturn_Locations()
        {
            foreach (IDataService svc in _dataServices)
            {
                string message=$"TestingWhen_GetLocations_ShouldReturn_Locations with DataService {svc.GetType()}";
                _ctx.WriteLine($"Start: {message}");
                IEnumerable<ILocation> locations = svc.GetAllLocations();
                Assert.IsNotNull(locations, $"Failed: {message}");
                Assert.IsTrue(locations.Count() > 0, $"Failed: {message}");
            }
        }
    }
}


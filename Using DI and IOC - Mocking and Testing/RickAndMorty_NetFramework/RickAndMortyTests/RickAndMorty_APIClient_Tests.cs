using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Repositories.API;
using System.Collections.Generic;
using System.Linq;

namespace RickAndMortyTests
{
    [TestClass]
    public class RickAndMorty_APIClient_Tests
    {
        private static RickAndMorty_APIClient _client;
        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            _client = new RickAndMorty_APIClient();
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            _client = null;
        }

        [TestMethod]
        public void When_GetResources_ShouldReturn_Resources()
        {
            Resources actual = _client.GetResources();
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.characters));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.locations));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.episodes));
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


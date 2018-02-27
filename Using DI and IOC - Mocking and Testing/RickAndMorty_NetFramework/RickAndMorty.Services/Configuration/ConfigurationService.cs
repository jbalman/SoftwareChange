using RickAndMorty.Contracts;
using System.Diagnostics;
using System.IO;

namespace RickAndMorty.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private string _rootApiUrl;
        private string _mockJsonDataFolder;

        public ConfigurationService(string RootApiUrl, string MockJsonDatafolder)
        {
            _rootApiUrl = RootApiUrl;
            _mockJsonDataFolder = MockJsonDatafolder;
        }

        public string GetMockJsonDataFolder()
        {
            if (string.IsNullOrWhiteSpace(_mockJsonDataFolder))
            {
                _mockJsonDataFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                _mockJsonDataFolder = Path.Combine(_mockJsonDataFolder, "data", "mock", "client");
            }
            return _mockJsonDataFolder;
        }


        public string GetRootApiUrl()
        {
            if (string.IsNullOrWhiteSpace(_rootApiUrl))
            {
                _rootApiUrl= "https://rickandmortyapi.com/api";
            }
            return _rootApiUrl;
        }
    }
}

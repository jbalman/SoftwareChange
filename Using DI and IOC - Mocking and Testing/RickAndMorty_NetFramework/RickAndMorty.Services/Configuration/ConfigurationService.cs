using RickAndMorty.Contracts;
using System.Diagnostics;
using System.IO;

namespace RickAndMorty.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetMockJsonDataFolder()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }


        public string GetRootApiUrl()
        {
            return "https://rickandmortyapi.com/api";
        }
    }
}

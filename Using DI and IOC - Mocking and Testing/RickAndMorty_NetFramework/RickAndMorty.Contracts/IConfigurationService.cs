namespace RickAndMorty.Contracts
{
    public interface IConfigurationService
    {
        string GetRootApiUrl();
        string GetMockJsonDataFolder();
    }
}

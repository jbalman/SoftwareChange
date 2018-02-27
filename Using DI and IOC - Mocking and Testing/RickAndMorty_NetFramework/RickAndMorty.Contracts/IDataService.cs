namespace RickAndMorty.Contracts
{
    public interface IDataService
    {
        ICharacter GetCharacterById(int id);
        ILocation GetLocationById(int id);
        IEpisode GetEpisodeById(int id);
    }
}

using Ninject.Modules;
using RickAndMorty.Contracts;
using RickAndMorty.Implementations;
using RickAndMorty.Services.Configuration;
using RickAndMorty.Services.Data.Mock;

namespace RickAndMorty
{
    public class BindingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationService>().To<ConfigurationService>();
            this.Bind<ICharacter>().To<Character>();
            this.Bind<IEpisode>().To<Episode>();
            this.Bind<ILocation>().To<Location>();
            this.Bind<IQueryParser>().To<IQueryParser>();
            this.Bind<IQueryEvaluator>().To<IQueryEvaluator>();
            this.Bind<IDataService>().To<RickAndMortyDataService_Mock>();
        }
    }
}

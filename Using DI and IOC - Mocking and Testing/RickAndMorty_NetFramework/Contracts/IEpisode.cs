using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEpisode
    {
        int id { get; set; }
        string name { get; set; }
        DateTime air_date { get; set; }
        string episode_code { get; set; }
        IEnumerable<ICharacter> characters { get; set; }
        IEnumerable<IEpisode> episodes { get; set; }
        DateTime created { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICharacter
    {
        int id { get; set; }
        string name { get; set; }
        string status { get; set; }
        string species { get; set; }
        string type { get; set; }
        string gender { get; set; }
        IOrigin origin { get; set; }
        ILocation location { get; set; }
        Uri image { get; set; }
        IEnumerable<IEpisode> episodes { get; set; }
        Uri url { get; set; }
        DateTime created { get; set; }
    }
}

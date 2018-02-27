using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ILocation
    {
        int id { get; set; }
        string name { get; set; }
        string type { get; set; }
        string dimension { get; set; }
        IEnumerable<ICharacter> residents { get; set; }
        Uri url { get; set; }
        DateTime created { get; set; }
    }
}

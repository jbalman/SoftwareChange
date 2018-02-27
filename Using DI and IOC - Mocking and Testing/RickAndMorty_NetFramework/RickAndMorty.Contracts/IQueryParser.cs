using System;
using System.Collections.Generic;

namespace RickAndMorty.Contracts
{
    public interface IQueryParser
    {
        IEnumerable<Tuple<string, string, string>> ParseQuery(string query);
    }
}

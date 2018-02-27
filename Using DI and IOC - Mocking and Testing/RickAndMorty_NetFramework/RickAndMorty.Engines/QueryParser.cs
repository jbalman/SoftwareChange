using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RickAndMorty.Engines
{
    public class QueryParser : IQueryParser
    {
        public IEnumerable<Tuple<string, string, string>> ParseQuery(string query)
        {
            IEnumerable<string> commands = from c in  query.Split(',')
                                           select c.Trim(' ');
            IEnumerable<Tuple<string, string, string>> results = from c in commands
                                                                    select new Tuple<string, string, string>
                                                                    (
                                                                        c.Split('=')[0].Split('.')[0],
                                                                        c.Split('=')[0].Split('.')[1],
                                                                        c.Split('=')[1]
                                                                    );
            return results;
        }
    }
}

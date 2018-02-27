using System;
using System.Collections.Generic;

namespace Repositories.API
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimension { get; set; }
        public IEnumerable<string> residents { get; set; }
        public string url { get; set; }
        public string created { get; set; }
    }
}

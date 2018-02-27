using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.API
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; }
        string air_date { get; set; }
        string episode { get; set; }
        List<string> characters { get; set; }
        List<string> url { get; set; }
        string created { get; set; }
    }
}

using System.Collections.Generic;

namespace Repositories.API
{
    public class Results<T>
    {
        public Info info { get; set; }
        public List<T> results { get; set; }
    }
}

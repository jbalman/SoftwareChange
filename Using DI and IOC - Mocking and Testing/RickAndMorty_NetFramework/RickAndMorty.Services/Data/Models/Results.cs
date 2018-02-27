using System.Collections.Generic;

namespace RickAndMorty.Services.Data.Models
{
    public class Results<T>
    {
        public Info info { get; set; }
        public List<T> results { get; set; }
    }
}

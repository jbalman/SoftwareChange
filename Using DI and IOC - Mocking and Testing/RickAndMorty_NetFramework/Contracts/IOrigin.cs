using System;

namespace Contracts
{
    public interface IOrigin
    {
        string name { get; set; }
        Uri url { get; set; }
    }
}

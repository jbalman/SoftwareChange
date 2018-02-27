using Ninject;
using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel Kernel = new StandardKernel(new BindingModule());
            IDataService svc = Kernel.Get<IDataService>();
            bool keepLooping= true;
            while (keepLooping)
            {
                Console.WriteLine("Enter Query:");
                string query = Console.ReadLine();
            }
        }
    }
}

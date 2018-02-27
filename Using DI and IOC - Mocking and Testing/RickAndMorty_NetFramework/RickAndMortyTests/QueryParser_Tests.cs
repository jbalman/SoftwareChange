using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using RickAndMorty.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RickAndMorty.Tests.QueryParser
{
    namespace IOC
    {
        public class BindingModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IQueryParser>().To<Engines.QueryParser>();
            }
        }

    }

    [TestClass]
    public class QueryParser_Tests
    {
        private static StandardKernel _kernel = null;
        private static TestContext _ctx = null;

        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            _ctx = ctx;
            string _mockJsonDataFolder = _ctx.TestDir;
            _kernel = new StandardKernel(new IOC.BindingModule());
        }

        [TestMethod]
        public void Given_Query_When_ParseQuery_ShouldReturn_3TupleOfCommandAttributes()
        {
            foreach (IQueryParser parser in _kernel.GetAll<IQueryParser>())
            {
                string message = $"Testing Given_Query_When_ParseQuery_ShouldReturn_3TupleOfCommandAttributes with IQueryParser {parser.GetType()}";
                _ctx.WriteLine($"Start: {message}");
                IEnumerable<Tuple<string, string, string>> commands = parser.ParseQuery("type1.property1=value1, type2.property2=value2");
                Assert.IsTrue(commands.Count() == 2);
                Tuple<string, string, string> cmd;
                cmd = commands.FirstOrDefault();
                Assert.IsNotNull(cmd);
                Assert.IsTrue(cmd.Item1.Equals("type1"));
                Assert.IsTrue(cmd.Item2.Equals("property1"));
                Assert.IsTrue(cmd.Item3.Equals("value1"));
                cmd = commands.Skip(1).FirstOrDefault();
                Assert.IsNotNull(cmd);
                Assert.IsTrue(cmd.Item1.Equals("type2"));
                Assert.IsTrue(cmd.Item2.Equals("property2"));
                Assert.IsTrue(cmd.Item3.Equals("value2"));
            }
        }
    }
}

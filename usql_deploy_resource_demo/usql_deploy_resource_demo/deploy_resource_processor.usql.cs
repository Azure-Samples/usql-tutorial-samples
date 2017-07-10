using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demo
{
    [SqlUserDefinedProcessor]
    public class HelloWorldProcessor : IProcessor
    {
        private string hw;

        public HelloWorldProcessor()
        {
            this.hw = System.IO.File.ReadAllText("helloworld.txt");
        }

        public override IRow Process(IRow input, IUpdatableRow output)
        {
            output.Set<int>("DepID", input.Get<int>("DepID"));
            output.Set<string>("DepName", input.Get<string>("DepName"));
            output.Set<string>("HelloWorld", hw);
            return output.AsReadOnly();
        }
    }
}

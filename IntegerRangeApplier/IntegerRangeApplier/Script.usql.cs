using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demo
{

    [SqlUserDefinedApplier]
    public class IntegerRangeApplier : IApplier
    {
        private int Start;
        private int End;

        public IntegerRangeApplier(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public override IEnumerable<IRow> Apply(IRow input, IUpdatableRow output)
        {
            for (int i = this.Start; i <= this.End; i++)
            {
                output.Set<int>("Value", i);
                yield return output.AsReadOnly();
            }
        }
    }
}

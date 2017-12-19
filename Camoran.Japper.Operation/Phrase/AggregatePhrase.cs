using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class AggregatePhrase : SelectPhrase
    {

        public AggregateType AggregateType { get; }

        public AggregatePhrase(string name, string alias,string table,AggregateType aggregateType)
            :base(name,alias,table)
        {
            AggregateType = aggregateType;
        }

    }

}

//select a.b , sum(a.c) ,a.d from a 

using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class OrderPhrase : SelectPhrase
    {

        public OrderType OrderType { get; }

        public OrderPhrase(string name, string table, OrderType orderType)
            :this(name,table,null, orderType)
        {

        }

        public OrderPhrase(string name,string table, string alias,OrderType orderType)
            : base(name, alias)
        {
            OrderType = orderType;
        }

    }

}


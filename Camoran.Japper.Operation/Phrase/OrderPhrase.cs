using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public abstract class OrderPhrase : SelectPhrase
    {

        public OrderType Asc;

        public OrderPhrase(string name, string alias, string table)
            :base(name,alias)
        {

        }

    }

}


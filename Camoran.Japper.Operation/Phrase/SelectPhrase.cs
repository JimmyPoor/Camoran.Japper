using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class SelectPhrase : SqlPhrase
    {

        public string Alias { get; protected set; }
        public string TableName { get; set; }

        public SelectPhrase(string name, string table)
           : this(name, table, null) { }

        public SelectPhrase(string name, string table,string alias)
            : base(name) { }

    }

}


using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class SelectPhrase : SqlPhrase
    {

        public string Alias { get; protected set; }
        public string TableName { get; set; }

        public SelectPhrase(string name, string alias,string table)
            :base(name)
        {

        }

    }

}

//select a.b , sum(a.c) ,a.d from a 

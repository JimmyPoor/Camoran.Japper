using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class SelectPhrase : SqlPhrase
    {

        public string Alias { get; }
        public string TableName { get; }
        public SelectType SType { get; }

        public SelectPhrase(string name, string table)
           : this(name, table, null) { }

        public SelectPhrase(string name, string table,string alias)
            : this(name,table,alias, SelectType.Normal)
        {
           
        }

        public SelectPhrase(string name, string table, string alias,SelectType selectType)
           : base(name)
        {
            TableName = TableName;
            Alias = alias;
            SType = selectType;
        }

    }


    public class GroupPhrase : SelectPhrase
    {
        public GroupPhrase(string name,string table) : base(name,table) { }
    }

}


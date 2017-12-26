using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class FromPhrase : SqlPhrase
    {

        public string TableName { get; protected set; }
        public string Alias { get; protected set; }

        public FromPhrase(string tableName) : base(tableName) { }

        public FromPhrase(ITable table) : this(table.TableName)
        {
            this._table = table;
        }

        private ITable _table;

    }

    public class JoinPhrase : FromPhrase
    {

        public JoinType JoinType { get; }
        public WherePhrase WherePhrase { get; }

        public JoinPhrase(string table, JoinType joinType, WherePhrase wherePhrase)
            : base(table)
        {
            JoinType = joinType;
            WherePhrase = wherePhrase;
        }

    }

}

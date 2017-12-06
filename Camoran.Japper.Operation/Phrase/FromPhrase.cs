using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class FromPhrase : SqlPhrase
    {
        public string TableName { get; protected set; }
        public string Alias { get; protected set; }

        public FromPhrase() {}
        
        public FromPhrase(ITable table)
        {
            this._table = table;
        }

        private ITable _table;  
    }

}

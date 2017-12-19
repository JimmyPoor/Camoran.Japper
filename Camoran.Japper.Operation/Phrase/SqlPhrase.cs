using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public abstract class SqlPhrase : ISqlPhrase
    {

        public string Name { get; protected set; }

        public ISqlPhrase Next { get; protected set; }

        public SqlPhrase(string name)
        {
            Name = name;
        }

        public virtual void SetNext(ISqlPhrase phrase)
        {
            if (phrase != null)
                Next = phrase;
        }

    }

}


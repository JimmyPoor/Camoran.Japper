using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{
    public class SqlPhrase : ISqlPhrase
    {
        public string Name => throw new NotImplementedException();

        public ISqlPhrase Next => throw new NotImplementedException();

        public void SetNext(ISqlPhrase phrase)
        {
            throw new NotImplementedException();
        }

        public void SetNext(IEnumerable<ISqlPhrase> phrases)
        {
            throw new NotImplementedException();
        }
    }
}

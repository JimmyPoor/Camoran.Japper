using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper
{
    /// <summary>
    /// ISqlPhrase means the elements for sql operation 
    /// for example: from(phrase)
    /// </summary>
    public interface ISqlPhrase
    {
        string Name { get; }
        ISqlPhrase Next { get; }
        void SetNext(ISqlPhrase phrase);
        void SetNext(IEnumerable<ISqlPhrase> phrases);
    }
}

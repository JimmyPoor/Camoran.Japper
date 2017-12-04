using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Phrase
{

    public class WherePhrase : SqlPhrase
    {
        public string Name => throw new NotImplementedException();

        public static bool operator &(WherePhrase left, WherePhrase right)
        {
            return true;
        }

        public static bool operator |(WherePhrase left, WherePhrase right)
        {
            return true;
        }
    }

}


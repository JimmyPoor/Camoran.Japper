using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class WherePhrase : SqlPhrase
    {
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


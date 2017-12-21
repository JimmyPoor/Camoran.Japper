using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper
{

    public interface ISqlParser
    {
        string ParseToSql(ISqlPhrase[] phrase);
    }

}

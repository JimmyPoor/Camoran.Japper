using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper
{
    public interface ISqlOperation
    {
        ISqlOperation Parent { get; }
    }

    public interface ISqlTranslator<operation> where operation:ISqlOperation 
    {
        string SqlTranslate(operation operation);
    }

}

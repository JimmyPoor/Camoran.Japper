using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper
{
    public interface ITransaction
    {
        void BeginTran();
        void Commit();
        void RollBack();
    }
}

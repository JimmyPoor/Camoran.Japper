using System;
using System.Collections.Generic;

namespace Camoran.Japper.Operation.SqlServer
{

    public class SqlServerDbProvider : IDbProvider
    {

        public int ExcuteSelectCount(string sql, params string[] paras)
        {
            throw new NotImplementedException();
        }

        public int ExecutNonQuery(string sql, params string[] paras)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, params string[] paras)
        {
            throw new NotImplementedException();
        }

    }

}

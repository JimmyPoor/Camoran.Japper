using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper
{
    public interface IDbProvider
    {
        int ExecutNonQuery(string sql, params string[] paras);
        IEnumerable<T> Query<T>(string sql,params string[] paras);
        int ExcuteSelectCount(string sql, params string[] paras);
    }
}

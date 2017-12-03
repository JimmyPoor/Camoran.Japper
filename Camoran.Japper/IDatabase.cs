using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Camoran.Japper
{

    public interface IDatabase : ITransaction
    {
        IDbConnection DBconnection { get; }
        IDbProvider Provider { get; }
    }

    public interface ITable
    {
        string TableName { get; }
        string Alias { get; }
    }

    public interface IColumn<T> where T : struct
    {
        string ColumnName { get; }
        bool IsNullable { get; }
        string DisplayName { get; }
        T ColumnType { get; }
        bool IsRequired { get; }
        long Length { get; }
        bool IsIdentity { get; }
        int IdenetityStep { get; }
        //Table TabelDefintion
    }

}

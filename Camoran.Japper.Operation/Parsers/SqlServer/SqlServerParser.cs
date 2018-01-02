using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation.SqlServer
{

    public class SqlServerSearchParser : ISqlParser
    {

        IList<SelectPhrase> _selectPhrases;
        IList<WherePhrase> _wherePhrases;
        IList<JoinPhrase> _joinPhrases;
        IList<FromPhrase> _fromPhrases;
        IList<ConditionPhrase> _conditionPhrases;
        static StringBuilder _sb;
        static string _resutStr => _sb.ToString();

        public SqlServerSearchParser()
        {
            _sb = new StringBuilder();
        }

        public string ParseToSql(ISqlPhrase[] phrase)
        {
            foreach (var item in phrase)
            {
                AddToList(item);
            }

            ParseSelectPhrase(_selectPhrases);

            ParseFromPhrase(_fromPhrases);

            ParseWherePhrase(_wherePhrases);

            return _sb.ToString();
        }

        private void ParseSelectPhrase(IList<SelectPhrase> pharse)
        {
            // select a.c,a.b,max(a.d),min(),average()
            _sb.Append(SQL_SERVER_KEYWORD.Select);
            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);

            foreach (var item in pharse)
            {
                if (item is AggregatePhrase)
                {
                    _sb.Append((item as AggregatePhrase).AggregateType);
                }

                _sb.Append(SQL_SERVER_KEYWORD.LP);
                _sb.Append(SQL_SERVER_KEYWORD.LPS);
                _sb.Append(item.TableName);
                _sb.Append(SQL_SERVER_KEYWORD.Dot);
                _sb.Append(item.Name);
                _sb.Append(SQL_SERVER_KEYWORD.RPS);
                _sb.Append(SQL_SERVER_KEYWORD.RP);

                if (!string.IsNullOrEmpty(item.Alias))
                {
                    _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                    _sb.Append(SQL_SERVER_KEYWORD.Alias);
                }

                var splitChar = (item.Next is FromPhrase) ? SQL_SERVER_KEYWORD.WhiteSpace : SQL_SERVER_KEYWORD.Comma;
                _sb.Append(splitChar);
            }

        }

        private void ParseFromPhrase(IList<FromPhrase> pharse)
        {
            _sb.Append(SQL_SERVER_KEYWORD.From);
            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);

            foreach (var item in pharse)
            {
                _sb.Append(item.TableName);
                _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);

                if (item is JoinPhrase)
                {
                    var joinPhrase = item as JoinPhrase;
                    //_sb.Append((item as JoinType).);
                    _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                    _sb.Append(SQL_SERVER_KEYWORD.On);
                   // _sb.Append();
                }
            }
            //select * from a,b join b on a.1 = b.1
        }

        private void ParseWherePhrase(IList<WherePhrase> pharse)
        {
        }

        private void AddToList(ISqlPhrase phrase)
        {
            if (phrase is SelectPhrase)
            {
                _selectPhrases.Add(phrase as SelectPhrase);
            }
            else if (phrase is JoinPhrase)
            {
                _joinPhrases.Add(phrase as JoinPhrase);
            }
            else if (phrase is FromPhrase)
            {
                _fromPhrases.Add(phrase as FromPhrase);
            }
            else if (phrase is ConditionPhrase)
            {
                _wherePhrases.Add(phrase as ConditionPhrase);
            }
            else if (phrase is WherePhrase)
            {
                _wherePhrases.Add(phrase as WherePhrase);
            }

        }

    }

    public class SqlServerCommandParser : ISqlParser
    {
        public string ParseToSql(ISqlPhrase[] phrase)
        {
            throw new NotImplementedException();
        }
    }

    public static class SQL_SERVER_KEYWORD
    {
        public static string Select = "select";
        public static string From = "from";
        public static string WhiteSpace = " ";
        public static string Alias = "as";
        public static string Comma = ",";
        public static string Dot = ".";
        public static string LP = "(";
        public static string RP = ")";
        public static string LPS = "[";
        public static string RPS = "]";
        public static string On = "on";
    }

}

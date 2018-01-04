using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation.SqlServer
{

    public class SqlServerSearchParser : ISqlParser
    {

        static StringBuilder _sb;
        static string _resutStr => _sb.ToString();

        public SqlServerSearchParser()
        {
            _sb = new StringBuilder();
        }

        public string ParseToSql(ISqlPhrase phrase)
        {
            _sb.Append(SQL_SERVER_KEYWORD.Select);

            while (null != phrase)
            {
                if (phrase is SelectPhrase)
                {
                    ParseSelectPhrase(phrase as SelectPhrase);
                }
                else if (phrase is FromPhrase)
                {
                    ParseFromPhrase(phrase as FromPhrase);
                }
                else if (phrase is WherePhrase)
                {
                    ParseWherePhrase(phrase as WherePhrase);
                }

                phrase = phrase.Next;
            }

            return _sb.ToString();
        }

        private void ParseSelectPhrase(SelectPhrase pharse)
        {
            if (pharse is AggregatePhrase)
            {
                _sb.Append((pharse as AggregatePhrase).AggregateType);
            }

            _sb.Append(SQL_SERVER_KEYWORD.LP);
            _sb.Append(SQL_SERVER_KEYWORD.LPS);
            _sb.Append(pharse.TableName);
            _sb.Append(SQL_SERVER_KEYWORD.Dot);
            _sb.Append(pharse.Name);
            _sb.Append(SQL_SERVER_KEYWORD.RPS);
            _sb.Append(SQL_SERVER_KEYWORD.RP);

            if (!string.IsNullOrEmpty(pharse.Alias))
            {
                _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                _sb.Append(SQL_SERVER_KEYWORD.Alias);
            }

            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
            var splitChar = (pharse.Next is FromPhrase) ? SQL_SERVER_KEYWORD.WhiteSpace : SQL_SERVER_KEYWORD.Comma;
            _sb.Append(splitChar);
        }

        private void ParseFromPhrase(FromPhrase pharse)
        {
            if (pharse is JoinPhrase)
            {
                var joinPhrase = pharse as JoinPhrase;

                _sb.Append(SQL_SERVER_KEYWORD.Join);
                _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                _sb.Append(pharse.TableName);
                _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                _sb.Append(SQL_SERVER_KEYWORD.On);
            }
            else
            {
                _sb.Append(SQL_SERVER_KEYWORD.From);
                _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
                _sb.Append(pharse.TableName);
            }

            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
        }

        private void ParseWherePhrase(WherePhrase phrase)
        {
            var phraseIsOnlyWherePhrase = !(phrase is AndPhrase) && !(phrase is OrPhrase) && !(phrase is ConditionPhrase);
            if (phraseIsOnlyWherePhrase)
            {
                _sb.Append(SQL_SERVER_KEYWORD.Where);
            }
            else if (phrase is AndPhrase)
            {
                _sb.Append(SQL_SERVER_KEYWORD.And);
            }
            else if (phrase is OrPhrase)
            {
                _sb.Append(SQL_SERVER_KEYWORD.Or);
            }
            else if (phrase is ConditionPhrase)
            {
                var conditionPhrase = phrase as ConditionPhrase;
                ParseConditionPhrase(conditionPhrase);
            }

            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
        }

        private void ParseConditionPhrase(ConditionPhrase Phrase)
        {
            _sb.Append(Phrase.Param);
            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);

            switch (Phrase.OperatorType)
            {
                case OperatorType.Equal: _sb.Append(SQL_SERVER_KEYWORD.Equal); break;
                case OperatorType.NotEqual: _sb.Append(SQL_SERVER_KEYWORD.NotEqual); break;
                case OperatorType.In: _sb.Append(SQL_SERVER_KEYWORD.Equal); break;
                case OperatorType.NotIn: _sb.Append(SQL_SERVER_KEYWORD.Equal); break;
                case OperatorType.Between: _sb.Append(SQL_SERVER_KEYWORD.Equal); break;
                case OperatorType.NotBetween: _sb.Append(SQL_SERVER_KEYWORD.Equal); break;
                case OperatorType.LessThan: _sb.Append(SQL_SERVER_KEYWORD.LessThan); break;
                case OperatorType.LessThanOrEqual: _sb.Append(SQL_SERVER_KEYWORD.LessThanOrEqual); break;
                case OperatorType.MoreThan: _sb.Append(SQL_SERVER_KEYWORD.MoreThan); break;
                case OperatorType.MoreThanOrEqual: _sb.Append(SQL_SERVER_KEYWORD.MoreThanOrEqual); break;
            }

            _sb.Append(Phrase.Value);
            _sb.Append(SQL_SERVER_KEYWORD.WhiteSpace);
        }

        private void ParseOrderPhrase(OrderPhrase phrase) { }

        private void ParseGroupPhrase(GroupPhrase phrase) { }

    }


    public class SqlServerCommandParser : ISqlParser
    {
        public string ParseToSql(ISqlPhrase phrase)
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
        public static string Join = "join";
        public static string Equal = "=";
        public static string NotEqual = "<>";
        public static string In = "in";
        public static string NotIn = "NotIn";
        public static string LessThan = "<";
        public static string LessThanOrEqual = "<=";
        public static string MoreThan = ">";
        public static string MoreThanOrEqual = ">=";
        public static string And = "and";
        public static string Or = "or";
        public static string Where = "where";
        public static string Order_by = "order by";
        public static string Group_by= "group by";
    }

}

using System;
using System.Collections.Generic;

namespace Camoran.Japper.Operation.SqlServer
{

    public class SqlServerSearchParser : ISqlParser
    {

        //Dictionary<string, Func<SqlPhrase[], string>> _dic =new Dictionary<string, Func<SqlPhrase[], string>> {
        //    {"Select",(pharse)=>ParseSelectPhrase(pharse)}
        //};

        List<SelectPhrase> _selectPhrases;
      

        public string ParseToSql(ISqlPhrase[] phrase)
        {
          
            return string.Empty;
        }

        private static string ParseSelectPhrase(SelectPhrase[] pharse)
        {
            return string.Empty;
        }

        private void AddToList(ISqlPhrase phrase)
        {
           if(phrase is SelectPhrase)
            {
                _selectPhrases.Add(phrase as SelectPhrase);
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

}

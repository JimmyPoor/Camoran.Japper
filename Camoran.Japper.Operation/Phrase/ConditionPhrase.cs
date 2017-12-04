using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Phrase
{

    public class ConditionPhrase : WherePhrase
    {
        public object Value { get; }
        public string Param { get; }
        public ConditionOperator ConditionOperator { get; }

        public ConditionPhrase(string param, object value)
        {
            Value = value;
            Param = param;
        }

        public ConditionPhrase(ConditionOperator conditionOperator,string para,object value)
        {
            ConditionOperator = conditionOperator;
            Value = value;
        }

        public static AndPhrase operator &(ConditionPhrase left, WherePhrase right)
        {
            return new AndPhrase();
        }

        public static OrPhrase operator |(ConditionPhrase left, WherePhrase right)
        {
            return new OrPhrase();
        }

        public static ConditionPhrase operator !(ConditionPhrase left)
        {
            return new ConditionPhrase("","");
        }


    }


    public class AndPhrase : WherePhrase
    {

    }


    public class OrPhrase : WherePhrase
    {

    }


}

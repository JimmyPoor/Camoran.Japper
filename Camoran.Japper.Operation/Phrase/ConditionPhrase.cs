using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class ConditionPhrase : WherePhrase
    {
        public object Value { get; }
        public string Param { get; }
        public OperateExpression OperateExp { get; }
        public OperatorType OperatorType { get; }

        public ConditionPhrase(OperateExpression OperateExp, OperatorType operatorType, object value)
            :this(OperateExp, operatorType,null,value)
        {
        }

        public ConditionPhrase(OperateExpression operateExp, OperatorType operatorType,string param,object value)
        {
            Value = value;
            Param = param;
            OperateExp = OperateExp;
            OperatorType = operatorType;
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
            return new ConditionPhrase(null, left.OperatorType, "", "");
        }

        public AndPhrase And(WherePhrase right)
        {
            return new AndPhrase();
        }

        public AndPhrase Or(WherePhrase right)
        {
            return new AndPhrase();
        }

        
    }


    public class AndPhrase : WherePhrase
    {

    }


    public class OrPhrase : WherePhrase
    {

    }


}

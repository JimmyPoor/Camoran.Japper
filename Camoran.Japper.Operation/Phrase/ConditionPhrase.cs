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
        public object[] Values { get; }

        public ConditionPhrase(OperateExpression OperateExp, OperatorType operatorType, object value)
            : this(OperateExp, operatorType, null, value)
        {
        }

        public ConditionPhrase(OperateExpression OperateExp, OperatorType operatorType, params object[] values)
          : this(OperateExp, operatorType, null, values)
        {
        }

        public ConditionPhrase(OperateExpression operateExp, OperatorType operatorType, string param, object value) : base(param)
        {
            Value = value;
            Param = param;
            OperateExp = OperateExp;
            OperatorType = operatorType;
        }

        public ConditionPhrase(OperateExpression operateExp, OperatorType operatorType, string param, params object[] values) : base(param)
        {
            Values = values;
            Param = param;
            OperateExp = OperateExp;
            OperatorType = operatorType;
        }

        public static AndPhrase operator &(ConditionPhrase left, WherePhrase right)
        {
            return new AndPhrase(left, right);
        }

        public static OrPhrase operator |(ConditionPhrase left, WherePhrase right)
        {
            return new OrPhrase(left, right);
        }

        public static ConditionPhrase operator !(ConditionPhrase left)
        {
            return new ConditionPhrase(null, left.OperatorType, "", "");
        }

        public AndPhrase And(WherePhrase right)
        {
            return new AndPhrase(this, right);
        }

        public OrPhrase Or(WherePhrase right)
        {
            return new OrPhrase(this, right);
        }

    }


    public class AndPhrase : WherePhrase
    {

        private WherePhrase _left;
        private WherePhrase _right;

        public AndPhrase(WherePhrase left, WherePhrase right) : base(null)
        {
            _left = left;
            _right = right;

            _left.SetNext(_right);
        }

        public static AndPhrase operator &(AndPhrase left, WherePhrase right)
        {
            return new AndPhrase(left, right);
        }

        public static OrPhrase operator |(AndPhrase left, WherePhrase right)
        {
            return new OrPhrase(left, right);
        }

    }


    public class OrPhrase : WherePhrase
    {

        private WherePhrase _left;
        private WherePhrase _right;

        public OrPhrase(WherePhrase left, WherePhrase right) : base(null)
        {
            _left = left;
            _right = right;

            _left.SetNext(_right);
        }

        public static AndPhrase operator &(OrPhrase left, WherePhrase right)
        {
            return new AndPhrase(left, right);
        }

        public static OrPhrase operator |(OrPhrase left, WherePhrase right)
        {
            return new OrPhrase(left, right);
        }

    }

}

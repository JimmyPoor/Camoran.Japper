using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class OperateExpression
    {
        //NotIn(SelectOperation select):ConditonPhrase
        //NotIn(Array array):ConditonPhrase
        //In(SelectOperation select)):ConditonPhrase
        //In(Array array):ConditonPhrase
        //NotBetween(Object, Object):ConditonPhrase
        //NotBetween<T>(T t1, T t2):ConditonPhrase
        //Between<T>(T t1, T t2):ConditonPhrase
        //Between(Object, Object)::ConditonPhrase
        //< > <= >= != ==

        public string Param { get; set; }

        #region  [ operator with value ]

        public static ConditionPhrase operator ==(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.Equal, left.Param, right);
        }

        public static ConditionPhrase operator !=(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.NotEqual, left.Param, right);
        }

        public static ConditionPhrase operator >(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.MoreThan, left.Param, right);
        }

        public static ConditionPhrase operator <(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.LessThan, left.Param, right);
        }

        public static ConditionPhrase operator >=(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.MoreThanOrEqual, left.Param, right);
        }

        public static ConditionPhrase operator <=(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.LessThanOrEqual, left.Param, right);
        }

        #endregion

        #region [ operator with expresson ]

        public static ConditionPhrase operator ==(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.Equal,right);
        }

        public static ConditionPhrase operator !=(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.NotEqual, right);
        }

        public static ConditionPhrase operator >(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.MoreThan, right);
        }

        public static ConditionPhrase operator <(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.LessThan, right);
        }

        public static ConditionPhrase operator >=(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.MoreThanOrEqual, right);
        }

        public static ConditionPhrase operator <=(OperateExpression left, OperateExpression right)
        {
            return new ConditionPhrase(left, OperatorType.LessThanOrEqual, right);
        }

        #endregion

        public ConditionPhrase In(SelectOperation operation)
        {
            return new ConditionPhrase(this, OperatorType.In, operation);
        }

        public ConditionPhrase NotIn(SelectOperation operation)
        {
            return new ConditionPhrase(this, OperatorType.NotIn, operation);
        }


        #region  [ operator method with value ]

        public ConditionPhrase In(Array array)
        {
            return new ConditionPhrase(this, OperatorType.In, array);
        }

        public ConditionPhrase NotIn(Array array)
        {
            return new ConditionPhrase(this, OperatorType.NotIn, array);
        }

        public ConditionPhrase Between(object left, object right)
        {
            return new ConditionPhrase(this, OperatorType.Between, new object[] { left, right });
        }

        public ConditionPhrase Between<T>(T left, T right) where T : struct
        {
            return new ConditionPhrase(this, OperatorType.Between, new object[] { left, right });
        }

        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}

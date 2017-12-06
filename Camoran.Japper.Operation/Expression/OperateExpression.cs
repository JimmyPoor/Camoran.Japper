using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{
    public sealed class OperateExpression
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

        /// <summary>
        /// override equal operator . 
        /// for example: a.b=right value
        /// </summary>
        /// <param name="left">left exp</param>
        /// <param name="right">right value</param>
        /// <returns>ConditionPhrase</returns>
        public static ConditionPhrase operator ==(OperateExpression left, object right)
        {
            return new ConditionPhrase(left, OperatorType.Equal, left.Param, right);
        }

        /// <summary>
        /// override not equal operator . 
        /// for example: a.b!=right value
        /// </summary>
        /// <param name="left">left exp</param>
        /// <param name="right">right value</param>
        /// <returns>ConditionPhrase</returns>
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

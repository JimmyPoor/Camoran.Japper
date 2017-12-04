using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Phrase
{
    public sealed class ConditionOperator
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
        /// a.b==12 
        /// </summary>
        /// <param name="left">means param</param>
        /// <param name="right">means value</param>
        /// <returns></returns>
        public static ConditionPhrase operator ==(ConditionOperator left, object right)
        {
            //a.b == b.c
            return new ConditionPhrase(left, left.Param, right);
        }

        public static ConditionPhrase operator !=(ConditionOperator left, object right)
        {
            return null;
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class SelectOperation
    {
      
        public SelectOperation select(SelectPhrase[] phrases)
        {
            foreach(var item in phrases)
            {

            }

            return null;
        }

        public SelectOperation from(FromPhrase phrase)
        {
            return null;
        }

        public SelectOperation from(SelectOperation sub)
        {
            SubOperation = sub;

            return this;
        }

        public SelectOperation join()
        {
            return this;
        }

        public SelectOperation leftjoin()
        {
            return this;
        }

        public SelectOperation rightjoin()
        {
            return this;
        }

        public SelectOperation where()
        {
            return this;
        }

        public SelectOperation order_by()
        {
            return this;
        }

        public SelectOperation group_by()
        {
            return this;
        }

        public SelectOperation skip()
        {
            return this;
        }

        public SelectOperation take()
        {
            return this;
        }

        public IEnumerable<T> Query<T>()
        {
            return null;
        }

        public SelectOperation SubOperation { get; private set; }

        public IDbProvider IDbProvider { get; private set; }

        ISqlParser SelectParser { get; }

    }

}

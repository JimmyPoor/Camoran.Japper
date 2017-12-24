using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Camoran.Japper.Operation
{
    // select(s ,s ,s ,s).from(f).join(f).on(w) .join()....where().group_by()
    public sealed class SelectOperation
    {

        public SelectOperation()
        {
            _currentList = new LinkedList<SqlPhrase>();
        }

        public SelectOperation select(params SelectPhrase[] phrases)
        {
            foreach(var item in phrases)
            {
                _currentList.AddLast(item);
            }
           
            return this;
        }

        public SelectOperation from(FromPhrase phrase)
        {
            _currentList.AddLast(phrase);

            return null;
        }

        public SelectOperation from(SelectOperation sub)
        {
            SubOperation = sub;

            return this;
        }

        public SelectOperation join(FromPhrase pharse)
        {
            var joinPhrase= new JoinPhrase(pharse.TableName, JoinType.Inner);
            _currentList.AddLast(joinPhrase);

            return this;
        }

        public SelectOperation on(WherePhrase phrase)
        {
            _currentList.AddLast(new OnPhrase(phrase.Name) { });

            return this;
        }

        public SelectOperation leftjoin(FromPhrase pharse)
        {
            return this;
        }

        public SelectOperation rightjoin(FromPhrase pharse)
        {
            return this;
        }

        public SelectOperation where(WherePhrase phrase)
        {
            return this;
        }

        public SelectOperation order_by()
        {
            return this;
        }

        public SelectOperation group_by(AggregatePhrase phrase)
        {
            return this;
        }

        public SelectOperation skip(int skip)
        {
            return this;
        }

        public SelectOperation take(int take)
        {
            return this;
        }

        public IEnumerable<T> Query<T>()
        {
            var phraseArray = _currentList.ToArray();
            var sql = SelectParser.ParseToSql(phraseArray);
            var result = IDbProvider.Query<T>(sql);
            return result;
        }

        public Task<IEnumerable<T>> QueryAsync<T>()
        {
            //var phraseArray = _currentList.ToArray();
            //var sql = SelectParser.ParseToSql(phraseArray);
            //var result = IDbProvider.Query<T>(sql);
            //return result;
            IEnumerable<T> result = null;
            return Task.FromResult(result);
        }

        public SelectOperation SubOperation { get; private set; }

        public IDbProvider IDbProvider { get; private set; }

        private LinkedList<SqlPhrase> _currentList;

        private ISqlParser SelectParser { get; }

    }

}

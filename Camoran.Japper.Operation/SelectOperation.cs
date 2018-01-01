using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Camoran.Japper.Operation
{
    //dapper;
    //Japper.select(Avg(s) ,s ,s ,s).from(f).join(f,a.b=b.a) .join()....where().group_by()
    public sealed class SelectOperation
    {

        public SelectOperation(IDbProvider provider, ISqlParser parser)
        {
            _dbProvider = provider;
            _selectParser = parser;
            _currentList = new LinkedList<SqlPhrase>();
        }

        public SelectOperation select(params SelectPhrase[] phrases)
        {
            foreach (var item in phrases)
            {
                _currentList.AddLast(item);
            }

            return this;
        }

        public SelectOperation from(FromPhrase selectPhrases)
        {
            _currentList.AddLast(selectPhrases);

            return null;
        }

        //TODO:will add later
        //public SelectOperation from(SelectOperation sub)
        //{
        //    SubOperation = sub;

        //    return this;
        //}

        public SelectOperation join(FromPhrase pharse, WherePhrase wherePhrase)
        {
            var joinPhrase = new JoinPhrase(pharse.TableName, JoinType.Inner, wherePhrase);
            _currentList.AddLast(joinPhrase);
            _currentList.AddLast(wherePhrase);

            return this;
        }

        public SelectOperation leftjoin(FromPhrase pharse, WherePhrase wherePhrase)
        {
            var joinPhrase = new JoinPhrase(pharse.TableName, JoinType.Left, wherePhrase);
            _currentList.AddLast(joinPhrase);
            _currentList.AddLast(wherePhrase);

            return this;
        }

        public SelectOperation rightjoin(FromPhrase pharse, WherePhrase wherePhrase)
        {
            var joinPhrase = new JoinPhrase(pharse.TableName, JoinType.Right, wherePhrase);
            _currentList.AddLast(joinPhrase);
            _currentList.AddLast(wherePhrase);

            return this;
        }

        public SelectOperation where(WherePhrase phrase)
        {
            _currentList.AddLast(phrase);

            return this;
        }

        public SelectOperation order_by(params OrderPhrase[] selectPhrases)
        {
            foreach (var item in selectPhrases)
            {
                _currentList.AddLast(item);
            }

            return this;
        }

        public SelectOperation group_by(params GroupPhrase[] selectPhrases)
        {
            foreach (var item in selectPhrases)
            {
                _currentList.AddLast(item);
            }

            return this;
        }

        public SelectOperation skip(int skip)
        {
            var phrase = new SelectPhrase(null, null, null, SelectType.Skip);
            _currentList.AddLast(phrase);

            return this;
        }

        public SelectOperation take(int take)
        {
            var phrase = new SelectPhrase(null, null, null, SelectType.Take);
            _currentList.AddLast(phrase);

            return this;
        }

        public IEnumerable<T> Query<T>()
        {
            IEnumerable<T> result = null;
            if (_currentList.Count > 0)
            {
                SetNext();
                var phraseArray = _currentList.ToArray();
                var sql = _selectParser.ParseToSql(phraseArray);
                result = _dbProvider.Query<T>(sql);
            }

            return result;
        }

        public Task<IEnumerable<T>> QueryAsync<T>()
        {
            IEnumerable<T> result = null;
            return Task.FromResult(result);
        }

        public SelectOperation SubOperation { get; private set; }

        public IDbProvider _dbProvider { get; private set; }

        private LinkedList<SqlPhrase> _currentList;

        private ISqlParser _selectParser { get; set; }

        private void SetNext()
        {
            foreach (var item in _currentList)
            {
                if (null != item.Next)
                    item.SetNext(item.Next);
            }
        }

    }

}

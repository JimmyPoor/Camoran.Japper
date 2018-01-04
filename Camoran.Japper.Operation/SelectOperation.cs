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
            DbProvider = provider;
            _selectParser = parser;
        }

        public SelectOperation select(params SelectPhrase[] phrases)
        {
            var hasFirst = phrases!=null && phrases.Length>0;
            if (hasFirst)
            {
                _current = phrases[0];
                _current.SetNext(phrases);
            }
           
            return this;
        }

        public SelectOperation from(FromPhrase selectPhrases)
        {
            _current.SetNext(selectPhrases);

            return this;
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
            _current.SetNext(joinPhrase);
            _current.Next.SetNext(wherePhrase);

            return this;
        }

        public SelectOperation leftjoin(FromPhrase pharse, WherePhrase wherePhrase)
        {
            var joinPhrase = new JoinPhrase(pharse.TableName, JoinType.Left, wherePhrase);
            _current.SetNext(joinPhrase);
            _current.Next.SetNext(wherePhrase);

            return this;
        }

        public SelectOperation rightjoin(FromPhrase pharse, WherePhrase wherePhrase)
        {
            var joinPhrase = new JoinPhrase(pharse.TableName, JoinType.Right, wherePhrase);
            _current.SetNext(joinPhrase);
            _current.Next.SetNext(wherePhrase);

            return this;
        }

        public SelectOperation where(WherePhrase phrase)
        {
            _current.SetNext(phrase);

            return this;
        }

        public SelectOperation order_by(params OrderPhrase[] selectPhrases)
        {
            _current.SetNext(selectPhrases);

            return this;
        }

        public SelectOperation group_by(params GroupPhrase[] selectPhrases)
        {
            _current.SetNext(selectPhrases);

            return this;
        }

        public SelectOperation skip(int skip)
        {
            var phrase = new SelectPhrase(null, null, null, SelectType.Skip);
            _current.SetNext(phrase);

            return this;
        }

        public SelectOperation take(int take)
        {
            var phrase = new SelectPhrase(null, null, null, SelectType.Take);
            _current.SetNext(phrase);

            return this;
        }

        public IEnumerable<T> Query<T>()
        {
            var sql = _selectParser.ParseToSql(_current);

            return DbProvider.Query<T>(sql);
        }

        public Task<IEnumerable<T>> QueryAsync<T>()
        {
            IEnumerable<T> result = null;

            return Task.FromResult(result);
        }

        public SelectOperation SubOperation { get; private set; }

        public IDbProvider DbProvider { get; private set; }

        private SqlPhrase _current;

        private ISqlParser _selectParser { get; set; }
    }

}

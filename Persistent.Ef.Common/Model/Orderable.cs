using System;
using System.Linq;
using System.Linq.Expressions;

namespace Persistent.Common.Model
{
    public class Orderable<T> : IOrderable<T>
       where T : class, new()
    {
        private IQueryable<T> _queryable;
        public Orderable(IQueryable<T> queryable)
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");
            _queryable = queryable;
        }

        public IOrderable<T> Asc<TK>(Expression<Func<T, TK>> selector)
        {
            _queryable = _queryable
                 .OrderBy(selector);
            return this;
        }

        public IOrderable<T> Asc<TK1, TK2>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2)
        {
            _queryable = _queryable
                 .OrderBy(selector1)
                 .ThenBy(selector2);
            return this;
        }

        public IOrderable<T> Asc<TK1, TK2, TK3>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2, Expression<Func<T, TK3>> selector3)
        {
            _queryable = _queryable
                 .OrderBy(selector1)
                 .ThenBy(selector2)
                 .ThenBy(selector3);
            return this;
        }

        public IQueryable<T> AsQueryable()
        {
            return _queryable;
        }

        public IOrderable<T> Desc<TK>(Expression<Func<T, TK>> selector)
        {
            _queryable = _queryable
               .OrderByDescending(selector);
            return this;
        }

        public IOrderable<T> Desc<TK1, TK2>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2)
        {
            _queryable = _queryable
               .OrderByDescending(selector1)
               .ThenByDescending(selector2);
            return this;
        }

        public IOrderable<T> Desc<TK1, TK2, TK3>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2, Expression<Func<T, TK3>> selector3)
        {
            _queryable = _queryable
               .OrderByDescending(selector1)
               .ThenByDescending(selector2)
               .ThenByDescending(selector3);
            return this;
        }
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Persistent.Common
{
    public interface IOrderable<T> where T : class, new()
    {
        IQueryable<T> AsQueryable();

        IOrderable<T> Asc<TK>(Expression<Func<T, TK>> selector);
        IOrderable<T> Asc<TK1, TK2>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2);

        IOrderable<T> Asc<TK1, TK2, TK3>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2,
            Expression<Func<T, TK3>> selector3);

        IOrderable<T> Desc<TK>(Expression<Func<T, TK>> selector1);
        IOrderable<T> Desc<TK1, TK2>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2);

        IOrderable<T> Desc<TK1, TK2, TK3>(Expression<Func<T, TK1>> selector1, Expression<Func<T, TK2>> selector2,
            Expression<Func<T, TK3>> selector3);
    }
}

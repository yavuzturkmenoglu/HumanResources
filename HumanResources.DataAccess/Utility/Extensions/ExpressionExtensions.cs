using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HumanResources.DataAccess.Utility.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> MergeWithAnd<TEntity>(this Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression1, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression2)
        {
            var replace = new ReplacingExpressionVisitor(expression2.Parameters, new[] { expression1.Body });
            var combined = replace.Visit(expression2.Body);
            return Expression.Lambda<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>>(combined, expression1.Parameters);
        }
    }
}
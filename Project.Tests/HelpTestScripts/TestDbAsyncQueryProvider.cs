﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
{
    private readonly IQueryProvider _inner;

    internal TestAsyncQueryProvider(IQueryProvider inner)
    {
        _inner = inner;
    }

    public IQueryable CreateQuery(Expression expression)
    {
        return new AsyncEnumerable<TEntity>(expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new AsyncEnumerable<TElement>(expression);
    }

    public object Execute(Expression expression)
    {
        return _inner.Execute(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        return _inner.Execute<TResult>(expression);
    }

    public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
    {
        return Task.FromResult(Execute(expression));
    }

    // public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
    // {
    //     return Task.FromResult(Execute<TResult>(expression));
    // }
    
    public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
    {
        return Task.FromResult(Execute<TResult>(expression));
    }

    TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) {
        var returnValue = ExecuteAsync<TResult>(expression, default); 
        return ConvertToTResult<TResult>(returnValue);
    }

    private static TR ConvertToTResult<TR>(dynamic toConvert) {
        return (TR)toConvert;
    }
}
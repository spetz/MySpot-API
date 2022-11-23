namespace MySpot.Application.Shared.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}
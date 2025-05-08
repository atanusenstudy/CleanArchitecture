using Ardalis.Specification;
using ShardKernel.Modules.DB.Extensions;


namespace ShardKernel.Modules.DB.Repository;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    Task<(List<TResult> Items, int Total)> ListWithCountAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default) where TResult : IGlobalTotalCountHack;
}


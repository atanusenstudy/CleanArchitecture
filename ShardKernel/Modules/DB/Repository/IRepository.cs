using Ardalis.Specification;

namespace ShardKernel.Modules.DB.Repository;

public interface IRepository<T> : IRepositoryBase<T>, IReadRepository<T> where T : class, IAggregateRoot
{
}

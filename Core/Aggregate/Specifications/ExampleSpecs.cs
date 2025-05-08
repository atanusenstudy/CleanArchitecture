using Ardalis.Specification;
using Core.Aggregate.Entities;
using Core.Aggregate.Specifications.Filters;
using ShardKernel.Helpers;

namespace Core.Aggregate.Specifications;

public sealed class ExampleSpecs : Specification<Example>
{
    public ExampleSpecs(ExampleFilter filter, Guid? id = null)
    {
        if (id != null)
            Query.Where(e => e.Id == id);

        if(filter.boProperty.HasValue)
            Query.Where(e => e.boProperty == filter.boProperty);

        if(!string.IsNullOrEmpty(filter.stProperty))
            Query.Search(e => e.stProperty, "%" + filter.stProperty + "%");

        Query.Where(e => !e.IsDeleted);

        if(filter.IsPaginationEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));
    }
}

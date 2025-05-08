using ShardKernel.Modules.HTTP.SpecificationFilters;

namespace Core.Aggregate.Specifications.Filters;

public class ExampleFilter : BaseFilter
{
    public string? stProperty { get; set; }
    public bool? boProperty { get; set; }
}

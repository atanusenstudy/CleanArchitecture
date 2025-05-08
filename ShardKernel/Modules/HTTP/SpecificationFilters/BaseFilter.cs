namespace ShardKernel.Modules.HTTP.SpecificationFilters;

public class BaseFilter
{
    public bool IsPaginationEnabled { get; set; }
    public int PageNo { get; set; }
    public int PageSize { get; set; }
}

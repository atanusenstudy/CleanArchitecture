using ShardKernel.Modules.HTTP.SpecificationFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardKernel.Helpers;

public static class PaginationHelper
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 25;

    public static int CalculateTake(int pageSize) => pageSize<=0 ? DefaultPageSize : pageSize;
    public static int CalculateSkip( int pageSize, int pageNo)
    {
        pageNo = pageNo <=0 ? DefaultPage : pageNo;

        return CalculateTake(pageSize) * (pageNo - 1);
    }

    public static int CalculateTake(BaseFilter baseFilter) => CalculateTake(baseFilter.PageSize);
    public static int CalculateSkip(BaseFilter baseFilter) => CalculateSkip(baseFilter.PageSize, baseFilter.PageNo);
}

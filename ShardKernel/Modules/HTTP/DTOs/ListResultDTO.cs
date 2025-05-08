using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardKernel.Modules.HTTP.DTOs;

public class ListResultDTO<T>
{
    public List<T> List;
    public Task<int>? Count;
    public ListResultDTO(List<T> list, Task<int> count) {  
        List = list;
        Count = count;
    }
}

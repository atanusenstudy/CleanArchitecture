using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardKernel.Modules.DB.Entity;

public class BaseEntity : IEntity<Guid>, ITenant<int>
{
    public Guid Id { get; set; }
    public int CompanyId { get; set; }
}

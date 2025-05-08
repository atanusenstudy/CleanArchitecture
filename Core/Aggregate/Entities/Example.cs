using ShardKernel.Modules.DB.Entity;
using ShardKernel.Modules.DB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aggregate.Entities;

public class Example : AuditableEntity, IAggregateRoot, ISoftDeletable
{
    public string stProperty { get; set; }
    public bool boProperty { get; set; }
    public bool IsDeleted { get; set; } = false;
}
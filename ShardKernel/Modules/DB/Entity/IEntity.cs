using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardKernel.Modules.DB.Entity;

public interface IEntity<TId>
{
    public TId Id { get; set; }
}

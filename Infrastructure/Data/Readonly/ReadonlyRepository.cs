using Infrastructure.Data.FullAccess;
using ShardKernel.Modules.DB.Repository;
using ShardKernel.Modules.HTTP.CallerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Readonly;

public class ReadonlyRepository<T>(ReadonlyAppDbContext dbContext, ICallerContext context)
    : BaseRepository<T>(dbContext, context) where T : class, IAggregateRoot;

using Ardalis.Result;
using AutoMapper;
using Core.Aggregate.DTOs;
using Core.Aggregate.Entities;
using Core.Aggregate.Specifications;
using Core.CQRS.Examples.Requests;
using MediatR;
using ShardKernel.Modules.DB.Repository;
using ShardKernel.Modules.HTTP.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CQRS.Examples.Handlers;

public class GetExampleHandler(IReadRepository<Example> readRepository, IMapper mapper) : IRequestHandler<GetExampleRequest, Result<ListResultDTO<ExampleDTO>>>
{
    public Task<Result<ListResultDTO<ExampleDTO>>> Handle(GetExampleRequest request, CancellationToken cancellationToken)
    {
        var entitis = readRepository.ListAsync(new ExampleSpecs(request.Filter, null), cancellationToken);
        var count = readRepository.CountAsync(new ExampleSpecs(request.Filter, null), cancellationToken);
        var result = new ListResultDTO<ExampleDTO>(mapper.Map<List<ExampleDTO>>(entitis), count);
        //var result = new ListResultDTO<ExampleDTO>(entitis, count);

        return Task.FromResult(Result.Success(result));
    }
}

using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Core.Aggregate.DTOs;
using Core.Aggregate.Specifications.Filters;
using Core.CQRS.Examples.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShardKernel.Modules.HTTP.DTOs;
using ShardKernel.Modules.HTTP.Extensions;

namespace API.Endpoints.Example;

public class Get(IMediator mediator, IHttpContextAccessor _httpContextAccessor)
: EndpointBaseAsync.WithRequest<ExampleFilter>.WithResult<Result<ListResultDTO<ExampleDTO>>>
{
    [HttpGet("api/example")]
    public override Task<Result<ListResultDTO<ExampleDTO>>> HandleAsync([FromQuery] ExampleFilter filter,
        CancellationToken cancellationToken = default) => mediator.Send(new GetExampleRequest(filter), cancellationToken);
}
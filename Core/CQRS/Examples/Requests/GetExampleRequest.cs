using Ardalis.Result;
using Core.Aggregate.DTOs;
using Core.Aggregate.Specifications.Filters;
using MediatR;
using ShardKernel.Modules.HTTP.DTOs;

namespace Core.CQRS.Examples.Requests;
public record GetExampleRequest(ExampleFilter Filter) : IRequest<Result<ListResultDTO<ExampleDTO>>>;
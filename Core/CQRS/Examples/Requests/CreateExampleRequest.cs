using Ardalis.Result;
using Core.Aggregate.DTOs;
using MediatR;

namespace Core.CQRS.Examples.Requests;

public record CreateExampleRequest(ExampleDTO Example, int UserId) : IRequest<Result<ExampleDetailsDTO>>;
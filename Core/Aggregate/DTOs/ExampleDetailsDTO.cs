namespace Core.Aggregate.DTOs;

public record ExampleDetailsDTO(Guid Id, string stProperty, bool boProperty) : ExampleDTO(stProperty, boProperty);

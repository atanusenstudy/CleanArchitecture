using FluentValidation;

namespace Core.Aggregate.Validations;

public class BaseExampleValidator<T> : AbstractValidator<T>
{
    public BaseExampleValidator()
    {
        RuleFor(e => GetExampleStringProperty(e))
            .NotEmpty()
            .WithMessage("ExampleStringProperty cannot be empty.");

        When(e => GetExampleBoolProperty(e) == true, () =>
        {
            RuleFor(e => GetExampleStringProperty(e))
                .NotEqual("Example")
                .WithMessage("Please ensure that the example property is not set to 'Example' when the bool property is set to true.");
        });
    }

    private static string? GetExampleStringProperty(T instance)
    {
        var example = instance?.GetType().GetProperty("Example")?.GetValue(instance);
        return example?.GetType().GetProperty("stProperty")?.GetValue(example) as string;
    }

    private static bool? GetExampleBoolProperty(T instance)
    {
        var example = instance?.GetType().GetProperty("Example")?.GetValue(instance);
        return example?.GetType().GetProperty("boProperty")?.GetValue(example) as bool?;
    }
}
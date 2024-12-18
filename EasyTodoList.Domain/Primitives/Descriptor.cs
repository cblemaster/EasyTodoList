
namespace EasyTodoList.Domain.Primitives;

public record Descriptor(ValidString Value)
{
    public static Descriptor ConstructOrThrowArgumentException(string value) =>
        string.IsNullOrWhiteSpace(value) || value.Length > 100
        ? throw new ArgumentException("Value is required, cannot consist of only whitespace characters, and must be 100 characters or fewer.", nameof(value))
        : new Descriptor(new ValidString(value));
}

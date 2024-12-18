
namespace EasyTodoList.Domain.Primitives;

public record Descriptor(ValidString Value)
{
    public static Descriptor ConstructOrThrowArgumentException(string value) =>
        string.IsNullOrWhiteSpace(value) || value.Length > 100
        ? throw new ArgumentException(value)
        : new Descriptor(new ValidString(value));
}

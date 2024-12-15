
namespace EasyTodoList.Domain.Primitives;

public class Identifier
{
    public Guid Value { get; init; }

    private Identifier(Guid value) => Value = value;

    public static Identifier Construct() => new(Guid.CreateVersion7());
}

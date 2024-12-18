
using EasyTodoList.Domain.Primitives;

namespace EasyTodoList.Domain.Entities;

public record Todo(Descriptor Description, DateOnly? DueDate, bool IsImportant, bool IsComplete, DateTimeStamps Dates, Identifier Id) : Entity(Id)
{
    internal static Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete) =>
        new(new Descriptor(new ValidString(description)), dueDate, isImportant, isComplete, new DateTimeStamps(DateTime.Now, null), new Identifier(Guid.CreateVersion7()));
}

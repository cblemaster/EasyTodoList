
using EasyTodoList.Domain.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Entities;

public class Todo : Entity
{
    public required Descriptor Description { get; init; }
    public DateOnly? DueDate { get; init; }
    public bool IsImportant { get; init; }
    public bool IsComplete { get; init; }
    public DateTimeStamps Dates { get; init; }
    public override Identifier Id { get; init; }

    [SetsRequiredMembers]
    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete)
    {
        Description = Descriptor.ConstructOrThrowArgumentException(description);
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        Dates = new DateTimeStamps(CreateDate: DateTime.Now, UpdateDate: null);
        Id = new Identifier(Value: Guid.CreateVersion7());
    }

    internal static Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete) =>
        new(description, dueDate, isImportant, isComplete);
}


using EasyTodoList.Domain.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Entities;

public class Todo : Entity
{
    public required Descriptor Description { get; init; }
    public required DateOnly? DueDate { get; init; }
    public required bool IsImportant { get; init; }
    public required bool IsComplete { get; init; }
    public required DateTimeStamps Dates { get; init; }
    public required override Identifier Id { get; init; }

    private Todo() { }

    [SetsRequiredMembers]
    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate)
    {
        Description = Descriptor.ConstructOrThrowArgumentException(description);
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        Dates = DateTimeStamps.Construct(createDate, updateDate);
        Id = Identifier.Construct();
    }

    internal static Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete) =>
        new(description, dueDate, isImportant, isComplete, DateTime.Now, null);
}

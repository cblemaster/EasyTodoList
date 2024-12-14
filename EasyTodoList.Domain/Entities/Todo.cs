
using EasyTodoList.Domain.Primitives;

namespace EasyTodoList.Domain.Entities;

internal class Todo : Entity
{
    internal Descriptor Description { get; init; }
    internal DateOnly? DueDate { get; init; }
    internal bool IsImportant { get; init; }
    internal bool IsComplete { get; init; }
    internal DateTimeStamps Dates { get; init; }
    internal override Identifier Id { get; init; }

    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate)
    {
        DateTimeStamps dates = DateTimeStamps.Construct(createDate, updateDate);

        Description = Descriptor.Construct(description);
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        Dates = dates;
        Id = Identifier.Construct();
    }

    public static Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate) =>
        new(description, dueDate, isImportant, isComplete, createDate, updateDate);
}

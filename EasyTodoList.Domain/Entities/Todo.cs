
using EasyTodoList.Domain.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Entities;

internal class Todo : Entity
{
    internal required Descriptor Description { get; init; }
    internal required DateOnly? DueDate { get; init; }
    internal required bool IsImportant { get; init; }
    internal required bool IsComplete { get; init; }
    internal required DateTimeStamps Dates { get; init; }
    internal required override Identifier Id { get; init; }

    [SetsRequiredMembers]
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

﻿
using EasyTodoList.Domain.DataTransfer;
using EasyTodoList.Domain.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Entities;

public class Todo : Entity
{
    #region properties
    public required Descriptor Description { get; init; }
    public required DateOnly? DueDate { get; init; }
    public required bool IsImportant { get; init; }
    public required bool IsComplete { get; init; }
    public required DateTimeStamps Dates { get; init; }
    public required override Identifier Id { get; init; }

    public TodoDetail GetTodoDetail => new() { Description = Description.Value, DueDate = DueDate, IsImportant = IsImportant, IsComplete = IsComplete, CreateDate = Dates.CreateDate, UpdateDate = Dates.UpdateDate, Id = Id.Value };
    #endregion properties

    #region ctors
    private Todo() { }

    [SetsRequiredMembers]
    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate)
    {
        Description = Descriptor.Construct(description);
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        Dates = DateTimeStamps.Construct(createDate, updateDate);
        Id = Identifier.Construct();
    }
    #endregion ctors

    #region factory methods
    public static Todo Construct(CreateTodo dto) => ValidateCreateTodo(dto).IsValid
            ? new(dto.Description, dto.DueDate, dto.IsImportant, dto.IsComplete, DateTime.Now, null)
            : Todo.NotValid(); // TODO: Pass in the validation error

    public static IEnumerable<Todo> ConstructEnumerable(IEnumerable<CreateTodo> dtos)
    {
        List<Todo> list = [];
        foreach (CreateTodo dto in dtos)
        {
            list.Add(Todo.Construct(dto));
        }
        return list.AsEnumerable();
    }

    private static Todo NotValid() => new("Input provided for todo is not valid.", null, false, false, DateTime.Now, null);
    #endregion factory methods

    #region input validation
    private static (bool IsValid, string ErrorMessage) ValidateCreateTodo(CreateTodo dto)
    {
        bool isValid = true;
        string error = string.Empty;

        if (string.IsNullOrWhiteSpace(dto.Description))
        {
            isValid = false;
            error = "Todo description is required and cannot consist of only whitespace charaters.";
        }
        else if (dto.Description.Length > 100)
        {
            isValid = false;
            error = "Todo description must be 100 characters or fewer.";
        }

        return (isValid, error);
    }
    #endregion input validation
}

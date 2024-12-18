﻿
using EasyTodoList.Domain.Entities;

namespace EasyTodoList.Domain.DataTransfer;

public static class EntityDTOMapper
{
    public static TodoDTO MapTodoEntityToDTO(Todo todo) =>
        new()
        {
            Description = todo.Description.Value.Value,
            DueDate = todo.DueDate,
            IsImportant = todo.IsImportant,
            IsComplete = todo.IsComplete,
            CreateDate = todo.Dates.CreateDate,
            UpdateDate = todo.Dates.UpdateDate,
            Id = todo.Id.Value
        };

    public static IEnumerable<TodoDTO> MapTodoEntitySequenceToTodoDTOSequence(IEnumerable<Todo> todos)
    {
        List<TodoDTO> dtos = [];
        foreach (Todo todo in todos)
        {
            dtos.Add(MapTodoEntityToDTO(todo));
        }
        return dtos;
    }
}

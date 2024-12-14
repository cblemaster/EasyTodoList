

using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Primitives;

internal class DateTimeStamps
{
    internal required DateTime CreateDate { get; init; }
    internal required DateTime? UpdateDate { get; init; }

    [SetsRequiredMembers]
    private DateTimeStamps(DateTime createDate, DateTime? updateDate)
    {
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    public static DateTimeStamps Construct(DateTime createDate, DateTime? updateDate) => new(createDate, updateDate);
}

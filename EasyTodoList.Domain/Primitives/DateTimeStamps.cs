
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Primitives;

public class DateTimeStamps
{
    public DateTime CreateDate { get; init; }
    public DateTime? UpdateDate { get; init; }

    private DateTimeStamps(DateTime createDate, DateTime? updateDate)
    {
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    internal static DateTimeStamps Construct(DateTime createDate, DateTime? updateDate) => new(createDate, updateDate);
}

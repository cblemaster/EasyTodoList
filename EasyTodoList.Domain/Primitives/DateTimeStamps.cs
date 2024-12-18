
namespace EasyTodoList.Domain.Primitives;

public class DateTimeStamps
{
    internal DateTime CreateDate { get; init; }
    internal DateTime? UpdateDate { get; init; }

    private DateTimeStamps(DateTime createDate, DateTime? updateDate)
    {
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    internal static DateTimeStamps Construct(DateTime createDate, DateTime? updateDate) => new(createDate, updateDate);
}

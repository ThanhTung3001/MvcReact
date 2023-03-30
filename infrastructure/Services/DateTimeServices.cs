using Applications.Common.Interface;

namespace infrastructure.Services;

public class DateTimeServices:IDateTime
{
    public DateTime Now => DateTime.Now;
}
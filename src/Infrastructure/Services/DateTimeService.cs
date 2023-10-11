using Music.Application.Common.Interfaces;

namespace Music.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}

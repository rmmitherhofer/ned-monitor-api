using MediatR;

namespace NedMonitor.Application.Core;

public class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    public Event() => Timestamp = DateTime.Now;
}

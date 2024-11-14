using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface INotificationStorage : IStorage<Notification>
{
    Task<List<Notification>> GetNotificationsBySensorId(Guid sensorId, CancellationToken cancellationToken = default);
}
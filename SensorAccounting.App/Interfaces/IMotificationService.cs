using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface IMotificationService
{
    Task<List<Notification>> GetNotificationsByUserIdAsync(Guid userId);
    Task<List<Notification>> GetNotificationsBySensorIdAsync(Guid sensorId);
    Task SendNotificationAsync(Guid userId, string message, Guid? sensorId = null);
}
using Buildings.Domain.Models;
using SensorAccounting.App.Interfaces;

namespace SensorAccounting.App.Services;

public class SensorService
{
    private readonly ISensorStorage _sensorStorage;
    private readonly INotificationStorage _notificationStorage;

    public SensorService(ISensorStorage sensorStorage, INotificationStorage notificationStorage)
    {
        _sensorStorage = sensorStorage;
        _notificationStorage = notificationStorage;
    }

    public async Task RegisterSensorAsync(Sensor sensor)
    {
        await _sensorStorage.Add(sensor);
    }

    public async Task UpdateSensorLocationAsync(Guid sensorId, string? photoUrl, Location location)
    {
        /*var sensor = await _sensorStorage.GetById(sensorId).Result;
        if (sensor != null)
        {
            sensor.PhotoUrl = photoUrl;
            sensor.Location = location;
            await _sensorStorage.Update(sensor);
        }*/
    }

    public async Task StartSensorTransmissionAsync(Guid sensorId, double temperature, int chargeLevel)
    {
        var sensor = await _sensorStorage.GetById(sensorId);
        if (sensor != null)
        {
            sensor.Temperature = temperature;
            sensor.ChargeLevel = chargeLevel;
            await _sensorStorage.Update(sensor);
            
            if (temperature < sensor.MinTemperature || temperature > sensor.MaxTemperature)
            {
                var notification = new Notification
                {
                    Id = sensor.Building.Id,
                    IdSensor = sensor.Id,
                    Message = $"Sensor {sensor.Name} temperature out of range: {temperature}°C",
                    Date = DateTime.UtcNow
                };
                await _notificationStorage.Add(notification);
            }
            
            if (chargeLevel < 10)
            {
                var notification = new Notification
                {
                    Id = sensor.Building.Id,
                    IdSensor = sensor.Id,
                    Message = $"Sensor {sensor.Name} battery level below 10%",
                    Date = DateTime.UtcNow
                };
                await _notificationStorage.Add(notification);
            }
        }
    }
}
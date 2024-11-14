using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface ISensorService
{
    Task RegisterSensorAsync(Sensor sensor);
    Task<Sensor?> GetSensorByIdAsync(Guid sensorId);
    Task<List<Sensor>> GetSensorsByBuildingIdAsync(Guid buildingId);
    Task UpdateSensorInfoAsync(Sensor sensor);
    Task DeleteSensorAsync(Guid sensorId);
    Task StartSensorTransmissionAsync(Guid sensorId, double temperature, double humidity, double chargeLevel);
    Task UpdateSensorLocationAsync(Guid sensorId, string? photoUrl, Location location);
}
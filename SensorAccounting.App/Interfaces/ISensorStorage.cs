using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface ISensorStorage: IStorage<Sensor>
{
    Task<List<Sensor>> GetSensorsByBuildingId(Guid buildingId);
}
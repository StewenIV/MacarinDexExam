using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface IBuildingService
{
    Task RegisterBuildingAsync(Building building);
    Task<Building?> GetBuildingByIdAsync(Guid buildingId);
    Task<List<Building>> GetBuildingsByUserIdAsync(Guid userId);
    Task UpdateBuildingInfoAsync(Building building);
    Task DeleteBuildingAsync(Guid buildingId);
}
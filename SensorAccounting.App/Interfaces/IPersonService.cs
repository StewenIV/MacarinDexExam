using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface IPersonService
{
    Task RegisterUserAsync(Person user);
    Task<Person?> GetUserByIdAsync(Guid userId);
    Task<List<Building>> GetUserBuildingsAsync(Guid userId);
    Task UpdateUserInfoAsync(Person user);
    Task DeleteUserAsync(Guid userId);
}
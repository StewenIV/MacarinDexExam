using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface IPersonStorage: IStorage<Person>
{
    Task<List<Person>> GetAll(CancellationToken cancellationToken = default);
}
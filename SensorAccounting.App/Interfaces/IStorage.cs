using Buildings.Domain.Models;

namespace SensorAccounting.App.Interfaces;

public interface IStorage<T> where T : class
{
    Task<List<Building?>> GetAll(CancellationToken cancellationToken = default);
    Task<T> GetById(Guid id,CancellationToken cancellationToken = default);
    Task Add(T entity, CancellationToken cancellationToken = default);
    Task Update(T entity, CancellationToken cancellationToken = default);
    Task Delete(Guid id, CancellationToken cancellationToken = default);
}
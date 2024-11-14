using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SensorAccounting.App.Interfaces;
using SensorAccounting.DbContext;

namespace SensorAccounting.Storages;

public class BuildingStorage : IBuildingStorage
{
    private readonly SensorAccountingDbContext _dbContext;
    
    public BuildingStorage(SensorAccountingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Add(Building? building, CancellationToken cancellationToken = default)
    {
        await _dbContext.Buildings.AddAsync(building, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<List<Building?>> GetAll(CancellationToken cancellationToken = default)
    {
        return _dbContext.Buildings.ToListAsync(cancellationToken);
    }

    public async Task<Building?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<List<Building?>> GetBuildingsByPersonId(Guid personId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Buildings.Where(b => b.Id == personId).ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task Update(Building? building, CancellationToken cancellationToken = default)
    {
        _dbContext.Buildings.Update(building);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var building = await GetById(id, cancellationToken);
        if (building is not null)
        {
            _dbContext.Buildings.Remove(building);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
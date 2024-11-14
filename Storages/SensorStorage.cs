using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SensorAccounting.DbContext;

namespace SensorAccounting.Storages;

public class SensorStorage
{
    private readonly SensorAccountingDbContext _context;

    public SensorStorage(SensorAccountingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sensor sensor)
    {
        await _context.Sensors.AddAsync(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task<Sensor?> GetByIdAsync(Guid sensorId)
    {
        return await _context.Sensors.FirstOrDefaultAsync(s => s.Id == sensorId);
    }

    public async Task<List<Sensor>> GetByBuildingIdAsync(Guid buildingId)
    {
        return await _context.Sensors.Where(s => s.Id == buildingId).ToListAsync();
    }

    public async Task UpdateAsync(Sensor sensor)
    {
        _context.Sensors.Update(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid sensorId)
    {
        var sensor = await GetByIdAsync(sensorId);
        if (sensor != null)
        {
            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();
        }
    }
}
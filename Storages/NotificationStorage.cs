using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SensorAccounting.DbContext;

namespace SensorAccounting.Storages;

public class NotificationStorage
{
    private readonly SensorAccountingDbContext _context;

    public NotificationStorage(SensorAccountingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Notifications.Where(n => n.Id == userId).ToListAsync();
    }

    public async Task<List<Notification>> GetBySensorIdAsync(Guid sensorId)
    {
        return await _context.Notifications.Where(n => n.Id == sensorId).ToListAsync();
    }
}
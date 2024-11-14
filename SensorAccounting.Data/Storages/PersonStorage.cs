using Buildings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SensorAccounting.DbContext;

namespace SensorAccounting.Storages;

public class PersonStorage
{
    private readonly SensorAccountingDbContext _context;
    public PersonStorage(SensorAccountingDbContext context)
    {
        _context = context;
    }
    public async Task Add(Person? person, CancellationToken cancellationToken = default)
    {
        await _context.Persons.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<Person?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Persons.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
    
    public async Task<List<Person?>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _context.Persons.ToListAsync(cancellationToken);
    }
    
    public async Task Update(Person? person, CancellationToken cancellationToken = default)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var person = await _context.Persons.FindAsync(new object[] { id }, cancellationToken);
        if (person == null)
        {
            throw new ArgumentException("Person not found");
        }
        _context.Persons.Remove(person);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
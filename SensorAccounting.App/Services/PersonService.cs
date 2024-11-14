using Buildings.Domain.Models;
using SensorAccounting.App.Interfaces;

namespace SensorAccounting.App.Services;

public class PersonService : IPersonService
{
    private readonly IPersonStorage _personStorage;
    private readonly IBuildingStorage _buildingStorage;

    public PersonService(IPersonStorage personStorage, IBuildingStorage buildingStorage)
    {
        _personStorage = personStorage;
        _buildingStorage = buildingStorage;
    }

    public async Task RegisterPersonAsync(Person person)
    {
        person.Id = Guid.NewGuid();
        await _personStorage.Add(person);
    }

    public async Task<Person?> GetPersonByIdAsync(Guid personId)
    {
        return await _personStorage.GetById(personId); 
    }

    /*public async Task<List<Building>> GetPersonBuildingsAsync(Guid personId)
    {
       // return await _buildingStorage.GetByPersonId(personId); 
    }*/

    public async Task UpdatePersonInfoAsync(Person person)
    {
        await _personStorage.Update(person); 
    }

    public async Task DeletePersonAsync(Guid personId)
    {
        await _personStorage.Delete(personId); 
    }

    public Task RegisterUserAsync(Person user)
    {
        throw new NotImplementedException();
    }

    public Task<Person?> GetUserByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Building>> GetUserBuildingsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserInfoAsync(Person user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}

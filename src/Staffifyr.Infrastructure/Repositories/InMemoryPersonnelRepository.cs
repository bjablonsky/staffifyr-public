using Staffifyr.Core.Entities;
using Staffifyr.Core.Repositories;

namespace Staffifyr.Infrastructure.Repositories;

public class InMemoryPersonnelRepository : IPersonnelRepository
{
    private readonly List<Personnel> _personnelStorage = new();

    public Task<IEnumerable<Personnel>> GetAllAsync()
    {
        return Task.FromResult((IEnumerable<Personnel>)_personnelStorage);
    }

    public Task<Personnel?> GetByIdAsync(int id)
    {
        var personnel = _personnelStorage.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(personnel);
    }

    public Task AddAsync(Personnel personnel)
    {
        personnel.Id = _personnelStorage.Count > 0 ? _personnelStorage.Max(p => p.Id) + 1 : 1;
        _personnelStorage.Add(personnel);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Personnel personnel)
    {
        var existingPersonnel = _personnelStorage.FirstOrDefault(p => p.Id == personnel.Id);
        if (existingPersonnel != null)
        {
            existingPersonnel.UpdateName(personnel.Name);
            existingPersonnel.UpdateDateOfBirth(personnel.DateOfBirth);
            existingPersonnel.UpdateEmail(personnel.EmailAddress);
            existingPersonnel.UpdatePhoneNumber(personnel.PhoneNumber);
            existingPersonnel.UpdateAddress(personnel.Address);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var personnel = _personnelStorage.FirstOrDefault(p => p.Id == id);
        if (personnel != null)
        {
            _personnelStorage.Remove(personnel);
        }
        return Task.CompletedTask;
    }
}

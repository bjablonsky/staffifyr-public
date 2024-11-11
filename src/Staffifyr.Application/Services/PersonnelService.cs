using Staffifyr.Core.Entities;
using Staffifyr.Core.Repositories;


namespace Staffifyr.Application.Services;

public class PersonnelService
{
    private readonly IPersonnelRepository _personnelRepository;

    public PersonnelService(IPersonnelRepository personnelRepository)
    {
        _personnelRepository = personnelRepository;
    }

    public Task<IEnumerable<Personnel>> GetAllPersonnelAsync()
    {
        return _personnelRepository.GetAllAsync();
    }

    public Task<Personnel?> GetPersonnelByIdAsync(int id)
    {
        return _personnelRepository.GetByIdAsync(id);
    }

    public Task AddPersonnelAsync(Personnel personnel)
    {
        return _personnelRepository.AddAsync(personnel);
    }

    public Task UpdatePersonnelAsync(Personnel personnel)
    {
        return _personnelRepository.UpdateAsync(personnel);
    }

    public Task DeletePersonnelAsync(int id)
    {
        return _personnelRepository.DeleteAsync(id);
    }
}

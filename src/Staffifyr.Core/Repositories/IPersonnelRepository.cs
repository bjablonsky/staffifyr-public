using Staffifyr.Core.Entities;

namespace Staffifyr.Core.Repositories;

public interface IPersonnelRepository
{
    Task<IEnumerable<Personnel>> GetAllAsync();
    Task<Personnel?> GetByIdAsync(int id);
    Task AddAsync(Personnel personnel);
    Task UpdateAsync(Personnel personnel);
    Task DeleteAsync(int id);
}

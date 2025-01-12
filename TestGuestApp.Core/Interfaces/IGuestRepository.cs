using TestGuestApp.Core.Entities;

namespace TestGuestApp.Core.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest?> GetByIdAsync(Guid id);

        Task<IEnumerable<Guest>> GetAllAsync();

        Task AddAsync(Guest guest);

        Task UpdateAsync(Guest guest);
    }
}

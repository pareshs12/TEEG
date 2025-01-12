using Microsoft.EntityFrameworkCore;
using TestGuestApp.Core.Entities;
using TestGuestApp.Core.Interfaces;
using TestGuestApp.Infrastructure.DataContext;

namespace TestGuestApp.Infrastructure.Repositories
{
    internal class GuestRepository : IGuestRepository
    {
        private readonly TestGuestDbContext _context;

        public GuestRepository(TestGuestDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetByIdAsync(Guid guestId)
        {
            return await _context.Guests
                .FirstOrDefaultAsync(g => g.Id == guestId);
        }
    }
}

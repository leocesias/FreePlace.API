using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.ParkingLots.Persistence.Repositories;

public class ParkingRepository: BaseRepository, IParkingRepository
{
    public ParkingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Parking>> ListAsync()
    {
        return await _context.Parkings.ToListAsync();
    }

    public async Task AddAsync(Parking parking)
    {
        await _context.Parkings.AddAsync(parking);
    }

    public async Task<Parking> FindByIdAsync(int id)
    {
        return await _context.Parkings.FindAsync(id);
    }

    public async Task<IEnumerable<Parking>> FindByParkingIdAsync(int userId)
    {
        return await _context.Parkings
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Parking parking)
    {
        _context.Parkings.Update(parking);
    }

    public void Remove(Parking parking)
    {
        _context.Parkings.Remove(parking);
    }
}
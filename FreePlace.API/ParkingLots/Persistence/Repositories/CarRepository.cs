using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.ParkingLots.Persistence.Repositories;

public class CarRepository: BaseRepository, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> ListAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<IEnumerable<Car>> FindByParkingIdAsync(int parkingId)
    {
        return await _context.Cars
            .Where(p=>p.ParkingId==parkingId)
            .Include(p => p.Parking)
            .ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
    }
    
    public async Task<Car> FindByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }
    public async Task<Car> FindByCarName (string name)
    {
        return await _context.Cars
        .Include(p => p.Parking)
        .FirstOrDefaultAsync(p => p.name == name)
    }
    public void Update(Car car)
    {
        _context.Cars.Update(car);
    }

    public User FindById(int id)
    {
        return _context.Cars.Find(id);
    }

    public void Remove(Car car)
    {
        _context.Cars.Remove(car);
    }
}
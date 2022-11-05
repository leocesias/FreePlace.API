using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Repositories;

public interface IParkingRepository
{
    Task<IEnumerable<Parking>> ListAsync();
    Task AddAsync(Parking parking);
    Task<Parking> FindByIdAsync(int id);
    Task<IEnumerable<Parking>> FindByParkingIdAsync(int userId);
    void Update(Parking parking);
    void Remove(Parking parking);
}
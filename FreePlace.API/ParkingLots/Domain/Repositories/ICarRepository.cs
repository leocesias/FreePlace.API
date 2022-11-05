using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> ListAsync();
    Task AddAsync(Car car);
    Task<Car> FindByIdAsync(int id);
    void Update(Car car);
    void Remove(Car car);
}
using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> ListAsync();
    Task<IEnumerable<Car>> ListByParkingIdAsync(int ParkingId);
}
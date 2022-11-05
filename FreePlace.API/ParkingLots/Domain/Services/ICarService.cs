using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> ListAsync();
    Task<IEnumerable<Car>> ListByParkingIdAsync(int ParkingId);
    Task<CarResponse> SaveAsync(Car car);
    Task<CarResponse> UpdateAsync(int id, Car car);
    Task<CarResponse> DeleteAsync(int id);
}
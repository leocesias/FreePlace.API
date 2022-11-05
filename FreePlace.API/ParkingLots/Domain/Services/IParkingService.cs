using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface IParkingService
{
    Task<IEnumerable<Parking>> ListAsync();
    Task<ParkingResponse> SaveAsync(Car car);
    Task<ParkingResponse> UpdateAsync(int id, Car car);
    Task<ParkingResponse> DeleteAsync(int id);
}
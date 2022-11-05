using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface IParkingService
{
    Task<IEnumerable<Parking>> ListAsync();
    Task<ParkingResponse> SaveAsync(Parking parking);
    Task<ParkingResponse> UpdateAsync(int id, Parking parking);
    Task<ParkingResponse> DeleteAsync(int id);
}
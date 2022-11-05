using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Services;

public interface IParkingService
{
    Task<IEnumerable<Parking>> ListAsync();
}
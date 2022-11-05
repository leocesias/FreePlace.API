using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services.Communication;

public class CarResponse: BaseResponse<Car>
{
    public CarResponse(string message): base(message) {}
    public CarResponse(Car resource): base(resource) {}
}
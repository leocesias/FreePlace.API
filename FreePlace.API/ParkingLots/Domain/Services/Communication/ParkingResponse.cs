using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.ParkingLots.Domain.Services.Communication;

public class ParkingResponse: BaseResponse<Parking>
{
    public ParkingResponse(string message): base(message) {}
    public ParkingResponse(Parking resource): base(resource) {}
}
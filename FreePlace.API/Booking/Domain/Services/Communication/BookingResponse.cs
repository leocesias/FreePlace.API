using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Shared.Services.Communication;

namespace FreePlace.API.Booking.Domain.Services.Communication;

public class BookingResponse: BaseResponse<Booked>
{
    public BookingResponse(string message) : base(message) {}
    public BookingResponse(Booked resource) : base(resource) {}

}
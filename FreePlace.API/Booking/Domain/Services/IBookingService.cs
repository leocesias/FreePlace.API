using FreePlace.API.Booking.Domain.Services.Communication;

namespace FreePlace.API.Booking.Domain.Services;

public interface IBookingService
{
    Task<IEnumerable<Models.Booked>> ListAsync();
    Task<BookingResponse> SaveAsync(Models.Booked booked);
    Task<BookingResponse> UpdateAsync(int id, Models.Booked booked);
    Task<BookingResponse> DeleteAsync(int id);
}
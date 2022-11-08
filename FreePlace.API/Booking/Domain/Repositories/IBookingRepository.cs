using FreePlace.API.Booking.Domain.Models;

namespace FreePlace.API.Booking.Domain.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booked>> ListAsync();
    Task AddAsync(Booked booked);
    Task<Booked> FindByIdAsync(int id);
    void Update(Booked booked);
    void Remove(Booked booked);
}
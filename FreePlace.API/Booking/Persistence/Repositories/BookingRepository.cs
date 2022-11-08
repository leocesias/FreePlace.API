using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Repositories;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.Booking.Persistence.Repositories;

public class BookingRepository: BaseRepository, IBookingRepository
{
    public BookingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Booked>> ListAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task AddAsync(Booked booked)
    {
        await _context.Bookings.AddAsync(booked);
    }

    public async Task<Booked> FindByIdAsync(int id)
    { 
        return await _context.Bookings.FindAsync(id);
    }

    public void Update(Booked booked)
    {
        _context.Bookings.Update(booked);
    }

    public void Remove(Booked booked)
    {
        _context.Bookings.Remove(booked);
    }
}
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Repositories;
using FreePlace.API.Booking.Domain.Services;
using FreePlace.API.Booking.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.Booking.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<IEnumerable<Booked>> ListAsync()
    {
        return await _bookedRepository.ListAsync();
    }

    public async Task<BookingResponse> SaveAsync(Booked booked)
    {
        try
        {
            await _bookedRepository.AddAsync(booked);
            await _unitOfWork.CompleteAsync();
            return new BookingResponse(booked);
        }
        catch (Exception e)
        {
            return new BookingResponse($"An error occurred while saving the booking: {e.Message}");
        }
    }

    public async Task<BookingResponse> UpdateAsync(int id, Booked booked)
    {
        var existingBooked = await _bookedRepository.FindByIdAsync(id);
        if (existingBooked == null)
            return new BookingResponse("Booking not found");
        existingBooked.StartDate = booked.StartDate;
        existingBooked.EndDate = booked.EndDate;

        try
        {
            _bookedRepository.Update(existingBooked);
            await _unitOfWork.CompleteAsync();

            return new BookingResponse(existingBooked);
        }
        catch (Exception e)
        {
            return new BookingResponse($"An error occurred while updating the booking: {e.Message}");
        }
    }

    public async Task<BookingResponse> DeleteAsync(int id)
    {
        var existingBooked = await _bookedRepository.FindByIdAsync(id);
        if (existingBooked == null)
            return new BookingResponse("Booking not found");

        try
        {
            _bookedRepository.Remove(existingBooked);
            await _unitOfWork.CompleteAsync();

            return new BookingResponse(existingBooked);
        }
        catch (Exception e)
        {
            return new BookingResponse($"An error occurred while deleting the booking: {e.Message}");
        }
    }
}
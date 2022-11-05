using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.ParkingLots.Services;

public class ParkingService: IParkingService
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<IEnumerable<Parking>> ListAsync()
    {
        return await _parkingRepository.ListAsync();
    }

    public async Task<IEnumerable<Parking>> ListByUserIdAsync(int userId)
    {
        return await _parkingRepository.FindByParkingIdAsync(userId);
    }

    public async Task<ParkingResponse> SaveAsync(Parking parking)
    {
        try
        {
            await _parkingRepository.AddAsync(parking);
            await _unitOfWork.CompleteAsync();
            return new ParkingResponse(parking);
        }
        catch (Exception e)
        {
            return new ParkingResponse($"An error occurred while saving the parking: {e.Message}");
        }
    }

    public async Task<ParkingResponse> UpdateAsync(int id, Parking parking)
    {
        var existingParking = await _parkingRepository.FindByIdAsync(id);
        if (existingParking == null)
            return new ParkingResponse("Parking not found");
        //existingCar.Plate = car.Plate;
        existingParking.Description = parking.Description;
        existingParking.Price = parking.Price;
        existingParking.Capacity = parking.Capacity;

        try
        {
            _parkingRepository.Update(existingParking);
            await _unitOfWork.CompleteAsync();

            return new ParkingResponse(existingParking);
        }
        catch (Exception e)
        {
            return new ParkingResponse($"An error occurred while updating the parking: {e.Message}");
        }
    }

    public async Task<ParkingResponse> DeleteAsync(int id)
    {
        var existingParking = await _parkingRepository.FindByIdAsync(id);
        if (existingParking == null)
            return new ParkingResponse("Parking not found");

        try
        {
            _parkingRepository.Remove(existingParking);
            await _unitOfWork.CompleteAsync();

            return new ParkingResponse(existingParking);
        }
        catch (Exception e)
        {
            return new ParkingResponse($"An error occurred while deleting the parking: {e.Message}");
        }
    }
}
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Repositories;

namespace FreePlace.API.ParkingLots.Services;

public class CarService: ICarService
{

    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarService(IUnitOfWork unitOfWork, ICarRepository carRepository)
    {
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<Car>> ListAsync()
    {
        return await _carRepository.ListAsync();
    }

    public async Task<IEnumerable<Car>> ListByParkingIdAsync(int parkingId)
    {
        return await _carRepository.FindByParkingIdAsync(parkingId);
    }

    public async Task<CarResponse> SaveAsync(Car car)
    {
        try
        {
            await _carRepository.AddAsync(car);
            await _unitOfWork.CompleteAsync();
            return new CarResponse(car);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while saving the car: {e.Message}");
        }
    }

    public async Task<CarResponse> UpdateAsync(int id, Car car)
    {
        var existingCar = await _carRepository.FindByIdAsync(id);
        if (existingCar == null)
            return new CarResponse("Car not found");
        //existingCar.Plate = car.Plate;
        existingCar.ParkedTime = car.ParkedTime;

        try
        {
            _carRepository.Update(existingCar);
            await _unitOfWork.CompleteAsync();

            return new CarResponse(existingCar);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while updating the car: {e.Message}");
        }
    }

    public async Task<CarResponse> DeleteAsync(int id)
    {
        var existingCar = await _carRepository.FindByIdAsync(id);
        if (existingCar == null)
            return new CarResponse("Car not found");

        try
        {
            _carRepository.Remove(existingCar);
            await _unitOfWork.CompleteAsync();

            return new CarResponse(existingCar);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while deleting the car: {e.Message}");
        }
    }
}
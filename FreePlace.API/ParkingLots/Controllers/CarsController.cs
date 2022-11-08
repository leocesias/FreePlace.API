using AutoMapper;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.Shared.Extensions;
using FreePlace.API.Shared.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.ParkingLots.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;
    
    public CarsController(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CarResource>> GetAllAsync()
    {
        var cars = await _carService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var car = _mapper.Map<SaveCarResource, Car>(resource);

        var result = await _carService.SaveAsync(car);

        if (!result.Success)
            return BadRequest(result.Message);

        var carResource = _mapper.Map<Car, CarResource>(result.Resource);

        return Ok(carResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var car = _mapper.Map<SaveCarResource, Car>(resource);

        var result = await _carService.UpdateAsync(id, car);

        if (!result.Success)
            return BadRequest(result.Message);

        var carResource = _mapper.Map<Car, CarResource>(result.Resource);

        return Ok(carResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _carService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var carResource = _mapper.Map<Car, CarResource>(result.Resource);

        return Ok(carResource);
    }
}
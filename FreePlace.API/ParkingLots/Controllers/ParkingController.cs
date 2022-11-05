using AutoMapper;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Domain.Services.Communication;
using FreePlace.API.Shared.Extensions;
using FreePlace.API.Shared.Resources;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.ParkingLots.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ParkingController: ControllerBase
{
    private readonly IParkingService _parkingService;
    private readonly IMapper _mapper;

    public ParkingController(IParkingService parkingService, IMapper mapper)
    {
        _parkingService = parkingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ParkingResource>> GetAllAsync()
    {
        var parkings = await _parkingService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Parking>, IEnumerable<ParkingResource>>(parkings);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveParkingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var parking = _mapper.Map<SaveParkingResource, Parking>(resource);

        var result = await _parkingService.SaveAsync(parking);

        if (!result.Success)
            return BadRequest(result.Message);

        var parkingResource = _mapper.Map<Parking, ParkingResource>(parking);

        return Ok(parkingResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveParkingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var parking = _mapper.Map<SaveParkingResource, Parking>(resource);

        var result = await _parkingService.UpdateAsync(id, parking);

        if (!result.Success)
            return BadRequest(result.Message);

        var parkingResource = _mapper.Map<Parking, ParkingResource>(result.Resource);

        return Ok(parkingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _parkingService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var parkingResource = _mapper.Map<Parking, ParkingResource>(result.Resource);

        return Ok(parkingResource);
    }
}
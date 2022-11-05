using AutoMapper;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.Shared.Resources;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.ParkingLots.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/parking")]
public class UserParkingController : ControllerBase
{
    private readonly IParkingService _parkingService;
    private readonly IMapper _mapper;

    public UserParkingController(IParkingService parkingService, IMapper mapper)
    {
        _parkingService = parkingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ParkingResource>> GetAllParkingsByUserId(int userId)
    {
        var parking = await _parkingService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Parking>, IEnumerable<ParkingResource>>(parking);
        return resources;
    }
}

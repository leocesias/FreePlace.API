using AutoMapper;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Services;
using FreePlace.API.Booking.Resources;
using FreePlace.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.Booking.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BookingController: ControllerBase
{
    
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;

    public BookingController(IBookingService bookingService, IMapper mapper)
    {
        _bookingService = bookingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BookingResource>> GetAllAsync()
    {
        var bookings = await _bookingService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Booked>, IEnumerable<BookingResource>>(bookings);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBookingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var booked = _mapper.Map<SaveBookingResource, Booked>(resource);

        var result = await _bookingService.SaveAsync(booked);

        if (!result.Success)
            return BadRequest(result.Message);

        var bookingResource = _mapper.Map<Booked, BookingResource>(result.Resource);

        return Ok(bookingResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBookingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var booked = _mapper.Map<SaveBookingResource, Booked>(resource);

        var result = await _bookingService.UpdateAsync(id, booked);

        if (!result.Success)
            return BadRequest(result.Message);

        var bookingResource = _mapper.Map<Booked, BookingResource>(result.Resource);

        return Ok(bookingResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookingService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var bookingResource = _mapper.Map<Booked, BookingResource>(result.Resource);

        return Ok(bookingResource);
    }
}
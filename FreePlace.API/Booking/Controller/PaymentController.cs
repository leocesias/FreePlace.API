﻿using AutoMapper;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Domain.Services.Communication;
using FreePlace.API.Booking.Resources;
using FreePlace.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.Booking.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class PaymentController: ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

        var result = await _paymentService.SaveAsync(payment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Ok(paymentResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

        var result = await _paymentService.UpdateAsync(id, payment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Ok(paymentResource);
    }
}
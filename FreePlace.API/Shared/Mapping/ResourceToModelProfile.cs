using AutoMapper;
using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.Booking.Resources;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Resources;

namespace FreePlace.API.Shared.Mapping;

public class ResourceToModelProfile: Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveCarResource, Car>();

        CreateMap<SaveParkingResource, Parking>();

        CreateMap<SaveUserResource, User>();

        CreateMap<SaveBookingResource, Booked>();
    }
}
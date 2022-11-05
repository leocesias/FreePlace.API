using System.Runtime.CompilerServices;
using AutoMapper;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Resources;

namespace FreePlace.API.Shared.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Car, CarResource>();

        CreateMap<Parking, ParkingResource>();

        CreateMap<User, UserResource>();
    }
}
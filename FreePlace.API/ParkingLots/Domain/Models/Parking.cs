using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Models;

public class Parking
{
    public int Id { set; get; }
    public int Capacity { set; get; }
    public string Description { set; get; }
    public string Ubication { set; get; }
    public float Price { set; get; }

    //Relationships
    public int CarId { set; get; }
    public Car Car;
    
    //User from Shared
    public long UserId { set; get; }
    public User User;

}
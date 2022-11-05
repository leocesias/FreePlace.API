using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.ParkingLots.Domain.Models;

public class Car
{
    public int Id { set; get; }
    public string Plate { set; get; }
    public float ParkedTime { set; get; }
    
    //Relationships
    
    public int ParkingId { get; set; }
    public Parking Parking { get; set; }
    public IList<Parking> Parkings { set; get; } = new List<Parking>();
    
    //User from Shared
    public long UserId { set; get; }
    public User User;

}
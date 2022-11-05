namespace FreePlace.API.ParkingLots.Domain.Models;

public class Car
{
    public int Id { set; get; }
    public string Plate { set; get; }
    public float ParkedTime { set; get; }
    
    //Relationships

    public IList<Parking> Parkings { set; get; } = new List<Parking>();

}
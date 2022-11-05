using FreePlace.API.ParkingLots.Domain.Models;

namespace FreePlace.API.Shared.Domain.Models;

public class User
{
    public long Id { set; get; }
    public string Name { set; get; }
    public string LastName { set; get; }
    public short Age { set; get; }
    public long Phone { set; get; }
    
    //Relationships

    public IList<Parking> Parkings { set; get; } = new List<Parking>();
    public IList<Car> Cars { set; get; } = new List<Car>();
    // Missing add Security, Booking and History ---
}
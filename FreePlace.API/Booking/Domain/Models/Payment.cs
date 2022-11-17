using FreePlace.API.Shared.Domain.Models;

namespace FreePlace.API.Booking.Domain.Models;

public class Payment
{
    public int TransactionId { set; get; }
    public string Description { set; get; }
    public float Value = 30;

    //Relationships

    public long UserId { set; get; }
    public User User { set; get; }
    
}
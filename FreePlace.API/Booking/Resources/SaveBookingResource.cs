using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Booking.Resources;

public class SaveBookingResource
{
    [Required] 
    public DateTime StartDate { get; set; }
    
    [Required] 
    public DateTime EndDate { get; set; }

}
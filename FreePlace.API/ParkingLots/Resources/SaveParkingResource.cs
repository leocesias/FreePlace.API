using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Shared.Resources;

public class SaveParkingResource
{
    [Required]
    [MaxLength(250)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Ubication { get; set; }
    
    [Required]
    public float Price { get; set; }
    
    [Required]
    public int Capacity { get; set; }
    
}
using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Shared.Resources;

public class SaveCarResource
{
    [Required]
    [MaxLength(10)]
    public string Plate { get; set; }
    
    [Required]
    public int ParkedTime { get; set; }
}
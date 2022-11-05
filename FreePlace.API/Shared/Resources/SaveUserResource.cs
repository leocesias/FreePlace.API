using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Shared.Resources;

public abstract class SaveUserResource
{
    [Required]
    [MaxLength(40)]
    public string Name { set; get; }
    
    [Required]
    [MaxLength(40)]
    public string LastName { set; get; }
    
    [Required]
    public short Age { set; get; }
    
    [Required]
    public long Phone { set; get; }
}
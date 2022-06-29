using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Models;

public class Image
{
    [Required]
    public IFormFile imageContent { get; set; }
}
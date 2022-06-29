using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Models;

public class Student
{
    [Required(ErrorMessage = "ID is required")]
    [Range(0, int.MaxValue, ErrorMessage = "ID cannot be negative")]

    public int? Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30)]

    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [StringLength(30)]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]

    public string? Email { get; set; }
    
  
    /*
    public Student(int a, string s1, string s2)
    {
        this.Id = a;
        this.Name = s1;
        this.Email = s2;
    }
    */


}
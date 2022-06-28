using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Models;

public class Student
{
    [Required] public int? Id { get; set; }
    [Required]

    public string? Name { get; set; }
    [Required]
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
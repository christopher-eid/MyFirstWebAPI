using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Exceptions;
using MyFirstWebAPI.Interfaces;
using MyFirstWebAPI.Models;


namespace MyFirstWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private IStudentHelper _studentHelper;
    
    public  List<Student> Students;

    public StudentController(IStudentHelper studentHelper)
    {
        _studentHelper = studentHelper;
        Students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Email = "chris.302@outlook.com",
                Name = "chris"
            },
            new Student()
            {
                Id = 2,
                Email = "chris.312@outlook.com",
                Name = "chris"
            },
            new Student()
            {
                Id = 3,
                Email = "sarah.302@gmail.com",
                Name = "sarah"
            }
        };
    }

    [HttpGet("GetAllStudents")]
    public async Task<List<Student>> GetAllStudents()
    {
        return _studentHelper.GetAllStudentsHelper(Students);
    }
 
    
    [HttpGet("GetStudentById~/{id}")]
    public async Task<Student> GetStudentById([FromRoute] long id )
    {
       
        return _studentHelper.GetStudentByIdHelper(id, Students);
    }


    [HttpGet("GetStudentsByName")]
    public async Task<List<Student>> GetStudentsByName([FromQuery] string enteredName)
    {
        return _studentHelper.GetStudentsByNameHelper(enteredName, Students);
    }
    
    
    
    [HttpGet("GetDate")]
    public async Task<string> GetDate([FromHeader] string format)
    {
        return _studentHelper.GetDateHelper(format);
    }
    
    
    
    
    
    
    
    

    [HttpPost("ChangeStudentName")]
    public async Task<Student[]> ChangeStudentName([FromBody] Student request)
    {
        
        foreach (Student std in Students)
        {   
            if (std.Id == request.Id && std.Email == request.Email)
            {
                std.Name = request.Name;
            }
        }


        return Students.ToArray();

    }

    
    /*
    private readonly ILogger<StudentController> _logger;
    */

    /*
    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }
    */
}
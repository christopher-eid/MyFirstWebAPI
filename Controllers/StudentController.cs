
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Interfaces;
using MyFirstWebAPI.Models;


namespace MyFirstWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private IStudentHelper _studentHelper;
    
    public static List<Student> Students;

    public StudentController(IStudentHelper studentHelper)
    {
        _studentHelper = studentHelper;
        Students = new List<Student>()
        {
            new Student()
            {
                Id = 1, Email = "chris.302@outlook.com", Name = "chris"
            },
            new Student()
            {
                Id = 2, Email = "sarah.302@outlook.com", Name = "sarah"
            }, 
            new Student()
            {
                Id = 3, Email = "elie.302@outlook.com", Name = "elie"
            },
        };
    }

    [HttpGet("GetAllStudents")]
    public async Task<List<Student>> GetAllStudents()
    {
        return _studentHelper.GetAllStudentsHelper(Students);
    }
 
    
    [HttpGet("GetStudentById/{id}")]
    public async Task<Student> GetStudentById([FromRoute] int id )
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
    public async Task<List<Student>> ChangeStudentName([FromBody] Student request)
    {
        return _studentHelper.ChangeStudentNameHelper(request, Students);

    }


    
    [HttpPost("UploadPhoto")]
    public async Task<Image> UploadPhoto([FromForm] Image fileReceived)
    {
       return _studentHelper.UploadPhotoHelper(fileReceived);
       
    }

    [HttpDelete("DeleteStudent/{id}")]
    public async Task<Student> DeleteStudent([FromRoute]int id)
    {
        return _studentHelper.DeleteStudentHelper(id, Students);
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
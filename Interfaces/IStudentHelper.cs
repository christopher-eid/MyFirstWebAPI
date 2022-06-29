using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Interfaces;

public interface IStudentHelper
{
    public List<Student> GetAllStudentsHelper(List<Student> stds);
    public Student GetStudentByIdHelper(int id, List<Student> stds);

    public List<Student> GetStudentsByNameHelper(string enteredName, List<Student> stds);

    public string GetDateHelper(string format);

    
    public List<Student> ChangeStudentNameHelper(Student stdToFind, List<Student> stds);

    public Image UploadPhotoHelper(Image fileReceived);
}
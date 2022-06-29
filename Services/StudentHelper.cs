using System.Globalization;
using MyFirstWebAPI.Exceptions;
using MyFirstWebAPI.Interfaces;
using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Services;








public class StudentHelper : IStudentHelper
{

    /*
    public const Student = new Student(0 , "none", "none");
    */


    public List<Student> GetAllStudentsHelper(List<Student> stds)
    {
        return stds;
    }


//hello






    public Student GetStudentByIdHelper(int id, List<Student> stds)
    {

        try
        {

            foreach (Student std in stds)
            {
                if (std.Id == id)
                {
                    return std;
                }
            }


            throw new StudentNotFoundException("Student Not Found");
        }
        catch (StudentNotFoundException e)
        {

            Console.WriteLine("Error: {0}", e);

        }

        return new Student() {Id = 0 , Email = "none", Name = "none"};


    }

    

    public List<Student> GetStudentsByNameHelper(string enteredName, List<Student> stds)
    {

        List<Student> studentsFound = new List<Student>();
        foreach (Student std in stds)
        {
            if (String.Equals(std.Name, enteredName, StringComparison.CurrentCultureIgnoreCase)) //compares names with case INSENSITIVE
            {
                studentsFound.Add(std);
            }
        }

        return studentsFound;
    }


    public string GetDateHelper(string format)
    {

        DateTime myDate = DateTime.Now;
        string s = "error";
        switch (format)
        {
            case "en-US":
                s = myDate.ToString(new CultureInfo("en-US"));
                break;
            case "es-ES":
                s = myDate.ToString(new CultureInfo("es-ES"));
                break;
            case "fr-FR":
                s = myDate.ToString(new CultureInfo("fr-FR"));
                break;
            default:
                //throw exception here
                break;
        }

        
        return s;




    }


    
    public List<Student> ChangeStudentNameHelper(Student stdToFind, List<Student> stds)
    {

        bool found = false;
        foreach (Student std in stds)
        {   
            if (std.Id == stdToFind.Id && String.Equals(std.Email, stdToFind.Email, StringComparison.CurrentCultureIgnoreCase)) //checks for both id and email
            {
                std.Name = stdToFind.Name;
                found = true;

            }
        }

        if (!found)
        {
            //throw error in case we did not find the student

        }
        return stds;
      
    }


    public Image UploadPhotoHelper(Image fileReceived)
    {
        
        string pathToStore = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Images", fileReceived.imageContent.FileName);
        string fileType = Path.GetExtension(fileReceived.imageContent.FileName);
        string[] allowedTypes = new string[] { ".JPG", ".JPEG", ".RAW" };
        if (Array.IndexOf(allowedTypes, fileType) > -1)
        {
            
            
            using (var uploading = new FileStream(pathToStore, FileMode.Create))
            {
                fileReceived.imageContent.CopyToAsync(uploading);
            }
        }
        
        return fileReceived;
    }



}
using System.Globalization;
using MyFirstWebAPI.Controllers;
using MyFirstWebAPI.Exceptions;
using MyFirstWebAPI.Interfaces;
using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Services;








public class StudentHelper : IStudentHelper
{




    public List<Student> GetAllStudentsHelper(List<Student> stds)
    {
        return stds;
    }









    public Student GetStudentByIdHelper(long id, List<Student> stds)
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

        return null;


    }




    public List<Student> GetStudentsByNameHelper(string enteredName, List<Student> stds)
    {

        List<Student> studentsFound = new List<Student>();
        foreach (Student std in stds)
        {
            if (String.Compare(std.Name, enteredName) == 0)
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
}
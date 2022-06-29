using System.ComponentModel.DataAnnotations;
using System.Globalization;
using MyFirstWebAPI.Exceptions;
using MyFirstWebAPI.Interfaces;
using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Services;








public class StudentHelper : IStudentHelper
{

    
    public static readonly Student NotFound = new Student(){Id = 0, Name = "NOT_FOUND", Email = "NOT_FOUND"};
    


    public List<Student> GetAllStudentsHelper(List<Student> stds)
    {
        return stds;
    }


//hello






    public Student GetStudentByIdHelper(int id, List<Student> stds)
    {

        Student returnedStudent = NotFound;
        try
        {

            foreach (Student std in stds)
            {
                if (std.Id == id)
                {
                    returnedStudent = std;
                }
            }

            
            throw new StudentNotFoundException("Student Not Found");
        }
        catch (StudentNotFoundException e)
        {

            Console.WriteLine("Error: {0}", e);

        }

        return returnedStudent; //returnedStudent will either be the student we found or the "notFound" student 


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
        //no need to throw exception if no students found since it will return an empty list
        return studentsFound;
    }


    public string GetDateHelper(string format)
    {
        string s = "error";

        try
        {
            DateTime myDate = DateTime.Now;
            bool supported = false;
            foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.AllCultures)) //going through all cultures to check if the entered format is supported
            {
                if (String.Equals(c.ToString(), format))
                {
                    supported = true;
                }
            }

            //Array.IndexOf(CultureInfo.GetCultures(CultureTypes.AllCultures), format) > -1
            if (supported)
            {
                s = myDate.ToString(new CultureInfo(format));
            }
            else
            {
                s = "This Culture Format is not supported";
                throw new NotSupportedException("This Culture Format is Not supported");

            }

        }
        catch (NotSupportedException e)
        {
            Console.WriteLine("Error: {0}", e);
        }

        return s;


    }


    
    public List<Student> ChangeStudentNameHelper(Student stdToFind, List<Student> stds)
    {
        try
        {
            bool found = false;
            foreach (Student std in stds)
            {
                if (std.Id == stdToFind.Id &&
                    String.Equals(std.Email, stdToFind.Email,
                        StringComparison.CurrentCultureIgnoreCase)) //checks for both id and email
                {
                    std.Name = stdToFind.Name;
                    found = true;

                }
            }

            if (!found)
            {
                throw new StudentNotFoundException("Requested student was not found");

            }
        }
        catch (StudentNotFoundException e)
        {
            Console.WriteLine("Error: {0}", e);
        }


        return stds; //no need to return an error since the user will notice himself that student name did not change
    }


    public Object UploadPhotoHelper(Image fileReceived)
    {
        try
        {
            string pathToStore = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images",
                fileReceived.imageContent.FileName);
            string fileType = Path.GetExtension(fileReceived.imageContent.FileName);
            string[] allowedTypes = new string[] { ".JPG", ".JPEG", ".RAW" };
            if (Array.IndexOf(allowedTypes, fileType) > -1)
            {


                using (var uploading = new FileStream(pathToStore, FileMode.Create))
                {
                    fileReceived.imageContent.CopyToAsync(uploading);
                }

                return fileReceived;
            }

            throw new NotSupportedException("Please enter a file of the following types: jpg - jpeg - raw");
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine("Error: {0}", e);
        }

        return "Please enter a file of the following types: jpg - jpeg - raw";
    }


    public Student DeleteStudentHelper(int id, List<Student> stds)
    {
        Student returnedStudent = NotFound;
        bool found = false;
        try
        {
            foreach (Student std in stds)
            {
                if (std.Id == id)
                {
                    returnedStudent = std;
                    found = true;
                    stds.Remove(std);
                    break; //use break since after deleting student from the list, if we continue the loop we will have an error "collection is modified"
                }
            }

            if (!found)
            {
                throw new StudentNotFoundException("Requested student was not found");
            }

        }
        catch (StudentNotFoundException e)
        {
            Console.WriteLine("Error: {0}", e); 
        }
        
        return returnedStudent;
        

        
    }

}
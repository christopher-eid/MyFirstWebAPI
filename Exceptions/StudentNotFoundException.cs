using System.Net;

namespace MyFirstWebAPI.Exceptions;
class StudentNotFoundException : Exception
{
    public StudentNotFoundException() {  }

    public StudentNotFoundException(string message)
        : base(String.Format("Student Not found: {0}", message))
    {

    }
}
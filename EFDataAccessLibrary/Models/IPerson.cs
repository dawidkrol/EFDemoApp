using System.Collections.Generic;

namespace EFDataAccessLibrary.Models
{
    public interface IPerson
    {
        int Age { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
    }
}
using System.Collections.Generic;

namespace EFDataAccessLibrary.Models
{
    public interface IAdresses
    {
        List<Address> Addresses { get; set; }
    }
}
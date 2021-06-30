using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Person : PersonBase,IPerson, IAdresses
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}

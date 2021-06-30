using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Employee : PersonBase,IPerson,IPosition
    {
        [Required]
        [MaxLength(10)]
        public string Position { get; set; }
        public List<Email> EmailAdressess { get; set; } = new List<Email>();
    }
}

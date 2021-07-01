using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Models
{
    public class WorkDone
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string NameOfWork { get; set; }
        [Required]
        public TimeSpan TimeOfWork { get; set; }
    }
}
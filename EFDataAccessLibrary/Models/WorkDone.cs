using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Models
{
    public class WorkDone : IEquatable<WorkDone>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string NameOfWork { get; set; }
        [Required]
        public TimeSpan TimeOfWork { get; set; }

        public bool Equals(WorkDone other)
        {
            if (other.NameOfWork == NameOfWork)
                return true;

            return false;
        }
    }
}
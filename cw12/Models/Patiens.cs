using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cw12.Models
{
    public partial class Patiens
    {
        public Patiens()
        {
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int IdPatient { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
    }
}

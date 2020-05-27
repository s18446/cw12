using System;
using System.Collections.Generic;

namespace cw12.Models
{
    public partial class Patiens
    {
        public Patiens()
        {
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
    }
}

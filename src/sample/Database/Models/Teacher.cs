using System;
using System.Collections.Generic;

namespace sample.Database.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classrooms = new HashSet<Classroom>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}

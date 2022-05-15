using System;
using System.Collections.Generic;

namespace sample.Database.Models
{
    public partial class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int GradeLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IndividuelltProjekt.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int KursId { get; set; }
        public string KursNamn { get; set; } = null!;
        public string? KursBeskrivning { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

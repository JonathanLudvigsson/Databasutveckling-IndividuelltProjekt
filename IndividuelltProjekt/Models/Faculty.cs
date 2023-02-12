using System;
using System.Collections.Generic;

namespace IndividuelltProjekt.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int FacultyId { get; set; }
        public string Personnummer { get; set; } = null!;
        public string Fnamn { get; set; } = null!;
        public string Lnamn { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Email { get; set; }
        public int? JobId { get; set; }
        public DateTime? AnställdDatum { get; set; }
        public decimal? Lön { get; set; }

        public virtual Job? Job { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

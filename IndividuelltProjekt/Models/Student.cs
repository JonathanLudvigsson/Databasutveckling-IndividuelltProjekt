using System;
using System.Collections.Generic;

namespace IndividuelltProjekt.Models
{
    public partial class Student
    {
        public Student()
        {
            ClassStudents = new HashSet<ClassStudent>();
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int StudentId { get; set; }
        public string Personnummer { get; set; } = null!;
        public string Fnamn { get; set; } = null!;
        public string Lnamn { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

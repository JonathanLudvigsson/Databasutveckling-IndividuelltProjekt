using System;
using System.Collections.Generic;

namespace IndividuelltProjekt.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassStudents = new HashSet<ClassStudent>();
        }

        public int KlassId { get; set; }
        public string? KlassNamn { get; set; }
        public string? KlassInriktning { get; set; }
        public bool? ÄrAktiv { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}

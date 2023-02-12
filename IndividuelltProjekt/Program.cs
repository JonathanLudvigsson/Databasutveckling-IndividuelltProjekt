using IndividuelltProjekt.Data;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace IndividuelltProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolDBContext context = new SchoolDBContext();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?\n-1 Visa all personal\n-2 Visa alla studenter\n-3 Visa alla aktiva kurser");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        CountWorkers(context);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        ShowStudentInformation(context);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        ShowCourses(context);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Fel input");
                        break;
                }

            }

        }
        static void CountWorkers(SchoolDBContext context)
        {
            foreach (var job in context.Jobs)
            {
                var jobCount = context.Faculties.Where(x => x.JobId == job.JobId).Count();
                var jobName = context.Jobs.Where(x => x.JobId == job.JobId).Select(x => x.JobNamn).FirstOrDefault();
                Console.WriteLine($"{jobName} - {jobCount}");
                foreach (var person in context.Faculties.OrderBy(x => x.Fnamn))
                {
                    if (person.JobId == job.JobId)
                        Console.WriteLine($"{person.Fnamn} {person.Lnamn}");
                }
                Console.WriteLine();
            }
        }
        static void ShowStudentInformation(SchoolDBContext context)
        {
            Console.WriteLine("Elever:");
            List<string> studentList = new List<string>();
            foreach (var student in context.Students)
            {
                var studentClassConnectionID = context.ClassStudents.Where(x => x.StudentId == student.StudentId).Select(x => x.KlassId).FirstOrDefault();
                var studentClass = context.Classes.Where(x => x.KlassId == studentClassConnectionID).Select(x => x.KlassNamn).FirstOrDefault();
                studentList.Add($"{studentClass} - {student.Fnamn} {student.Lnamn} - {student.Email} - {student.Adress}");
            }
            studentList.Sort();
            foreach (string item in studentList)
            {

                Console.WriteLine(item);
            }
        }
        static void ShowCourses(SchoolDBContext context)
        {
            Console.WriteLine("Kurser");
            foreach (var course in context.Classes.OrderBy(x => x.KlassNamn).Where(x => x.ÄrAktiv == true))
            {
                Console.WriteLine($"{course.KlassNamn} - {course.KlassInriktning}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.DataAccess.Core;
using CodeFirst.DataAccess.Models;

namespace CodeFirst.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting App");

            //SaveStudent();
            GetAllStudents();
            //GetStudentById();
            //DeleteStudentId();

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        private static void SaveStudent()
        {
            using (var mainContext = new AppContextMain())
            {
                mainContext.Students.Add(new Student
                {
                    Name = "Leng Ganda",
                    Status = "Active"
                });

                mainContext.SaveChanges();
            }

            Console.WriteLine("Student Saved!");
        }

        private static void GetAllStudents()
        {
            using (var mainContext = new AppContextMain())
            {
                var studentList = mainContext.Students;

                foreach (var student in studentList)
                {
                    Console.WriteLine("{0} - {1}", student.Id, student.Name);
                }
            }
        }

        private static void GetStudentById()
        {
            using (var mainContext = new AppContextMain())
            {
                var student = mainContext.Students.Where(x => x.Id == 7).FirstOrDefault();

                Console.WriteLine("{0} - {1}", student.Id, student.Name);
            }
        }

        private static void DeleteStudentId()
        {
            using (var mainContext = new AppContextMain())
            {
                var student = mainContext.Students.FirstOrDefault(x => x.Id == 7);

                if (student != null)
                {
                    mainContext.Students.Remove(student);
                    mainContext.SaveChanges();

                    Console.WriteLine("Student Deleted");
                }
            }
        }
    }
}

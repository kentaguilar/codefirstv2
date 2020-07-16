using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.DataAccess.Core;
using CodeFirst.DataAccess.Models;
using System.Linq;

namespace CodeFirst.Tests.Models
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void SaveStudent_Test()
        {
            using (var mainContext = new AppContextMain())
            {
                mainContext.Students.Add(new Student
                {                    
                    Name = "Marc Griffin",
                    Status = "Active"
                });

                mainContext.SaveChanges();
            }

            Assert.Inconclusive("Student Saved");
        }

        [TestMethod]
        public void GetAllStudents_Test()
        {
            using (var mainContext = new AppContextMain())
            {
                var studentList = mainContext.Students;

                Assert.AreEqual(10, studentList.Count());
            }
        }

        [TestMethod]
        public void GetStudentById_Test()
        {
            using (var mainContext = new AppContextMain())
            {
                var student = mainContext.Students.Where(x => x.Id == 6).FirstOrDefault();

                Assert.AreEqual("test name", student.Name);
            }
        }

        [TestMethod]
        public void DeleteStudentId_Test()
        {
            using (var mainContext = new AppContextMain())
            {
                var student = mainContext.Students.FirstOrDefault(x => x.Id == 6);
                mainContext.Students.Remove(student);
                mainContext.SaveChanges();

                Assert.Inconclusive("Student Deleted");
            }
        }
    }
}

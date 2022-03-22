using interview_test_angular.Models.Students;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_test_angular.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new();
        private int studentCount = 0;
        private readonly ILogger _logger;

        public StudentsService(ILogger<StudentsService> logger)
        {
            _logger = logger;

            students.Add(new Student
            {
                StudentID = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                Average = 90
            });

            students.Add(new Student
            {
                StudentID = 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                Average = 80
            });

            students.Add(new Student
            {
                StudentID = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                Average = 70
            });

            students.Add(new Student
            {
                StudentID = 4,
                FirstName = "John",
                LastName = "Smith",
                Email = "js@test.com",
                Major = "Music",
                Average = 40
            });

            studentCount = students.Count;
        }

        /// <summary>
        /// Adds a new student to the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddStudent(Student student)
        {
            try
            {
                if (students.Any(s => s.StudentID == student.StudentID))
                {
                    _logger.LogInformation("ID of the student already exists.");

                    return false;
                }
                else
                {
                    student.StudentID = students.Max(s => s.StudentID) + 1;
                    students.Add(student);

                    _logger.LogInformation("Student successfully added.");

                    return true;
                }                
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred while adding a student.");

                return false;
            }
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteStudent(Student student)
        {
            int count = studentCount;
            try
            {
                if (students.Any(s => s.StudentID == student.StudentID))
                {
                    students.RemoveAll(s => s.StudentID == student.StudentID);
                }

                if (count != studentCount)
                {
                    _logger.LogInformation("Student successfully deleted.");

                    return true;
                }

                _logger.LogInformation("Deleting student was not successful.");

                return false;
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred while deleting a student.");

                return false;
            }
        }

        /// <summary>
        /// Returns all of the students currently in the system
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}

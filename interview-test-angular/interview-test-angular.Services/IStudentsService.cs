﻿using interview_test_angular.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_test_angular.Services
{
    public interface IStudentsService
    {
        List<Student> GetAllStudents();

        bool AddStudent(Student student);

        bool DeleteStudent(Student student);
    }
}

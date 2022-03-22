using interview_test_angular.Models.Students;
using interview_test_angular.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace interview_test_angular.Mediatr.Students
{
    public class AddStudentRequest : IRequest<AddStudentResponse>
    {
        public Student Student { get; set; }
    }

    public class AddStudentResponse
    {
        public bool IsAddSuccess { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentRequest, AddStudentResponse>
    {
        private IStudentsService _studentService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentService = studentsService;
        }

        public Task<AddStudentResponse> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            var response = new AddStudentResponse
            {
                IsAddSuccess = _studentService.AddStudent(request.Student)
            };

            return Task.FromResult(response);
        }
    }
}

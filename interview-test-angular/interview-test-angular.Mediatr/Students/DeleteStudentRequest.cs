using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using interview_test_angular.Models.Students;
using interview_test_angular.Services;
using MediatR;


namespace interview_test_angular.Mediatr.Students
{
    public class DeleteStudentRequest : IRequest<DeleteStudentResponse>
    {
        public Student Student { get; set; }
    }
    public class DeleteStudentResponse
    {
        public bool IsDeleteSuccess { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
    {
        private IStudentsService _studentService;
        public DeleteStudentHandler(IStudentsService studentservice)
        {
            _studentService = studentservice;
        }

        public Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteStudentResponse
            {
                IsDeleteSuccess = _studentService.DeleteStudent(request.Student)
            };

            return Task.FromResult(response);        
        }
    }
}

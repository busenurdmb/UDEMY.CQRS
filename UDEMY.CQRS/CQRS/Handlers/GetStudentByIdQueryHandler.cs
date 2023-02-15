using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UDEMY.CQRS.CQRS.Queries;
using UDEMY.CQRS.CQRS.Results;
using UDEMY.CQRS.Data;

namespace UDEMY.CQRS.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler:IRequestHandler<GetStudentByIdQuery,GetStudentByIdQueryResult>
    {
        private readonly StudentContext _Context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _Context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student =await _Context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                SurName = student.SurName
            };
        }
        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _Context.Set<Student>().Find(query.Id);
        //    return new GetStudentByIdQueryResult
        //    {
        //        Age = student.Age,
        //        Name = student.Name,
        //        SurName = student.SurName
        //    };
        //}
    }
}

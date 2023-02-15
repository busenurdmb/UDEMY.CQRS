using MediatR;
using UDEMY.CQRS.CQRS.Results;

namespace UDEMY.CQRS.CQRS.Queries
{
    public class GetStudentByIdQuery:IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}

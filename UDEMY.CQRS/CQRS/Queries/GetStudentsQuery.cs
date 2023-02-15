using MediatR;
using System.Collections.Generic;
using UDEMY.CQRS.CQRS.Results;

namespace UDEMY.CQRS.CQRS.Queries
{
    public class GetStudentsQuery:IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}

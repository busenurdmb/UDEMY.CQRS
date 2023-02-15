using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UDEMY.CQRS.CQRS.Queries;
using UDEMY.CQRS.CQRS.Results;
using UDEMY.CQRS.Data;

namespace UDEMY.CQRS.CQRS.Handlers
{
    public class GetStudentsQueryHandler:IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var data =await _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, SurName = x.SurName }).AsNoTracking().ToListAsync();
            return data;
              //return await _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, SurName = x.SurName }).AsNoTracking().AsAsyncEnumerable();
        }
        //public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        //{
        //    return _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, SurName = x.SurName }).AsNoTracking().AsEnumerable();

        //}
    }
}

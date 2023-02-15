using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UDEMY.CQRS.CQRS.Commands;
using UDEMY.CQRS.Data;

namespace UDEMY.CQRS.CQRS.Handlers
{
    public class RemoveStudentCommandHandler:IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        //public void Handle(RemoveStudentCommand command)
        //{
        //    var deletedEntity = _context.Students.Find(command.Id);
           
        //    _context.Remove(deletedEntity);
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity =await _context.Students.FindAsync(request.Id);

           _context.Remove(deletedEntity);
           await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

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
    public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        //public void Handle(UpdateStudentCommand command)
        //{
        //  var updatedentity=  _context.Students.Find(command.Id);
        //    updatedentity.Name = command.Name;
        //    updatedentity.SurName = command.SurName;
        //    updatedentity.Age = command.Age;
        //    _context.SaveChanges();

        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedentity = await _context.Students.FindAsync(request.Id);
            updatedentity.Name = request.Name;
            updatedentity.SurName = request.SurName;
            updatedentity.Age = request.Age;
           await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

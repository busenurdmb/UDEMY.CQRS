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
    public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        //public void Handle(CreateStudentCommand command)
        //{
        //    _context.Students.Add(new Student {Name=command.Name,SurName=command.SurName,Age=command.Age });
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
           await _context.Students.AddAsync(new Student { Name = request.Name, SurName = request.SurName, Age = request.Age });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

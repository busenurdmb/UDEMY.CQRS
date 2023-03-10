using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDEMY.CQRS.CQRS.Commands
{
    public class RemoveStudentCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int id)
        {
            Id = id;
        }
    }
}

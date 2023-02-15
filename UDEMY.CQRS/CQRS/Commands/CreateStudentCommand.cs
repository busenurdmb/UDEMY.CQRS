using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDEMY.CQRS.CQRS.Commands
{
    public class CreateStudentCommand:IRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}

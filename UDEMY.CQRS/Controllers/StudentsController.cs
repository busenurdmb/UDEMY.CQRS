using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UDEMY.CQRS.CQRS.Commands;
using UDEMY.CQRS.CQRS.Handlers;
using UDEMY.CQRS.CQRS.Queries;

namespace UDEMY.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;





        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var result =await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result =await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
           await _mediator.Send(command);
            return Created("", command.Name);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
           await _mediator.Send(command);
            return NoContent();
        }


    }
}

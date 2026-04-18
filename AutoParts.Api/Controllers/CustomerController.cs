using AutoParts.Application.Customers.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra um novo cliente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/customers
        ///     {
        ///        "fullName": "João da Silva",
        ///        "email": "joao@email.com",
        ///        "phone": "11987654321",
        ///        "cpf": "12345678901",
        ///        "birthDate": "1995-05-15"
        ///     }
        /// </remarks>
        /// <param name="command">Dados do cliente para cadastro.</param>
        /// <returns>Retorna o ID do cliente recém-criado.</returns>
        /// <response code="201">Cliente criado com sucesso.</response>
        /// <response code="400">Se os dados enviados forem inválidos (Validação falhou).</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}

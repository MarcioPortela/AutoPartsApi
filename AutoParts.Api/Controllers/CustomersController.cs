using AutoParts.Application.Customers.Commands.CreateCustomer;
using AutoParts.Application.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
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

        /// <summary>
        /// Busca os detalhes de um cliente pelo ID.
        /// </summary>
        /// <param name="id">Identificador único do cliente.</param>
        /// <returns>Os dados do cliente solicitado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}

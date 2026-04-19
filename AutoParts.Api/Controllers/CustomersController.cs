using AutoParts.Application.Customers.Commands.CreateAddress;
using AutoParts.Application.Customers.Commands.CreateCustomer;
using AutoParts.Application.Customers.Commands.UpdateCustomer;
using AutoParts.Application.Customers.Queries.GetAddressesByCustomerId;
using AutoParts.Application.Customers.Queries.GetCustomerById;
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
        /// <param name="customerId">Identificador único do cliente.</param>
        /// <returns>Os dados do cliente solicitado.</returns>
        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Atualiza os dados de um cliente pelo ID.
        /// </summary>
        /// /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/customers
        ///     {
        ///        "email": "joao@email.com",
        ///        "phone": "11987654321"
        ///     }
        /// </remarks>
        /// <param name="customerId">Identificador único do cliente.</param>
        /// <param name="command">Campos a serem atualizados do cliente.</param>
        /// <response code="204">Os dados do cliente foram atualizados.</response>
        /// <response code="404">Se o cliente com o ID fornecido não for encontrado.</response>
        /// <response code="400">Se os dados enviados forem inválidos (Validação falhou).</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid customerId, [FromBody] UpdateCustomerCommand command)
        {
            command.SetId(customerId);
            var result = await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Cadastra um novo endereço do cliente no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/customers
        ///     {
        ///        "addressName": "Casa",
        ///        "street": "Rua da Consolação",
        ///        "number": "999",
        ///        "complement": "Casa 2",
        ///        "neighborhood": "Consolação",
        ///        "city": "São Paulo",
        ///        "state": "SP",
        ///        "zipCode": "01301-100"
        ///     }
        /// </remarks>
        /// <param name="customerId">Identificador único do cliente ao qual o endereço será associado.</param>
        /// <param name="command">Dados do endereço do cliente para cadastro.</param>
        /// <returns>Retorna o ID do endereço recém-criado.</returns>
        /// <response code="201">Endereço criado com sucesso.</response>
        /// <response code="404">Cliente não foi encontrado</response>
        /// <response code="400">Se os dados enviados forem inválidos (Validação falhou).</response>
        [HttpPost("{customerId}/addresses")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAddress(Guid customerId, [FromBody] CreateAddressCommand command)
        {
            command.SetCustomerId(customerId);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        /// <summary>
        /// Busca os endereços de um cliente pelo ID.
        /// </summary>
        /// <param name="customerId">Identificador único do cliente.</param>
        /// <returns>Os dados dos endereços do cliente solicitado.</returns>
        /// <response code="200">Retorna os dados dos endereços do cliente.</response>
        /// <response code="404">Cliente não foi encontrado</response>
        [HttpGet("{customerId}/addresses")]
        [ProducesResponseType(typeof(IEnumerable<AddressResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddressesByCustomerId(Guid customerId)
        {
            var query = new GetAddressesByCustomerIdQuery(customerId);
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}

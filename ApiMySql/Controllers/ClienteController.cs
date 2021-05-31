using ApiMySql.Data;
using ApiMySql.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ApiMySql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository = null;
        public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        [HttpGet("data")]
        public IActionResult ObterData()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);

            return Ok("Adicioando");
        }

        [HttpPut("id")]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            var cli = await _clienteRepository.Obter(id);

            if (cli == null)
                return NotFound();

            cli.Nome = cliente.Nome;
            await _clienteRepository.Editar(cli);

            return Ok("Editado");
        }

        [HttpGet("id")]
        public async Task<IActionResult> Obter(int id)
        {
            var cli = await _clienteRepository.Obter(id);

            return Ok(cli);
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var cli = await _clienteRepository.Obter();

            return Ok(cli);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Remover(int id)
        {
            var cli = await _clienteRepository.Obter(id);

            if (cli == null)
                return NotFound();

            await _clienteRepository.Remover(cli);

            return Ok("Removido");
        }
    }
}

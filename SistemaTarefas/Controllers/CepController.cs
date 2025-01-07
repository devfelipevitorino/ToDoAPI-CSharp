using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Integração;
using SistemaTarefas.Integração.Interfaces;
using SistemaTarefas.Integração.Response;

namespace SistemaTarefas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase 
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosDoEndereco(string cep) 
        {
            var ResponseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if (ResponseData == null) { return BadRequest("CEP não encontrado"); }

            return Ok(ResponseData);
        }
    }
}

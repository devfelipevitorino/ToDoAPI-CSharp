using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> buscarUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> buscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CadastrarUsuario([FromBody] UsuarioModel usuarioModel) 
        {
            UsuarioModel usuario = await _usuarioRepositorio.AdicionarUsuario(usuarioModel);
            return Ok(usuario);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> EditarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.AtualizarUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> ApagarUsuario(int id)
        {
            bool apagado = await _usuarioRepositorio.ApagarUsuario(id);
            return Ok(apagado);
        }
    }
}

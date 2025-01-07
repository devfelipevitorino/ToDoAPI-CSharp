using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaTarefas.Data;
using SistemaTarefas.Models;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {

        private readonly SistemaTarefasDBContext _context;

        public ContaController(SistemaTarefasDBContext context)
        {
            _context = context;
        }

        [HttpPost("/login")]
        public IActionResult login([FromBody] LoginModel login)
        {
            var usuario = _context.usuarios.FirstOrDefault(u => u.Email == login.Email);

            if (usuario == null || usuario.Senha != login.Senha)
            {
                return BadRequest(new { mensagem = "E-mail ou senha incorretos" });
            }
            var token = gerarTokenJwt(usuario);
            return Ok(new { token });
        }

        private string gerarTokenJwt(UsuarioModel usuario)
        {
            string chaveSecreta = "077be8e3-bca9-4a9b-9e7c-11547bb2e3d2";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim("email", usuario.Email),
                new Claim("nome", usuario.Nome),

            };

            var token = new JwtSecurityToken(
                issuer: "sua_empresa",
                audience: "sua_aplicação",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

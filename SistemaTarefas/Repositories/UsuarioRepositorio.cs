using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaTarefasDBContext dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int Id)
        {
            return await dbContext.usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await dbContext.usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await dbContext.usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int Id)
        {
            UsuarioModel buscaUsuarioPorId = await BuscarUsuarioPorId(Id);
            if (buscaUsuarioPorId == null) { throw new Exception("Usuario não encontrado!");}

            buscaUsuarioPorId.Nome = usuario.Nome;
            buscaUsuarioPorId.Email = usuario.Email;

            dbContext.usuarios.Update(buscaUsuarioPorId);
            await dbContext.SaveChangesAsync();

            return buscaUsuarioPorId;
        }

        public async Task<bool> ApagarUsuario(int Id)
        {
            UsuarioModel buscaUsuarioPorId = await BuscarUsuarioPorId(Id);
            if (buscaUsuarioPorId == null) { throw new Exception("Usuario não encontrado!"); }

            dbContext.usuarios.Remove(buscaUsuarioPorId);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}

using SistemaTarefas.Models;

namespace SistemaTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        Task<UsuarioModel> BuscarUsuarioPorId(int Id);

        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);

        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int Id);

        Task<bool> ApagarUsuario(int Id);

    }
}

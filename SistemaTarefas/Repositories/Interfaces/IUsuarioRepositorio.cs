using SistemaTarefas.Models;

namespace SistemaTarefas.Repositories.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();

        Task<TarefaModel> BuscarTarefaPorId(int Id);

        Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa);

        Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int Id);

        Task<bool> ApagarTarefa(int Id);

    }
}

using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas.Repositories
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        private readonly SistemaTarefasDBContext dbContext;
        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            dbContext = sistemaTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarTarefaPorId(int Id)
        {
            return await dbContext.tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await dbContext.tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
        {
            await dbContext.tarefas.AddAsync(tarefa);
            await dbContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int Id)
        {
            TarefaModel buscarTarefaPorId = await BuscarTarefaPorId(Id);
            if (buscarTarefaPorId == null) { throw new Exception("Tarefa não encontrada!");}

            buscarTarefaPorId.Nome = tarefa.Nome;
            buscarTarefaPorId.Descricao = tarefa.Descricao;
            buscarTarefaPorId.Status = tarefa.Status;
            buscarTarefaPorId.UsuarioId = tarefa.UsuarioId;

            dbContext.tarefas.Update(buscarTarefaPorId);
            await dbContext.SaveChangesAsync();

            return buscarTarefaPorId;
        }

        public async Task<bool> ApagarTarefa(int Id)
        {
            TarefaModel buscatarefaPorId = await BuscarTarefaPorId(Id);
            if (buscatarefaPorId == null) { throw new Exception("Tarefa não encontrada!"); }

            dbContext.tarefas.Remove(buscatarefaPorId);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}

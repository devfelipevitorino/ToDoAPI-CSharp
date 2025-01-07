using System.ComponentModel;

namespace SistemaTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("Em espera")]
        Espera = 1,
        [Description("Em andamento")]
        Andamento = 2,
        [Description("Tarefa concluida")]
        Concluido = 3
    }
}

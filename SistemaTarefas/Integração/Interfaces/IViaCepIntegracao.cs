using SistemaTarefas.Integração.Response;

namespace SistemaTarefas.Integração.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}

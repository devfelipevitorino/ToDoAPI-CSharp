using Refit;
using SistemaTarefas.Integração.Response;

namespace SistemaTarefas.Integração.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}

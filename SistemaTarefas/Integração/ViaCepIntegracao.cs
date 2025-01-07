using SistemaTarefas.Integração.Interfaces;
using SistemaTarefas.Integração.Refit;
using SistemaTarefas.Integração.Response;

namespace SistemaTarefas.Integração
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {

        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var ResponseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            if (ResponseData != null && ResponseData.IsSuccessStatusCode) 
            {
                return ResponseData.Content;
            }

            return null;
        }
    }
}

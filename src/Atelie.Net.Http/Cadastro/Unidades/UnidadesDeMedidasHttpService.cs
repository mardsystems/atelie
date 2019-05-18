using Atelie.Comum;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Unidades
{
    public class UnidadesDeMedidasHttpService : IConsultaDeUnidadesDeMedidas, ICadastroDeUnidadesDeMedidas
    {
        private readonly HttpClient client;

        public UnidadesDeMedidasHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCadastroDeUnidade> CadastraUnidade(ISolicitacaoDeCadastroDeUnidade solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("cadastro/medidas/unidadesDeMedidas/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeUnidade resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeUnidade>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCadastroDeUnidade> AtualizaUnidade(string sigla, ISolicitacaoDeCadastroDeUnidade solicitacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"cadastro/medidas/unidadesDeMedidas/{sigla}", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeUnidade resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeUnidade>();
            }

            return resposta;
        }

        public async Task ExcluiUnidade(string sigla)
        {
            HttpResponseMessage response = await client.DeleteAsync($"cadastro/medidas/unidadesDeMedidas/{sigla}");

            IRespostaDeCadastroDeUnidade resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeUnidade>();
            }
        }

        public IObservable<IUnidadeDeMedida[]> ObtemObservavelDeUnidades()
        {
            IObservable<IUnidadeDeMedida[]> observable;

            var path = "cadastro/medidas/unidadesDeMedidas/";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var materiais = response.Content.ReadAsAsync<UnidadeDeMedidaDTO[]>();

                observable = materiais.ToObservable();
            }
            else
            {
                observable = Observable.Empty<IUnidadeDeMedida[]>();
            }

            return observable;
        }
    }
}

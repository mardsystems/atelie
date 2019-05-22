using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisHttpService : IPlanejamentoComercial, IConsultaDePlanosComerciais
    {
        private readonly HttpClient client;

        public PlanosComerciaisHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCriacaoDePlanoComercial> CriaPlanoComercial(ISolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("decisoes/comerciais/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCriacaoDePlanoComercial resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCriacaoDePlanoComercial>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCriacaoDePlanoComercial> AtualizaPlanoComercial(string planoComercialId, ISolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("decisoes/comerciais/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCriacaoDePlanoComercial resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCriacaoDePlanoComercial>();
            }

            return resposta;
        }

        public async Task ExcluiPlanoComercial(string planoComercialId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"decisoes/comerciais/{planoComercialId}");

            if (response.IsSuccessStatusCode)
            {

            }
        }

        public IObservable<IPlanoComercial[]> ObtemObservavelDePlanosComerciais()
        {
            IObservable<IPlanoComercial[]> observable;

            var path = "decisoes/comerciais/";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var planosComerciais = response.Content.ReadAsAsync<PlanoComercial[]>();

                observable = planosComerciais.ToObservable();
            }
            else
            {
                var empty = new IPlanoComercial[] { };

                observable = Observable.Return(empty);
            }

            return observable;
        }
    }
}

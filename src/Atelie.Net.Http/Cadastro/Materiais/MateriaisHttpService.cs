using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public class MateriaisHttpService : IConsultaDeMateriais, ICadastroDeMateriais
    {
        private readonly HttpClient client;

        public MateriaisHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCadastroDeMaterial> CadastraMaterial(ISolicitacaoDeCadastroDeMaterial solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("cadastro/materiais/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeMaterial resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeMaterial>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCadastroDeMaterial> AtualizaMaterial(int materialId, ISolicitacaoDeCadastroDeMaterial solicitacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"cadastro/materiais/{materialId}", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeMaterial resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeMaterial>();
            }

            return resposta;
        }

        public async Task ExcluiMaterial(int materialId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"cadastro/materiais/{materialId}");

            IRespostaDeCadastroDeMaterial resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeMaterial>();
            }
        }

        public IObservable<IMaterial[]> ObtemObservavelDeMateriais()
        {
            IObservable<IMaterial[]> observable;

            var path = "cadastro/materiais/";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var materiais = response.Content.ReadAsAsync<MaterialDTO[]>();

                observable = materiais.ToObservable();
            }
            else
            {
                observable = Observable.Empty<IMaterial[]>();
            }

            return observable;
        }
    }
}

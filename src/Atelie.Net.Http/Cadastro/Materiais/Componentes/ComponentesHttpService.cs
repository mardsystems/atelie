using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponentesHttpService : IConsultaDeComponentes, ICadastroDeComponentes
    {
        private readonly HttpClient client;

        public ComponentesHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCadastroDeComponente> CadastraComponente(ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("cadastro/materiais/componentes/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeComponente>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCadastroDeComponente> AtualizaComponente(int materialId, ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"cadastro/materiais/componentes/{materialId}", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeComponente>();
            }

            return resposta;
        }

        public async Task ExcluiComponente(int materialId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"cadastro/materiais/componentes/{materialId}");

            IRespostaDeCadastroDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeComponente>();
            }
        }

        public IObservable<IComponente[]> ObtemObservavelDeComponentes()
        {
            IObservable<IComponente[]> observable;

            var path = "cadastro/materiais/componentes";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var componentes = response.Content.ReadAsAsync<ComponenteDTO[]>();

                observable = componentes.ToObservable();
            }
            else
            {
                var empty = new IComponente[] { };

                observable = Observable.Return(empty);
            }

            return observable;
        }
    }
}

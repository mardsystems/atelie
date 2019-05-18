using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricacoesDeComponentesHttpService : IConsultaDeFabricacoesDeComponentes, ICadastroDeFabricacoesDeComponentes
    {
        private readonly HttpClient client;

        public FabricacoesDeComponentesHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> CadastraFabricacaoDeComponente(ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("cadastro/materiais/fabricacoesDeComponentes/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeFabricacaoDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricacaoDeComponente>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> AtualizaFabricacaoDeComponente(int fabricacaoDeComponenteId, ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"cadastro/materiais/fabricacoesDeComponentes/{fabricacaoDeComponenteId}", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeFabricacaoDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricacaoDeComponente>();
            }

            return resposta;
        }

        public async Task ExcluiFabricacaoDeComponente(int fabricanteId, int componenteId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"cadastro/materiais/fabricacoesDeComponentes/{fabricanteId}");

            IRespostaDeCadastroDeFabricacaoDeComponente resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricacaoDeComponente>();
            }
        }

        public Task<IRespostaDeCadastroDeFabricacaoDeComponente> AtualizaFabricacaoDeComponente(int fabricanteId, int componenteId, ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiFabricacaoDeComponentePorFabricante(int fabricanteId)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeCadastroDeCatalogo> CadastraCatalogo(ISolicitacaoDeCadastroDeCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeCadastroDeCatalogo> AtualizaCatalogo(int fabricanteId, int componenteId, string nome, ISolicitacaoDeCadastroDeCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiCatalogo(int fabricanteId, int componenteId, string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeDefinicaoDeCorNoCatalogo> DefineCorNoCatalogo(ISolicitacaoDeDefinicaoDeCorNoCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDefinicaoDeCorDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeDisponibilizacaoDeEmbalagemNoCatalogo> DisponibilizaEmbalagemNoCatalogo(ISolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiDisponibilidadeDeEmbalagemDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome)
        {
            throw new NotImplementedException();
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentes()
        {
            IObservable<IFabricacaoDeComponente[]> observable;

            var path = "cadastro/materiais/fabricacoesDeComponentes";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var fabricacoesDeComponentes = response.Content.ReadAsAsync<FabricacaoDeComponenteDTO[]>();

                observable = fabricacoesDeComponentes.ToObservable();
            }
            else
            {
                observable = Observable.Empty<IFabricacaoDeComponente[]>();
            }

            return observable;
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorFabricante(int fabricanteId)
        {
            throw new NotImplementedException();
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorComponente(int componenteId)
        {
            throw new NotImplementedException();
        }
    }
}

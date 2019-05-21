using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricantesHttpService : IConsultaDeFabricantes, ICadastroDeFabricantes
    {
        private readonly HttpClient client;

        public FabricantesHttpService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IRespostaDeCadastroDeFabricante> CadastraFabricante(ISolicitacaoDeCadastroDeFabricante solicitacao)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("cadastro/materiais/fabricantes/", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeFabricante resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricante>();
            }

            return resposta;
        }

        public async Task<IRespostaDeCadastroDeFabricante> AtualizaFabricante(int fabricanteId, ISolicitacaoDeCadastroDeFabricante solicitacao)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"cadastro/materiais/fabricantes/{fabricanteId}", solicitacao);

            //response.EnsureSuccessStatusCode();

            //return response.Headers.Location;

            IRespostaDeCadastroDeFabricante resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricante>();
            }

            return resposta;
        }

        public async Task ExcluiFabricante(int fabricanteId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"cadastro/materiais/fabricantes/{fabricanteId}");

            IRespostaDeCadastroDeFabricante resposta = null;

            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsAsync<IRespostaDeCadastroDeFabricante>();
            }
        }

        public IObservable<IFabricante[]> ObtemObservavelDeFabricantes()
        {
            IObservable<IFabricante[]> observable;

            var path = "cadastro/materiais/fabricantes";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var fabricantes = response.Content.ReadAsAsync<FabricanteDTO[]>();

                var observable2 = fabricantes.ToObservable().Select(fs =>
                {
                    foreach (var f in fs)
                    {
                        foreach (var cf in f.ComponentesFabricados)
                        {
                            cf.Fabricante = f;

                            //foreach (var ct in cf.Catalogos)
                            //{
                            //    ct.FabricacaoDeComponente = cf;

                            //    foreach (var corf in ct.Cores)
                            //    {
                            //        corf.Catalogo = ct;
                            //        //corf.Categoria = cf.Componente;
                            //    }
                            //}
                        }
                    }

                    return fs;
                });

                observable = observable2;

                //observable = fabricantes.ToObservable();
            }
            else
            {
                observable = Observable.Empty<IFabricante[]>();
            }

            return observable;
        }
    }
}

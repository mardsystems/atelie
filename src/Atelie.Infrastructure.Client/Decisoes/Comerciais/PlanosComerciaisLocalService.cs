using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisLocalService : IRepositorioDePlanosComerciais, IConsultaDePlanosComerciais
    {
        private readonly PlanosComerciaisDbService db;

        private readonly PlanosComerciaisHttpService http;

        public PlanosComerciaisLocalService(PlanosComerciaisDbService db, PlanosComerciaisHttpService http)
        {
            this.db = db;

            this.http = http;
        }

        public async Task SaveChanges()
        {
            await db.SaveChanges();
        }

        public async Task Add(PlanoComercial planoComercial)
        {
            await db.Add(planoComercial);

            //

            var solicitacaoDeCadastroDePlanoComercial = new SolicitacaoDeCriacaoDePlanoComercial
            {
                Id = planoComercial.Id,
                Nome = planoComercial.Nome,
                //ComponenteId = newItem.ComponenteId,
                //FabricanteId = newItem.FabricanteId,
            };

            var resposta = await http.CriaPlanoComercial(solicitacaoDeCadastroDePlanoComercial);
        }

        public async Task Update(PlanoComercial planoComercial)
        {
            await db.Update(planoComercial);

            //

            var solicitacaoDeCadastroDePlanoComercial = new SolicitacaoDeCriacaoDePlanoComercial
            {
                Id = planoComercial.Id,
                Nome = planoComercial.Nome,
                //ComponenteId = modifiedItem.ComponenteId,
                //FabricanteId = modifiedItem.FabricanteId,
            };

            var resposta = await http.AtualizaPlanoComercial(planoComercial.Id, solicitacaoDeCadastroDePlanoComercial);
        }

        public async Task Remove(PlanoComercial planoComercial)
        {
            await db.Remove(planoComercial);

            //

            await http.ExcluiPlanoComercial(planoComercial.Id);
        }

        public async Task<PlanoComercial> ObtemPlanoComercial(string id)
        {
            var result = await db.ObtemPlanoComercial(id);

            return result;
        }

        public IObservable<PlanoComercial[]> ObtemObservavelDePlanosComerciais()
        {
            var result = db.ObtemObservavelDePlanosComerciais();

            return result.Cast<PlanoComercial[]>();
        }

        IObservable<IPlanoComercial[]> IConsultaDePlanosComerciais.ObtemObservavelDePlanosComerciais()
        {
            var result = db.ObtemObservavelDePlanosComerciais();

            return result;
        }
    }
}

using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisLocalService : IRepositorioDePlanosComerciais
    {
        private readonly PlanosComerciaisDbService db;

        public PlanosComerciaisLocalService(PlanosComerciaisDbService db)
        {
            this.db = db;
        }

        public async Task SaveChanges()
        {
            await db.SaveChanges();
        }

        public async Task Add(PlanoComercial planoComercial)
        {
            await db.Add(planoComercial);
        }

        public async Task Update(PlanoComercial planoComercial)
        {
            await db.Update(planoComercial);
        }

        public async Task Remove(PlanoComercial planoComercial)
        {
            await db.Remove(planoComercial);
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
    }
}

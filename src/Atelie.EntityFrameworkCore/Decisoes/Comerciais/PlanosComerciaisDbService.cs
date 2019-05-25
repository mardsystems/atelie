using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisDbService : IRepositorioDePlanosComerciais
    {
        private readonly AtelieDbContext db;

        public PlanosComerciaisDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }

        public async Task Add(PlanoComercial planoComercial)
        {
            try
            {
                await db.PlanosComerciais.AddAsync(planoComercial);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar planoComercial '{planoComercial.Id}'.", ex);
            }
        }

        public async Task Update(PlanoComercial planoComercial)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Remove(PlanoComercial planoComercial)
        {
            try
            {
                db.PlanosComerciais.Remove(planoComercial);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir planoComercial '{planoComercial.Id}'.", ex);
            }
        }

        public async Task<PlanoComercial> ObtemPlanoComercial(string id)
        {
            try
            {
                var planoComercial = await db.PlanosComerciais.FindAsync(id);

                return planoComercial;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter planoComercial '{id}'.", ex);
            }
        }

        public IObservable<PlanoComercial[]> ObtemObservavelDePlanosComerciais()
        {
            try
            {
                var planosComerciais = db.PlanosComerciais
                    .Include(p => p.CustosFixos)
                    .Include(p => p.CustosVariaveis)
                    .Include(p => p.Itens)
                    .ToArrayAsync();

                var observable = planosComerciais.ToObservable();

                return observable;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricantesDbService : IRepositorioDeFabricantes, IConsultaDeFabricantes
    {
        private readonly AtelieDbContext db;

        public FabricantesDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Fabricante fabricante)
        {
            try
            {
                await db.Fabricantes.AddAsync(fabricante);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Update(Fabricante fabricante)
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

        public async Task Remove(Fabricante fabricante)
        {
            try
            {
                db.Fabricantes.Remove(fabricante);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task<Fabricante> ObtemFabricante(int id)
        {
            try
            {
                var fabricante = await db.Fabricantes.FindAsync(id);

                return fabricante;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public IObservable<IFabricante[]> ObtemObservavelDeFabricantes()
        {
            try
            {
                var fabricantes = db.Fabricantes
                    .Include(p => p.ComponentesFabricados)
                        .ThenInclude(p => p.Catalogos)
                            .ThenInclude(p => p.Cores)
                    .Include(p => p.ComponentesFabricados)
                        .ThenInclude(p => p.Catalogos)
                            .ThenInclude(p => p.Embalagens)
                    .Include(p => p.ComponentesFabricados)
                        .ThenInclude(p => p.Componente)
                            .ThenInclude(p => p.UnidadePadrao)
                    .ToArrayAsync();

                var observable = fabricantes.ToObservable();

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

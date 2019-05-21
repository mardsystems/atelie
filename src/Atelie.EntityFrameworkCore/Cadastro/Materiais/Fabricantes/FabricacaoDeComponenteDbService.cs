using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricacoesDeComponentesDbService : IRepositorioDeFabricacoesDeComponentes, IConsultaDeFabricacoesDeComponentes
    {
        private readonly AtelieDbContext db;

        public FabricacoesDeComponentesDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task Add(FabricacaoDeComponente fabricacaoDeComponente)
        {
            try
            {
                await db.FabricacoesDeComponentes.AddAsync(fabricacaoDeComponente);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Update(FabricacaoDeComponente fabricacaoDeComponente)
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

        public async Task Remove(FabricacaoDeComponente fabricacaoDeComponente)
        {
            try
            {
                db.FabricacoesDeComponentes.Remove(fabricacaoDeComponente);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task<FabricacaoDeComponente> ObtemFabricacaoDeComponente(int fabricanteId, int componenteId)
        {
            try
            {
                var fabricacaoDeComponente = await db.FabricacoesDeComponentes
                    .Where(p => p.FabricanteId == fabricanteId && p.ComponenteId == componenteId)
                    .FirstOrDefaultAsync();

                return fabricacaoDeComponente;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentes()
        {
            try
            {
                var fabricacoesDeComponentes = db.FabricacoesDeComponentes
                    //.Include(p => p.Catalogos)
                    //    .ThenInclude(p => p.Cores)
                    .ToArrayAsync();

                var observable = fabricacoesDeComponentes.ToObservable();

                return observable;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorFabricante(int fabricanteId)
        {
            try
            {
                var fabricacoesDeComponentes = db.FabricacoesDeComponentes
                    .Where(p => p.FabricanteId == fabricanteId)
                    //.Include(p => p.Catalogos)
                    //    .ThenInclude(p => p.Cores)
                    .ToArrayAsync();

                var observable = fabricacoesDeComponentes.ToObservable();

                return observable;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorComponente(int componenteId)
        {
            try
            {
                var fabricacoesDeComponentes = db.FabricacoesDeComponentes
                    .Where(p => p.ComponenteId == componenteId)
                    //.Include(p => p.Catalogos)
                    //    .ThenInclude(p => p.Cores)
                    .ToArrayAsync();

                var observable = fabricacoesDeComponentes.ToObservable();

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

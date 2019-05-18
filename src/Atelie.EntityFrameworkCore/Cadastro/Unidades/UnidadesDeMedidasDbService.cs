using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Unidades
{
    public class UnidadesDeMedidasDbService : RepositorioDeUnidadesDeMedidas, IConsultaDeUnidadesDeMedidas
    {
        private readonly AtelieDbContext db;

        public UnidadesDeMedidasDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task Add(UnidadeDeMedida unidadeDeMedida)
        {
            try
            {
                await db.Unidades.AddAsync(unidadeDeMedida);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Update(UnidadeDeMedida unidadeDeMedida)
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

        public async Task Remove(UnidadeDeMedida unidadeDeMedida)
        {
            try
            {
                db.Unidades.Remove(unidadeDeMedida);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir unidade de medida '{unidadeDeMedida.Sigla}'.", ex);
            }
        }

        public async Task<UnidadeDeMedida> ObtemUnidadeDeMedida(string sigla)
        {
            try
            {
                var unidadeDeMedida = await db.Unidades.FindAsync(sigla);

                return (UnidadeDeMedida)unidadeDeMedida;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter unidade de medida '{sigla}'.", ex);
            }
        }

        public IObservable<IUnidadeDeMedida[]> ObtemObservavelDeUnidades()
        {
            try
            {
                var unidadeDeMedidas = db.Set<UnidadeDeMedida>()
                    .ToArrayAsync();

                var observable = unidadeDeMedidas.ToObservable();

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

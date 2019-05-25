using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponentesDbService : IRepositorioDeComponentes
    {
        private readonly AtelieDbContext db;

        public ComponentesDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Componente componente)
        {
            try
            {
                await db.Componentes.AddAsync(componente);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Update(Componente componente)
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

        public async Task Remove(Componente componente)
        {
            try
            {
                db.Componentes.Remove(componente);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task<Componente> ObtemComponente(int id)
        {
            try
            {
                var componente = await db.Componentes.FindAsync(id);

                return componente;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public IObservable<Componente[]> ObtemObservavelDeComponentes()
        {
            try
            {
                var componentes = db.Componentes
                    .Include(p => p.ComponentePai)
                    .Include(p => p.UnidadePadrao)
                    .ToArrayAsync();

                var observable = componentes.ToObservable();

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

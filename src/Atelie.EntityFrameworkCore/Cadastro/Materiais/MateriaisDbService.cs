using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public class MateriaisDbService : IRepositorioDeMateriais
    {
        private readonly AtelieDbContext db;

        public MateriaisDbService(AtelieDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Material material)
        {
            try
            {
                await db.Materiais.AddAsync(material);

                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task Update(Material material)
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

        public async Task Remove(Material material)
        {
            try
            {
                db.Materiais.Remove(material);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir material '{material.Id}'.", ex);
            }
        }

        public async Task<Material> ObtemMaterial(int id)
        {
            try
            {
                var material = await db.Materiais.FindAsync(id);

                return material;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter material '{id}'.", ex);
            }
        }

        public IObservable<Material[]> ObtemObservavelDeMateriais()
        {
            try
            {
                var materiais = db.Materiais
                    .Include(p => p.Componente)
                    .Include(p => p.Componente.ComponentePai)
                    .Include(p => p.Componente.UnidadePadrao)
                    .Include(p => p.Fabricante)
                    .Include(p => p.Unidade)
                    .ToArrayAsync();

                var observable = materiais.ToObservable();

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

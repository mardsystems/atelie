﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var items = db.ChangeTracker.Entries<ItemDePlanoComercial>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

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

                throw new ApplicationException($"Erro ao adicionar planoComercial '{planoComercial.Codigo}'.", ex);
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

                throw new ApplicationException($"Erro ao excluir planoComercial '{planoComercial.Codigo}'.", ex);
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

        public async Task<IEnumerable<PlanoComercial>> ObtemObservavelDePlanosComerciais()
        {
            try
            {
                var planosComerciais = await db.PlanosComerciais
                    .Include(p => p.Custos)
                    .Include(p => p.Itens)
                        .ThenInclude(p => p.Modelo)
                            .ThenInclude(p => p.Recursos)
                    .ToListAsync();

                //var observable = planosComerciais.ToObservable();

                return planosComerciais;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro em Planos Comerciais.", ex);
            }
        }
    }
}

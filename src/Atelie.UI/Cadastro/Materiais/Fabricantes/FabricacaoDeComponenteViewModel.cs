using Atelie.Cadastro.Materiais.Componentes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricacaoDeComponenteViewModel : ObservableObject, INotifyPropertyChanged //, IEditableObject
    {
        public int ComponenteId { get; set; }

        public string ComponenteNome { get; set; }

        public string ComponenteUnidadePadraoSigla { get; set; }

        public int FabricanteId { get; set; }

        public string FabricanteNome { get; set; }

        public string FabricanteMarca { get; set; }

        public string FabricanteSite { get; set; }

        //public CatalogosBindingList Catalogos { get; set; }

        public static FabricacaoDeComponenteViewModel From(IFabricacaoDeComponente fabricacaoDeComponente)
        {
            //var catalogos = fabricacaoDeComponente.Catalogos.Select(p => CatalogoViewModel.From(p)).ToList();

            //var catalogosBindingList = new CatalogosBindingList(catalogos);

            var viewModel = new FabricacaoDeComponenteViewModel
            {
                ComponenteId = fabricacaoDeComponente.Componente.Id,
                ComponenteNome = fabricacaoDeComponente.Componente.Nome,
                //ComponenteUnidadePadraoSigla = componente.UnidadePadrao.Sigla,
                FabricanteId = fabricacaoDeComponente.Fabricante.Id,
                FabricanteNome = fabricacaoDeComponente.Fabricante.Nome,
                FabricanteMarca = fabricacaoDeComponente.Fabricante.Marca,
                FabricanteSite = fabricacaoDeComponente.Fabricante.Site,
                //Catalogos = catalogosBindingList
                //Periodo = fabricacaoDeComponente.Periodo,
            };

            return viewModel;
        }

        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {

        }

        public void EndEdit()
        {

        }
    }

    public class FabricacoesDeComponentesBindingList : ExtendedBindingList<FabricacaoDeComponenteViewModel>
    {
        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public FabricacoesDeComponentesBindingList(
            ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes,
            IList<FabricacaoDeComponenteViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricacoesDeComponentes = cadastroDeFabricacoesDeComponentes;
        }

        public FabricacoesDeComponentesBindingList(IList<FabricacaoDeComponenteViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(FabricacaoDeComponenteViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDeFabricacaoDeComponente = new SolicitacaoDeCadastroDeFabricacaoDeComponente
                {
                    FabricanteId = newItem.FabricanteId,
                    ComponenteId = newItem.ComponenteId,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.CadastraFabricacaoDeComponente(solicitacaoDeCadastroDeFabricacaoDeComponente);

                    SetStatus($"Nova fabricação do fabricante '{newItem.FabricanteId}' e componente '{newItem.ComponenteId}' cadastrado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var modifiedItems = GetItemsBy(ObjectState.Modified);

            foreach (var modifiedItem in modifiedItems)
            {
                var solicitacaoDeCadastroDeFabricacaoDeComponente = new SolicitacaoDeCadastroDeFabricacaoDeComponente
                {
                    FabricanteId = modifiedItem.FabricanteId,
                    ComponenteId = modifiedItem.ComponenteId,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.AtualizaFabricacaoDeComponente(modifiedItem.FabricanteId, modifiedItem.ComponenteId, solicitacaoDeCadastroDeFabricacaoDeComponente);

                    SetStatus($"Fabricação do fabricante '{modifiedItem.FabricanteId}' e componente '{modifiedItem.ComponenteId}' atualizado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var deletedItems = GetItemsBy(ObjectState.Deleted);

            foreach (var deletedItem in deletedItems)
            {
                try
                {
                    await cadastroDeFabricacoesDeComponentes.ExcluiFabricacaoDeComponente(deletedItem.FabricanteId, deletedItem.ComponenteId);

                    SetStatus($"Fabricação do fabricante '{deletedItem.FabricanteId}' e componente '{deletedItem.ComponenteId}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class FabricacoesDeComponentesObservableCollection : ExtendedObservableCollection<FabricacaoDeComponenteViewModel>
    {
        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public FabricacoesDeComponentesObservableCollection(
            ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes,
            IList<FabricacaoDeComponenteViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricacoesDeComponentes = cadastroDeFabricacoesDeComponentes;
        }

        public FabricacoesDeComponentesObservableCollection(IList<FabricacaoDeComponenteViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(FabricacaoDeComponenteViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDeFabricacaoDeComponente = new SolicitacaoDeCadastroDeFabricacaoDeComponente
                {
                    FabricanteId = newItem.FabricanteId,
                    ComponenteId = newItem.ComponenteId,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.CadastraFabricacaoDeComponente(solicitacaoDeCadastroDeFabricacaoDeComponente);

                    SetStatus($"Nova fabricação do fabricante '{newItem.FabricanteId}' e componente '{newItem.ComponenteId}' cadastrado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var modifiedItems = GetItemsBy(ObjectState.Modified);

            foreach (var modifiedItem in modifiedItems)
            {
                var solicitacaoDeCadastroDeFabricacaoDeComponente = new SolicitacaoDeCadastroDeFabricacaoDeComponente
                {
                    FabricanteId = modifiedItem.FabricanteId,
                    ComponenteId = modifiedItem.ComponenteId,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.AtualizaFabricacaoDeComponente(modifiedItem.FabricanteId, modifiedItem.ComponenteId, solicitacaoDeCadastroDeFabricacaoDeComponente);

                    SetStatus($"Fabricação do fabricante '{modifiedItem.FabricanteId}' e componente '{modifiedItem.ComponenteId}' atualizado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var deletedItems = GetItemsBy(ObjectState.Deleted);

            foreach (var deletedItem in deletedItems)
            {
                try
                {
                    await cadastroDeFabricacoesDeComponentes.ExcluiFabricacaoDeComponente(deletedItem.FabricanteId, deletedItem.ComponenteId);

                    SetStatus($"Fabricação do fabricante '{deletedItem.FabricanteId}' e componente '{deletedItem.ComponenteId}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }
}

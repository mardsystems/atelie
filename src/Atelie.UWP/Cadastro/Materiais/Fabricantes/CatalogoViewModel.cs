using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class CatalogoViewModel : ObservableObject, INotifyPropertyChanged
    {
        int fabricanteId = 0;
        public int FabricanteId
        {
            get { return fabricanteId; }
            set { SetProperty(ref fabricanteId, value); }
        }

        int componenteId = 0;
        public int ComponenteId
        {
            get { return componenteId; }
            set { SetProperty(ref componenteId, value); }
        }

        string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        public CorDeFabricantesBindingList Cores { get; set; }

        public DisponibilidadeDeEmbalagemsBindingList Embalagens { get; set; }

        public CatalogoViewModel(

        )
        {

        }

        public static CatalogoViewModel From(ICatalogo catalogo, IFabricacaoDeComponente fabricacaoDeComponente, IFabricante fabricante)
        {
            var cores = catalogo.Cores.Select(p => CorDeFabricanteViewModel.From(p)).ToList();

            var coresBindingList = new CorDeFabricantesBindingList(cores);

            var embalagens = catalogo.Embalagens.Select(p => DisponibilidadeDeEmbalagemViewModel.From(p)).ToList();

            var embalagensBindingList = new DisponibilidadeDeEmbalagemsBindingList(embalagens);

            var viewModel = new CatalogoViewModel
            {
                FabricanteId = fabricante.Id,
                ComponenteId = fabricacaoDeComponente.Componente.Id,
                Nome = catalogo.Nome,
                Cores = coresBindingList,
                Embalagens = embalagensBindingList
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

    public class CatalogosBindingList : ExtendedBindingList<CatalogoViewModel>
    {
        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public CatalogosBindingList(
            ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes,
            IList<CatalogoViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricacoesDeComponentes = cadastroDeFabricacoesDeComponentes;
        }

        public CatalogosBindingList(IList<CatalogoViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(CatalogoViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDeCatalogo = new SolicitacaoDeCadastroDeCatalogo
                {
                    FabricanteId = newItem.FabricanteId,
                    ComponenteId = newItem.ComponenteId,
                    Nome = newItem.Nome,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.CadastraCatalogo(solicitacaoDeCadastroDeCatalogo);

                    SetStatus($"Novo catalogo '{newItem.FabricanteId}' '{newItem.ComponenteId}' '{newItem.Nome}' cadastrado com sucesso.");
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
                var solicitacaoDeCadastroDeCatalogo = new SolicitacaoDeCadastroDeCatalogo
                {
                    FabricanteId = modifiedItem.FabricanteId,
                    ComponenteId = modifiedItem.ComponenteId,
                    Nome = modifiedItem.Nome,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.AtualizaCatalogo(modifiedItem.FabricanteId, modifiedItem.ComponenteId, modifiedItem.Nome, solicitacaoDeCadastroDeCatalogo);

                    SetStatus($"Catalogo '{modifiedItem.FabricanteId}' '{modifiedItem.ComponenteId}' '{modifiedItem.Nome}' atualizado com sucesso.");
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
                    await cadastroDeFabricacoesDeComponentes.ExcluiCatalogo(deletedItem.FabricanteId, deletedItem.ComponenteId, deletedItem.Nome);

                    SetStatus($"Catalogo '{deletedItem.FabricanteId}' '{deletedItem.ComponenteId}' '{deletedItem.Nome}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class CatalogosObservableCollection : ObservableCollection<CatalogoViewModel>
    {
        public CatalogosObservableCollection(IList<CatalogoViewModel> list)
            : base(list)
        {

        }
    }
}

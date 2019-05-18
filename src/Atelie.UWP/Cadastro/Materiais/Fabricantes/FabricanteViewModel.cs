using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricanteViewModel : ObservableObject, INotifyPropertyChanged
    {
        int id = 0;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        string marca = string.Empty;
        public string Marca
        {
            get { return marca; }
            set { SetProperty(ref marca, value); }
        }

        string site = string.Empty;
        public string Site
        {
            get { return site; }
            set { SetProperty(ref site, value); }
        }

        public FabricacoesDeComponentesBindingList ComponentesFabricados { get; set; }

        public static FabricanteViewModel From(IFabricante fabricante)
        {
            var componentesFabricados = fabricante.ComponentesFabricados.Select(p => FabricacaoDeComponenteViewModel.From(fabricante, p.Componente, p)).ToList();

            var componentesFabricadosBindingList = new FabricacoesDeComponentesBindingList(componentesFabricados);

            var viewModel = new FabricanteViewModel
            {
                Id = fabricante.Id,
                Nome = fabricante.Nome,
                Marca = fabricante.Marca,
                Site = fabricante.Site,
                ComponentesFabricados = componentesFabricadosBindingList,
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

    public class FabricantesBindingList : ExtendedBindingList<FabricanteViewModel>
    {
        private readonly ICadastroDeFabricantes cadastroDeFabricantes;

        public FabricantesBindingList(
            ICadastroDeFabricantes cadastroDeFabricantes,
            IList<FabricanteViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricantes = cadastroDeFabricantes;
        }

        public FabricantesBindingList(IList<FabricanteViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(FabricanteViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDeFabricante = new SolicitacaoDeCadastroDeFabricante
                {
                    Id = newItem.Id,
                    Nome = newItem.Nome,
                    Marca = newItem.Marca,
                    Site = newItem.Site,
                };

                try
                {
                    var resposta = await cadastroDeFabricantes.CadastraFabricante(solicitacaoDeCadastroDeFabricante);

                    SetStatus($"Novo fabricante '{resposta.Id}' cadastrado com sucesso.");
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
                var solicitacaoDeCadastroDeFabricante = new SolicitacaoDeCadastroDeFabricante
                {
                    Id = modifiedItem.Id,
                    Nome = modifiedItem.Nome,
                    Marca = modifiedItem.Marca,
                    Site = modifiedItem.Site,
                };

                try
                {
                    var resposta = await cadastroDeFabricantes.AtualizaFabricante(modifiedItem.Id, solicitacaoDeCadastroDeFabricante);

                    SetStatus($"Fabricante '{resposta.Id}' atualizado com sucesso.");
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
                    await cadastroDeFabricantes.ExcluiFabricante(deletedItem.Id);

                    SetStatus($"Fabricante '{deletedItem.Id}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class FabricantesObservableCollection : ObservableCollection<FabricanteViewModel>
    {
        private readonly ICadastroDeFabricantes cadastroDeFabricantes;

        public FabricantesObservableCollection(
            ICadastroDeFabricantes cadastroDeFabricantes,
            IList<FabricanteViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricantes = cadastroDeFabricantes;
        }

        public FabricantesObservableCollection(IList<FabricanteViewModel> list)
            : base(list)
        {

        }
    }
}

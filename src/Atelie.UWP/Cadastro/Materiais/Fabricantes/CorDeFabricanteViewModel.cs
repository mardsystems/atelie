using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class CorDeFabricanteViewModel : ObservableObject, INotifyPropertyChanged
    {
        int corDeFabricanteId = 0;
        public int FabricanteId
        {
            get { return corDeFabricanteId; }
            set { SetProperty(ref corDeFabricanteId, value); }
        }

        int componenteId = 0;
        public int ComponenteId
        {
            get { return componenteId; }
            set { SetProperty(ref componenteId, value); }
        }

        string catalogoNome = string.Empty;
        public string CatalogoNome
        {
            get { return catalogoNome; }
            set { SetProperty(ref catalogoNome, value); }
        }

        string categoria = string.Empty;
        public string Categoria
        {
            get { return categoria; }
            set { SetProperty(ref categoria, value); }
        }

        string localizacao = string.Empty;
        public string Localizacao
        {
            get { return localizacao; }
            set { SetProperty(ref localizacao, value); }
        }

        decimal? custoPadrao = 0;
        public decimal? CustoPadrao
        {
            get { return custoPadrao; }
            set { SetProperty(ref custoPadrao, value); }
        }

        string corDeUsoInternoCodigo = string.Empty;
        public string CorDeUsoInternoCodigo
        {
            get { return corDeUsoInternoCodigo; }
            set { SetProperty(ref corDeUsoInternoCodigo, value); }
        }

        public FabricacoesDeComponentesBindingList ComponentesFabricados { get; set; }

        public CorDeFabricanteViewModel(

        )
        {

        }

        public static CorDeFabricanteViewModel From(ICorDeFabricante corDeFabricante)
        {
            var viewModel = new CorDeFabricanteViewModel
            {
                FabricanteId = corDeFabricante.Catalogo.FabricacaoDeComponente.Fabricante.Id,
                ComponenteId = corDeFabricante.Catalogo.FabricacaoDeComponente.Componente.Id,
                CatalogoNome = corDeFabricante.Catalogo.Nome,
                Categoria = corDeFabricante.Categoria,
                Localizacao = corDeFabricante.Localizacao,
                CustoPadrao = corDeFabricante.CustoPadrao,
                CorDeUsoInternoCodigo = corDeFabricante.CorDeUsoInterno.Codigo,
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

    public class CorDeFabricantesBindingList : ExtendedBindingList<CorDeFabricanteViewModel>
    {
        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public CorDeFabricantesBindingList(
            ICadastroDeFabricacoesDeComponentes ICadastroDeFabricacoesDeComponentes,
            IList<CorDeFabricanteViewModel> list
        )
            : base(list)
        {
            this.cadastroDeFabricacoesDeComponentes = ICadastroDeFabricacoesDeComponentes;
        }

        public CorDeFabricantesBindingList(IList<CorDeFabricanteViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(CorDeFabricanteViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeDefinicaoDeCorNoCatalogo = new SolicitacaoDeDefinicaoDeCorNoCatalogo
                {
                    FabricanteId = newItem.FabricanteId,
                    ComponenteId = newItem.ComponenteId,
                    CatalogoNome = newItem.CatalogoNome,
                    Categoria = newItem.Categoria,
                    Localizacao = newItem.Localizacao,
                    CustoPadrao = newItem.CustoPadrao,
                    CorDeUsoInternoCodigo = newItem.CorDeUsoInternoCodigo,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.DefineCorNoCatalogo(solicitacaoDeDefinicaoDeCorNoCatalogo);

                    SetStatus($"Nova cor de fabricante '{newItem.FabricanteId}' definida com sucesso.");
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
                var solicitacaoDeDefinicaoDeCorNoCatalogo = new SolicitacaoDeDefinicaoDeCorNoCatalogo
                {
                    FabricanteId = modifiedItem.FabricanteId,
                    ComponenteId = modifiedItem.ComponenteId,
                    CatalogoNome = modifiedItem.CatalogoNome,
                    Categoria = modifiedItem.Categoria,
                    Localizacao = modifiedItem.Localizacao,
                    CustoPadrao = modifiedItem.CustoPadrao,
                    CorDeUsoInternoCodigo = modifiedItem.CorDeUsoInternoCodigo,
                };

                try
                {
                    var resposta = await cadastroDeFabricacoesDeComponentes.DefineCorNoCatalogo(solicitacaoDeDefinicaoDeCorNoCatalogo);

                    SetStatus($"Cor de fabricante '{modifiedItem.FabricanteId}' definida com sucesso.");
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
                    await cadastroDeFabricacoesDeComponentes.RemoveDefinicaoDeCorDoCatalogo(deletedItem.FabricanteId, deletedItem.ComponenteId, deletedItem.CatalogoNome, deletedItem.CorDeUsoInternoCodigo);

                    SetStatus($"Cor de fabricante '{deletedItem.FabricanteId}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class CorDeFabricantesObservableCollection : ObservableCollection<CorDeFabricanteViewModel>
    {
        public CorDeFabricantesObservableCollection(IList<CorDeFabricanteViewModel> list)
            : base(list)
        {

        }
    }
}

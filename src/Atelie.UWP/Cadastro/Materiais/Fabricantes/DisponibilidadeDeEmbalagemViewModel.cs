using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class DisponibilidadeDeEmbalagemViewModel : ObservableObject, INotifyPropertyChanged
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

        string catalogoNome = string.Empty;
        public string CatalogoNome
        {
            get { return catalogoNome; }
            set { SetProperty(ref catalogoNome, value); }
        }

        string embalagemNome = string.Empty;
        public string EmbalagemNome
        {
            get { return embalagemNome; }
            set { SetProperty(ref embalagemNome, value); }
        }

        string unidadeSigla = string.Empty;
        public string UnidadeSigla
        {
            get { return unidadeSigla; }
            set { SetProperty(ref unidadeSigla, value); }
        }

        double valor = 0;
        public double Valor
        {
            get { return valor; }
            set { SetProperty(ref valor, value); }
        }

        string unidadeBaseSigla = string.Empty;
        public string UnidadeBaseSigla
        {
            get { return unidadeBaseSigla; }
            set { SetProperty(ref unidadeBaseSigla, value); }
        }

        public DisponibilidadeDeEmbalagemViewModel()
        {

        }

        public static DisponibilidadeDeEmbalagemViewModel From(IDisponibilidadeDeEmbalagem disponibilidadeDeEmbalagem)
        {
            var viewModel = new DisponibilidadeDeEmbalagemViewModel
            {
                FabricanteId = disponibilidadeDeEmbalagem.Catalogo.FabricacaoDeComponente.Fabricante.Id,
                ComponenteId = disponibilidadeDeEmbalagem.Catalogo.FabricacaoDeComponente.Componente.Id,
                CatalogoNome = disponibilidadeDeEmbalagem.Catalogo.Nome,
                EmbalagemNome = disponibilidadeDeEmbalagem.EmbalagemNome,
                UnidadeSigla = disponibilidadeDeEmbalagem.Embalagem.Unidade.Sigla,
                Valor = disponibilidadeDeEmbalagem.Embalagem.Valor,
                UnidadeBaseSigla = disponibilidadeDeEmbalagem.Embalagem.UnidadeBase.Sigla,
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

    public class DisponibilidadeDeEmbalagemsBindingList : ExtendedBindingList<DisponibilidadeDeEmbalagemViewModel>
    {
        private readonly ICadastroDeFabricacoesDeComponentes ICadastroDeFabricacoesDeComponentes;

        public DisponibilidadeDeEmbalagemsBindingList(
            ICadastroDeFabricacoesDeComponentes ICadastroDeFabricacoesDeComponentes,
            IList<DisponibilidadeDeEmbalagemViewModel> list
        )
            : base(list)
        {
            this.ICadastroDeFabricacoesDeComponentes = ICadastroDeFabricacoesDeComponentes;
        }

        public DisponibilidadeDeEmbalagemsBindingList(IList<DisponibilidadeDeEmbalagemViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(DisponibilidadeDeEmbalagemViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo = new SolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo
                {
                    FabricanteId = newItem.FabricanteId,
                    ComponenteId = newItem.ComponenteId,
                    CatalogoNome = newItem.CatalogoNome,
                    EmbalagemNome = newItem.EmbalagemNome,
                    UnidadeSigla = newItem.UnidadeSigla,
                    Valor = newItem.Valor,
                    UnidadeBaseSigla = newItem.UnidadeBaseSigla,
                };

                try
                {
                    var resposta = await ICadastroDeFabricacoesDeComponentes.DisponibilizaEmbalagemNoCatalogo(solicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo);

                    SetStatus($"Nova disponibilidade de embalagem '{newItem.FabricanteId}' disponibilizada com sucesso.");
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
                var solicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo = new SolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo
                {
                    FabricanteId = modifiedItem.FabricanteId,
                    ComponenteId = modifiedItem.ComponenteId,
                    CatalogoNome = modifiedItem.CatalogoNome,
                    EmbalagemNome = modifiedItem.EmbalagemNome,
                    UnidadeSigla = modifiedItem.UnidadeSigla,
                    Valor = modifiedItem.Valor,
                    UnidadeBaseSigla = modifiedItem.UnidadeBaseSigla,
                };

                try
                {
                    var resposta = await ICadastroDeFabricacoesDeComponentes.DisponibilizaEmbalagemNoCatalogo(solicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo);

                    SetStatus($"Disponibilidade de embalagem '{modifiedItem.FabricanteId}' atualizada com sucesso.");
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
                    await ICadastroDeFabricacoesDeComponentes.ExcluiDisponibilidadeDeEmbalagemDoCatalogo(deletedItem.FabricanteId, deletedItem.ComponenteId, deletedItem.CatalogoNome, deletedItem.EmbalagemNome);

                    SetStatus($"Disponibilidade de embalagem '{deletedItem.FabricanteId}' salva com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class DisponibilidadeDeEmbalagemsObservableCollection : ObservableCollection<DisponibilidadeDeEmbalagemViewModel>
    {
        public DisponibilidadeDeEmbalagemsObservableCollection(IList<DisponibilidadeDeEmbalagemViewModel> list)
            : base(list)
        {

        }
    }
}

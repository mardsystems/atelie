using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercialViewModel : ObservableObject, INotifyPropertyChanged //, IEditableObject
    {
        //public PlanosComerciaisBindingList BindingList { get; internal set; }

        string id = string.Empty;
        public string Id
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

        decimal receitaBrutaMensal = 0;
        public decimal ReceitaBrutaMensal
        {
            get { return receitaBrutaMensal; }
            set { SetProperty(ref receitaBrutaMensal, value); }
        }

        decimal custoFixo = 0;
        public decimal CustoFixo
        {
            get { return custoFixo; }
            set { SetProperty(ref custoFixo, value); }
        }

        decimal custoFixoPercentual = 0;
        public decimal CustoFixoPercentual
        {
            get { return custoFixoPercentual; }
            set { SetProperty(ref custoFixoPercentual, value); }
        }

        decimal custoVariavel = 0;
        public decimal CustoVariavel
        {
            get { return custoVariavel; }
            set { SetProperty(ref custoVariavel, value); }
        }

        decimal custoPercentual = 0;
        public decimal CustoPercentual
        {
            get { return custoPercentual; }
            set { SetProperty(ref custoPercentual, value); }
        }

        decimal margem = 0;
        public decimal Margem
        {
            get { return margem; }
            set { SetProperty(ref margem, value); }
        }

        decimal margemPercentual = 0;
        public decimal MargemPercentual
        {
            get { return margemPercentual; }
            set { SetProperty(ref margemPercentual, value); }
        }

        decimal taxaDeMarcacao = 0;
        public decimal TaxaDeMarcacao
        {
            get { return taxaDeMarcacao; }
            set { SetProperty(ref taxaDeMarcacao, value); }
        }

        public ItensDePlanoComercialBindingList Itens { get; set; }

        public static PlanoComercialViewModel From(IPlanoComercial planoComercial)
        {
            var itensDePlanoComercial = planoComercial.Itens.Select(p => ItemDePlanoComercialViewModel.From(p)).ToList();

            var itensDePlanoComercialBindingList = new ItensDePlanoComercialBindingList(itensDePlanoComercial);

            var viewModel = new PlanoComercialViewModel
            {
                Id = planoComercial.Id,
                Nome = planoComercial.Nome,
                ReceitaBrutaMensal = planoComercial.ReceitaBrutaMensal,
                CustoFixo = planoComercial.CustoFixo,
                CustoFixoPercentual = planoComercial.CustoFixoPercentual,
                CustoVariavel = planoComercial.CustoVariavel,
                CustoPercentual = planoComercial.CustoPercentual,
                Margem = planoComercial.Margem,
                MargemPercentual = planoComercial.MargemPercentual,
                TaxaDeMarcacao = planoComercial.TaxaDeMarcacao,
                Itens = itensDePlanoComercialBindingList
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

    public class ItemDePlanoComercialViewModel : ObservableObject //, IEditableObject
    {
        string planoComercialId = string.Empty;
        public string PlanoComercialId
        {
            get { return planoComercialId; }
            set { SetProperty(ref planoComercialId, value); }
        }

        string modeloCodigo = string.Empty;
        public string ModeloCodigo
        {
            get { return modeloCodigo; }
            set { SetProperty(ref modeloCodigo, value); }
        }

        string modeloNome = string.Empty;
        public string ModeloNome
        {
            get { return modeloNome; }
            set { SetProperty(ref modeloNome, value); }
        }

        decimal custoDeProducaoValor = 0;
        public decimal CustoDeProducaoValor
        {
            get { return custoDeProducaoValor; }
            set { SetProperty(ref custoDeProducaoValor, value); }
        }

        decimal precoDeVenda = 0;
        public decimal PrecoDeVenda
        {
            get { return precoDeVenda; }
            set { SetProperty(ref precoDeVenda, value); }
        }

        public static ItemDePlanoComercialViewModel From(IItemDePlanoComercial itemDePlanoComercial)
        {
            var viewModel = new ItemDePlanoComercialViewModel
            {
                PlanoComercialId = itemDePlanoComercial.PlanoComercial.Id,
                ModeloCodigo = itemDePlanoComercial.Modelo.Codigo,
                ModeloNome = itemDePlanoComercial.Modelo.Nome,
                CustoDeProducaoValor = itemDePlanoComercial.CustoDeProducao.Valor,
                PrecoDeVenda = itemDePlanoComercial.PrecoDeVenda,
            };

            return viewModel;
        }
    }

    public class PlanosComerciaisBindingList : ExtendedBindingList<PlanoComercialViewModel>
    {
        private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisBindingList()
            : base()
        {

        }

        public PlanosComerciaisBindingList(
            IConsultaDePlanosComerciais consultaDePlanosComerciais,
            IPlanejamentoComercial planejamentoComercial,
            IList<PlanoComercialViewModel> list
        )
            : base(list)
        {
            this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            this.planejamentoComercial = planejamentoComercial;
        }

        public PlanosComerciaisBindingList(IList<PlanoComercialViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(PlanoComercialViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDePlanoComercial = new SolicitacaoDeCriacaoDePlanoComercial
                {
                    Id = newItem.Id,
                    Nome = newItem.Nome,
                    //ComponenteId = newItem.ComponenteId,
                    //FabricanteId = newItem.FabricanteId,
                };

                try
                {
                    var resposta = await planejamentoComercial.CriaPlanoComercial(solicitacaoDeCadastroDePlanoComercial);

                    SetStatus($"Novo planoComercial '{resposta.Id}' cadastrado com sucesso.");
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
                var solicitacaoDeCadastroDePlanoComercial = new SolicitacaoDeCriacaoDePlanoComercial
                {
                    Id = modifiedItem.Id,
                    Nome = modifiedItem.Nome,
                    //ComponenteId = modifiedItem.ComponenteId,
                    //FabricanteId = modifiedItem.FabricanteId,
                };

                try
                {
                    var resposta = await planejamentoComercial.AtualizaPlanoComercial(modifiedItem.Id, solicitacaoDeCadastroDePlanoComercial);

                    SetStatus($"PlanoComercial '{resposta.Id}' atualizado com sucesso.");
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
                    await planejamentoComercial.ExcluiPlanoComercial(deletedItem.Id);

                    SetStatus($"PlanoComercial '{deletedItem.Id}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class ItensDePlanoComercialBindingList : ExtendedBindingList<ItemDePlanoComercialViewModel>
    {
        public ItensDePlanoComercialBindingList(IList<ItemDePlanoComercialViewModel> list)
            : base(list)
        {

        }
    }

    public class PlanosComerciaisObservableCollection : ObservableCollection<PlanoComercialViewModel>
    {
        public PlanosComerciaisObservableCollection(IList<PlanoComercialViewModel> list)
            : base(list)
        {

        }
    }
}

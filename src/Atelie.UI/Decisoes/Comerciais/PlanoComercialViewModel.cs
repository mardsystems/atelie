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
        protected internal PlanoComercial model;

        //public PlanosComerciaisBindingList BindingList { get; internal set; }

        public string Id
        {
            get { return model.Id; }
            //set
            //{
            //    OnPropertyChanged();
            //}
        }

        public string Nome
        {
            get { return model.Nome; }
            set
            {
                model.DefineNome(value);

                OnPropertyChanged();
            }
        }

        public decimal RendaBrutaMensal
        {
            get { return model.ReceitaBrutaMensal; }
            set
            {
                model.DefineRendaBrutaMensal(value);

                OnPropertyChanged();
            }
        }

        public decimal CustoFixo
        {
            get { return model.CustoFixo; }
            set
            {
                OnPropertyChanged();
            }
        }

        public decimal CustoFixoPercentual
        {
            get { return model.CustoFixoPercentual; }
            set
            {
                OnPropertyChanged();
            }
        }

        public decimal CustoVariavel
        {
            get { return model.CustoVariavel; }
            set
            {
                OnPropertyChanged();
            }
        }

        public decimal CustoPercentual
        {
            get { return model.CustoPercentual; }
            set
            {
                OnPropertyChanged();
            }
        }

        public decimal Margem
        {
            get { return model.Margem; }
            set
            {
                model.DefineMargem(value);

                OnPropertyChanged();
            }
        }

        public decimal MargemPercentual
        {
            get { return model.MargemPercentual; }
            set
            {
                model.DefineMargemPercentual(value);

                OnPropertyChanged();

                OnPropertyChanged("TaxaDeMarcacao");
            }
        }

        public decimal TaxaDeMarcacao
        {
            get { return model.TaxaDeMarcacao; }
            set
            {
                OnPropertyChanged();
            }
        }

        public ItensDePlanoComercialBindingList Itens { get; set; }

        public static PlanoComercialViewModel From(IPlanoComercial planoComercial)
        {
            var itensDePlanoComercial = planoComercial.Itens.Select(p => ItemDePlanoComercialViewModel.From(p)).ToList();

            var itensDePlanoComercialBindingList = new ItensDePlanoComercialBindingList(itensDePlanoComercial);

            var viewModel = new PlanoComercialViewModel
            {
                model = planoComercial as PlanoComercial,
                //Id = planoComercial.Id,
                Nome = planoComercial.Nome,
                RendaBrutaMensal = planoComercial.ReceitaBrutaMensal,
                CustoFixo = planoComercial.CustoFixo,
                CustoFixoPercentual = planoComercial.CustoFixoPercentual,
                CustoVariavel = planoComercial.CustoVariavel,
                CustoPercentual = planoComercial.CustoPercentual,
                Margem = planoComercial.Margem,
                MargemPercentual = planoComercial.MargemPercentual,
                TaxaDeMarcacao = planoComercial.TaxaDeMarcacao,
                Itens = itensDePlanoComercialBindingList
            };

            itensDePlanoComercialBindingList.planoComercial = viewModel;

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

        //protected override object AddNewCore()
        //{
        //    var model = new PlanoComercial(
        //        Guid.NewGuid().ToString(),
        //        null,
        //        6000,
        //        20
        //    );

        //    var viewModel = PlanoComercialViewModel.From(model);

        //    OnAddNew(viewModel);

        //    return viewModel;
        //}

        protected override void OnAddNew(PlanoComercialViewModel viewModel)
        {
            //item.BindingList = this;

            var model = new PlanoComercial(
                            Guid.NewGuid().ToString(),
                            null,
                            6000,
                            20
                        );

            viewModel.model = model;

            //viewModel.Itens.planoComercial = viewModel;

            base.OnAddNew(viewModel);
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
        protected internal PlanoComercialViewModel planoComercial;

        public ItensDePlanoComercialBindingList(IList<ItemDePlanoComercialViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(ItemDePlanoComercialViewModel viewModel)
        {
            viewModel.PlanoComercialId = planoComercial.Id;

            base.OnAddNew(viewModel);
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

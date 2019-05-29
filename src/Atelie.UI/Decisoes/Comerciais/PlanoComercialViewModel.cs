using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercialViewModel : ObservableObject, INotifyPropertyChanged, IEditableObject, INotifyDataErrorInfo //, IDataErrorInfo
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

        private string nome;
        [Required(ErrorMessage = "Teste")]
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;

                OnPropertyChanged();

                try
                {
                    model.DefineNome(value);

                    ClearErrors("Nome");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("Nome", ex);
                }
            }
        }

        public decimal RendaBrutaMensal
        {
            get { return model.RendaBrutaMensal; }
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

        private string margemPercentual;
        public string MargemPercentual
        {
            get { return margemPercentual; }
            set
            {
                margemPercentual = value;

                OnPropertyChanged();

                try
                {
                    var value2 = Convert.ToDecimal(value);

                    model.DefineMargemPercentual(value2);

                    OnPropertyChanged("TaxaDeMarcacao");

                    ClearErrors("MargemPercentual");

                    ClearErrors("TaxaDeMarcacao");
                }
                catch (Exception ex)
                {
                    RaiseErrorsChanged("MargemPercentual", ex);

                    RaiseErrorsChanged("TaxaDeMarcacao", ex);
                }
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

        public ItensDePlanoComercialObservableCollection Itens { get; set; }

        public PlanoComercialViewModel()
        {
            Itens = new ItensDePlanoComercialObservableCollection(new List<ItemDePlanoComercialViewModel>() { });

            Itens.planoComercial = this;
        }

        public static PlanoComercialViewModel From(PlanoComercial planoComercial)
        {
            var itensDePlanoComercial = planoComercial.Itens.Select(p => ItemDePlanoComercialViewModel.From(p)).ToList();

            var itensDePlanoComercialObservableCollection = new ItensDePlanoComercialObservableCollection(itensDePlanoComercial);

            var viewModel = new PlanoComercialViewModel
            {
                model = planoComercial as PlanoComercial,
                //Id = planoComercial.Id,
                Nome = planoComercial.Nome,
                RendaBrutaMensal = planoComercial.RendaBrutaMensal,
                CustoFixo = planoComercial.CustoFixo,
                CustoFixoPercentual = planoComercial.CustoFixoPercentual,
                CustoVariavel = planoComercial.CustoVariavel,
                CustoPercentual = planoComercial.CustoPercentual,
                Margem = planoComercial.Margem,
                MargemPercentual = planoComercial.MargemPercentual.ToString(),
                TaxaDeMarcacao = planoComercial.TaxaDeMarcacao,
                Itens = itensDePlanoComercialObservableCollection
            };

            itensDePlanoComercialObservableCollection.planoComercial = viewModel;

            return viewModel;
        }

        private bool inEdidt;

        public void BeginEdit()
        {
            if (inEdidt)
            {
                return;
            }

            inEdidt = true;
        }

        public void EndEdit()
        {
            if (!inEdidt)
            {
                return;
            }

            inEdidt = false;
        }

        public void CancelEdit()
        {
            if (!inEdidt)
            {
                return;
            }

            inEdidt = false;

            nome = model.Nome;

            margemPercentual = model.MargemPercentual.ToString();
        }

        protected readonly Dictionary<string, IList<Exception>> validationErrors = new Dictionary<string, IList<Exception>>();

        private void ClearErrors(string propertyName)
        {
            if (!validationErrors.ContainsKey(propertyName))
            {
                return;
            }

            validationErrors.Remove(propertyName);

            OnErrorsChanged(propertyName);
        }

        private void RaiseErrorsChanged(string propertyName, Exception exception)
        {
            IList<Exception> errors;

            if (validationErrors.ContainsKey(propertyName))
            {
                errors = validationErrors[propertyName];
            }
            else
            {
                errors = new List<Exception>();

                validationErrors.Add(propertyName, errors);
            }

            errors.Add(exception);

            OnErrorsChanged(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public bool HasErrors
        {
            get { return validationErrors.Count > 0; }
        }

        public string Error => "teste";

        public string this[string columnName]
        {
            get
            {
                if (validationErrors.Count == 0)
                {
                    return null;
                }

                if (validationErrors[columnName].Count > 0)
                {
                    return validationErrors[columnName][0].Message;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !validationErrors.ContainsKey(propertyName))
            {
                return null;
            }

            return validationErrors[propertyName];
        }
    }

    public class ItemDePlanoComercialViewModel : ObservableObject //, IEditableObject
    {
        protected internal ItemDePlanoComercial model;

        public string PlanoComercialId
        {
            get { return model.PlanoComercial.Id; }
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

        public decimal CustoDeProducaoValor
        {
            get { return model.CustoDeProducao.Valor; }
            set
            {
                model.DefineCustoDeProducao(value);

                OnPropertyChanged();

                OnPropertyChanged("PrecoDeVenda");
            }
        }

        public decimal PrecoDeVenda
        {
            get { return model.PrecoDeVenda; }
            set
            {
                OnPropertyChanged();
            }
        }

        public ItemDePlanoComercialViewModel()
        {

        }

        public static ItemDePlanoComercialViewModel From(ItemDePlanoComercial itemDePlanoComercial)
        {
            var viewModel = new ItemDePlanoComercialViewModel
            {
                model = itemDePlanoComercial as ItemDePlanoComercial,
                //PlanoComercialId = itemDePlanoComercial.PlanoComercial.Id,
                //ModeloCodigo = itemDePlanoComercial.Modelo.Codigo,
                //ModeloNome = itemDePlanoComercial.Modelo.Nome,
                CustoDeProducaoValor = itemDePlanoComercial.CustoDeProducao.Valor,
                PrecoDeVenda = itemDePlanoComercial.PrecoDeVenda,
            };

            return viewModel;
        }
    }

    public class PlanosComerciaisObservableCollection : ExtendedObservableCollection<PlanoComercialViewModel>
    {
        private readonly PlanosComerciaisLocalService planosComerciaisLocalService;

        //private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        //private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisObservableCollection()
            : base()
        {

        }

        public PlanosComerciaisObservableCollection(
            PlanosComerciaisLocalService planosComerciaisLocalService,
            //IConsultaDePlanosComerciais consultaDePlanosComerciais,
            //IPlanejamentoComercial planejamentoComercial,
            IList<PlanoComercialViewModel> list
        )
            : base(list)
        {
            this.planosComerciaisLocalService = planosComerciaisLocalService;

            //this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            //this.planejamentoComercial = planejamentoComercial;
        }

        public PlanosComerciaisObservableCollection(IList<PlanoComercialViewModel> list)
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
            try
            {
                await planosComerciaisLocalService.SaveChanges();

                SetStatus($"PlanoComercial salvo com sucesso.");
            }
            catch (Exception ex)
            {
                SetStatus(ex.Message);
            }

            //var newItems = GetItemsBy(ObjectState.New);

            //foreach (var newItem in newItems)
            //{
            //    try
            //    {
            //        await planosComerciaisLocalService.Add(newItem.model);

            //        SetStatus($"Novo planoComercial '{newItem.model.Id}' cadastrado com sucesso.");
            //    }
            //    catch (Exception ex)
            //    {
            //        SetStatus(ex.Message);
            //    }
            //}

            ////

            //var modifiedItems = GetItemsBy(ObjectState.Modified);

            //foreach (var modifiedItem in modifiedItems)
            //{
            //    try
            //    {
            //        await planosComerciaisLocalService.Update(modifiedItem.model);

            //        SetStatus($"PlanoComercial '{modifiedItem.Id}' atualizado com sucesso.");
            //    }
            //    catch (Exception ex)
            //    {
            //        SetStatus(ex.Message);
            //    }
            //}

            ////

            //var deletedItems = GetItemsBy(ObjectState.Deleted);

            //foreach (var deletedItem in deletedItems)
            //{
            //    try
            //    {
            //        await planosComerciaisLocalService.Remove(deletedItem.model);

            //        SetStatus($"PlanoComercial '{deletedItem.Id}' excluído com sucesso.");
            //    }
            //    catch (Exception ex)
            //    {
            //        SetStatus(ex.Message);
            //    }
            //}
        }
    }

    public class ItensDePlanoComercialObservableCollection : ExtendedObservableCollection<ItemDePlanoComercialViewModel>
    {
        protected internal PlanoComercialViewModel planoComercial;

        public ItensDePlanoComercialObservableCollection(IList<ItemDePlanoComercialViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(ItemDePlanoComercialViewModel viewModel)
        {
            var model = planoComercial.model.AdicionaItem(null);

            viewModel.model = model;

            //viewModel.PlanoComercialId = planoComercial.Id;

            base.OnAddNew(viewModel);
        }
    }
}

using Atelie.Cadastro.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atelie.Decisoes.Comerciais
{
    /// <summary>
    /// Interaction logic for PlanosComerciaisWindow.xaml
    /// </summary>
    public partial class PlanosComerciaisWindow
    {
        private readonly PlanosComerciaisLocalService planosComerciaisLocalService;

        private readonly ModelosLocalService modelosLocalService;

        //private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        //private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisWindow(
            PlanosComerciaisLocalService planosComerciaisLocalService,
            ModelosLocalService modelosLocalService
        //IConsultaDePlanosComerciais consultaDePlanosComerciais,
        //IPlanejamentoComercial planejamentoComercial
        )
        {
            this.planosComerciaisLocalService = planosComerciaisLocalService;

            this.modelosLocalService = modelosLocalService;

            //this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            //this.planejamentoComercial = planejamentoComercial;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var planosComerciais = await planosComerciaisLocalService.ObtemObservavelDePlanosComerciais();

            var list = planosComerciais.Select(p => PlanoComercialViewModel.From(p)).ToList();

            var observableCollection = new PlanosComerciaisObservableCollection(
                planosComerciaisLocalService,
                //consultaDePlanosComerciais,
                //planejamentoComercial,
                list
            );

            //planosComerciaisBindingSource.DataSource = bindingList;

            observableCollection.StatusChanged += SetStatusBar;

            CollectionViewSource planosComerciaisViewSource = ((CollectionViewSource)(this.FindResource("planosComerciaisViewSource")));

            planosComerciaisViewSource.Source = observableCollection;
        }

        private void SetStatusBar(string value)
        {
            statusBarLabel.Content = value;

            //statusBarTimer.Enabled = true;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource planosComerciaisViewSource = ((CollectionViewSource)(this.FindResource("planosComerciaisViewSource")));

            var observableCollection = (PlanosComerciaisObservableCollection)planosComerciaisViewSource.Source;

            await observableCollection.SaveChanges();
        }

        private void AdicionarModeloButton_Click(object sender, RoutedEventArgs e)
        {
            var consultaDeModelosWindow = new ConsultaDeModelosWindow(
                modelosLocalService
            );

            var selecteds = GetSelectedItens();

            consultaDeModelosWindow.SetSelecteds(selecteds);

            consultaDeModelosWindow.ShowDialog();

            var planoComercial = planosComerciaisDataGrid.CurrentItem as PlanoComercialViewModel;

            var modelos = consultaDeModelosWindow.GetSelecteds();

            foreach (var modelo in modelos)
            {
                if (!planoComercial.Itens.Contains(modelo))
                {
                    planoComercial.Itens.AdicionaItem(modelo);
                }
            }
        }

        private IEnumerable<ModeloViewModel> GetSelectedItens()
        {
            var list = new List<ModeloViewModel>();

            foreach (var item in itensDataGrid.Items)
            {
                var viewModel = item as ItemDePlanoComercialViewModel;

                list.Add(viewModel.Modelo);
            }

            return list;
        }
    }

    public class PlanoComercialValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            PlanoComercialViewModel viewModel = (value as BindingGroup).Items[0] as PlanoComercialViewModel;

            if (viewModel.HasErrors)
            {
                return new ValidationResult(false, viewModel.Error);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

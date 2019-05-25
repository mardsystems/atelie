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

        //private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        //private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisWindow(
            PlanosComerciaisLocalService planosComerciaisLocalService
            //IConsultaDePlanosComerciais consultaDePlanosComerciais,
            //IPlanejamentoComercial planejamentoComercial
        )
        {
            this.planosComerciaisLocalService = planosComerciaisLocalService;

            //this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            //this.planejamentoComercial = planejamentoComercial;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var planosComerciais = await ((IConsultaDePlanosComerciais)planosComerciaisLocalService).ObtemObservavelDePlanosComerciais();

            //var list = planosComerciais.Select(p => PlanoComercialViewModel.From(p)).ToList();

            var observableCollection = new PlanosComerciaisObservableCollection(
                //planosComerciaisLocalService,
                //consultaDePlanosComerciais,
                //planejamentoComercial,
                //list
            );

            //planosComerciaisBindingSource.DataSource = bindingList;

            observableCollection.StatusChanged += SetStatusBar;

            CollectionViewSource planoComercialViewModelViewSource = ((CollectionViewSource)(this.FindResource("planoComercialViewModelViewSource")));

            planoComercialViewModelViewSource.Source = observableCollection;
        }

        private void SetStatusBar(string value)
        {
            //mainToolStripStatusLabel.Text = value;

            //statusBarTimer.Enabled = true;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource planoComercialViewModelViewSource = ((CollectionViewSource)(this.FindResource("planoComercialViewModelViewSource")));

            var observableCollection = (PlanosComerciaisObservableCollection)planoComercialViewModelViewSource.Source;

            await observableCollection.SaveChanges();
        }
    }
}

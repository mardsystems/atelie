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
    public partial class PlanosComerciaisWindow : Window
    {
        private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisWindow(
            IConsultaDePlanosComerciais consultaDePlanosComerciais,
            IPlanejamentoComercial planejamentoComercial
        )
        {
            this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            this.planejamentoComercial = planejamentoComercial;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var planosComerciais = await consultaDePlanosComerciais.ObtemObservavelDePlanosComerciais();

            var list = planosComerciais.Select(p => PlanoComercialViewModel.From(p)).ToList();

            var bindingList = new PlanosComerciaisBindingList(
                consultaDePlanosComerciais,
                planejamentoComercial,
                list
            );

            //planosComerciaisBindingSource.DataSource = bindingList;

            bindingList.StatusChanged += SetStatusBar;

            System.Windows.Data.CollectionViewSource planoComercialViewModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planoComercialViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            planoComercialViewModelViewSource.Source = bindingList;
        }

        private void SetStatusBar(string value)
        {
            //mainToolStripStatusLabel.Text = value;

            //statusBarTimer.Enabled = true;
        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            System.Windows.Data.CollectionViewSource planoComercialViewModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planoComercialViewModelViewSource")));

            var bindingList = (PlanosComerciaisBindingList)planoComercialViewModelViewSource.Source;

            await bindingList.SaveChanges();
        }
    }
}

using Atelie.Cadastro.Materiais.Componentes;
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

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    /// <summary>
    /// Interaction logic for FabricantesWindow.xaml
    /// </summary>
    public partial class FabricantesWindow : Window
    {
        private readonly ICadastroDeFabricantes cadastroDeFabricantes;

        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        public FabricantesWindow(
            ICadastroDeFabricantes cadastroDeFabricantes,
            IConsultaDeComponentes consultaDeComponentes,
            IConsultaDeFabricantes consultaDeFabricantes
        )
        {
            this.cadastroDeFabricantes = cadastroDeFabricantes;

            this.consultaDeComponentes = consultaDeComponentes;

            this.consultaDeFabricantes = consultaDeFabricantes;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fabricantes = await consultaDeFabricantes.ObtemObservavelDeFabricantes();

            var list = fabricantes.Select(p => FabricanteViewModel.From(p)).ToList();

            var observableCollection = new FabricantesObservableCollection(
                cadastroDeFabricantes,
                list
            );

            //fabricantesBindingSource.DataSource = bindingList;

            //bindingList.StatusChanged += SetStatusBar;

            //

            //componentesBindingSource.DataSource = await consultaDeComponentes.ParaDropdown();

            CollectionViewSource fabricanteViewModelViewSource = ((CollectionViewSource)(this.FindResource("fabricanteViewModelViewSource")));

            fabricanteViewModelViewSource.Source = observableCollection;
        }
    }
}

using Atelie.Cadastro.Materiais.Componentes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FabricantesPage : Page
    {
        public FabricantesObservableCollection Fabricantes;

        public FabricantesPage()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Fabricantes = new FabricantesObservableCollection(new FabricanteViewModel[] { });
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter as FabricantesPageParameter;

            ////

            //var fabricantes = await consultaDeFabricantes.ObtemObservavelDeFabricantes();

            //var list = fabricantes.Select(p => FabricanteViewModel.From(p)).ToList();

            //var observableCollection = new FabricantesObservableCollection(
            //    cadastroDeFabricantes,
            //    list
            //);

            //Fabricantes = observableCollection;

            //fabricantesBindingSource.DataSource = bindingList;

            //bindingList.StatusChanged += SetStatusBar;

            //

            //componentesBindingSource.DataSource = await consultaDeComponentes.ParaDropdown();

            //CollectionViewSource fabricanteViewModelViewSource = ((CollectionViewSource)(this.FindResource("fabricanteViewModelViewSource")));

            //fabricanteViewModelViewSource.Source = observableCollection;
        }
    }

    public class FabricantesPageParameter
    {
        //public ICadastroDeFabricantes CadastroDeFabricantes { get; set; }

        //public IConsultaDeComponentes ConsultaDeComponentes { get; set; }

        //public IConsultaDeFabricantes ConsultaDeFabricantes { get; set; }
    }
}

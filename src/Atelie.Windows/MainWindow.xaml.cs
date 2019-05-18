using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atelie.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Container container;

        public MainWindow()
        {
            InitializeComponent();

            var package = new InfrastructurePackage();

            container = new Container();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            container.RegisterPackages(assemblies);
        }

        private void CadastroDeFabricantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cadastroDeFabricantes = container.GetInstance<ICadastroDeFabricantes>();

            var consultaDeComponentes = container.GetInstance<IConsultaDeComponentes>();

            var consultaDeFabricantes = container.GetInstance<IConsultaDeFabricantes>();

            var fabricantesWindow = new FabricantesWindow(
                cadastroDeFabricantes,
                consultaDeComponentes,
                consultaDeFabricantes
            );

            fabricantesWindow.Show();
        }
    }
}

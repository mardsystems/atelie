using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Modelos;
using Atelie.Decisoes.Comerciais;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelie
{
    public partial class MainForm : Form
    {
        readonly Container container;

        public MainForm()
        {
            InitializeComponent();

            var package = new InfrastructurePackage();

            container = new Container();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            container.RegisterPackages(assemblies);
        }

        private void CadastroDeMateriaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaDeMateriais = container.GetInstance<IConsultaDeMateriais>();

            var cadastroDeMateriais = container.GetInstance<ICadastroDeMateriais>();

            var consultaDeComponentes = container.GetInstance<IConsultaDeComponentes>();

            var consultaDeFabricantes = container.GetInstance<IConsultaDeFabricantes>();

            var materiaisForm = new MateriaisForm(
                consultaDeMateriais,
                cadastroDeMateriais,
                consultaDeComponentes,
                consultaDeFabricantes
            );

            materiaisForm.Show();
        }

        private void CadastroDeFabricantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cadastroDeFabricantes = container.GetInstance<ICadastroDeFabricantes>();

            var consultaDeComponentes = container.GetInstance<IConsultaDeComponentes>();

            var consultaDeFabricantes = container.GetInstance<IConsultaDeFabricantes>();

            var fabricantesForm = new FabricantesForm(
                cadastroDeFabricantes,
                consultaDeComponentes,
                consultaDeFabricantes
            );

            fabricantesForm.Show();
        }

        private void CadastroDeComponentesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CadastroDeModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelosForm = new ModelosForm();

            modelosForm.Show();
        }

        private void PlanejamentoComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaDePlanosComerciais = container.GetInstance<IConsultaDePlanosComerciais>();

            var planejamentoComercial = container.GetInstance<IPlanejamentoComercial>();

            var planosComerciaisForm = new PlanosComerciaisForm(
                consultaDePlanosComerciais,
                planejamentoComercial
            );

            planosComerciaisForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelie.Decisoes.Comerciais
{
    public partial class PlanosComerciaisForm : Form
    {
        private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisForm(
            IConsultaDePlanosComerciais consultaDePlanosComerciais,
            IPlanejamentoComercial planejamentoComercial
        )
        {
            this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            this.planejamentoComercial = planejamentoComercial;

            InitializeComponent();
        }

        private async void PlanejamentoComercialForm_Load(object sender, EventArgs e)
        {
            var planosComerciais = await consultaDePlanosComerciais.ObtemObservavelDePlanosComerciais();

            var list = planosComerciais.Select(p => PlanoComercialViewModel.From(p)).ToList();

            var bindingList = new PlanosComerciaisBindingList(
                consultaDePlanosComerciais,
                planejamentoComercial,
                list
            );

            planosComerciaisBindingSource.DataSource = bindingList;

            bindingList.StatusChanged += SetStatusBar;
        }

        private void SetStatusBar(string value)
        {
            mainToolStripStatusLabel.Text = value;

            statusBarTimer.Enabled = true;
        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            var bindingList = (PlanosComerciaisBindingList)planosComerciaisBindingSource.DataSource;

            await bindingList.SaveChanges();
        }
    }
}

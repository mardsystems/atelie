using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
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

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public partial class FabricantesForm : Form
    {
        private readonly ICadastroDeFabricantes cadastroDeFabricantes;

        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        public FabricantesForm(
            ICadastroDeFabricantes cadastroDeFabricantes,
            IConsultaDeComponentes consultaDeComponentes,
            IConsultaDeFabricantes consultaDeFabricantes
        )
        {
            this.cadastroDeFabricantes = cadastroDeFabricantes;

            this.consultaDeComponentes = consultaDeComponentes;

            this.consultaDeFabricantes = consultaDeFabricantes;

            InitializeComponent();

            var obs = Observable.FromEventPattern<DataGridViewRowsAddedEventHandler, DataGridViewRowsAddedEventArgs>(
                h => fabricantesDataGridView.RowsAdded += h,
                h => fabricantesDataGridView.RowsAdded -= h);

            obs.Subscribe((p) =>
            {
                SetStatusBar("linha adicionada...");
            });
        }

        private async void FabricantesForm_Load(object sender, EventArgs e)
        {
            var fabricantes = await consultaDeFabricantes.ObtemObservavelDeFabricantes();

            var list = fabricantes.Select(p => FabricanteViewModel.From(p)).ToList();

            var bindingList = new FabricantesBindingList(
                cadastroDeFabricantes,
                list
            );

            fabricantesBindingSource.DataSource = bindingList;

            bindingList.StatusChanged += SetStatusBar;

            //

            componentesBindingSource.DataSource = await consultaDeComponentes.ParaDropdown();
        }

        private void FabricantesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var fabricanteViewModel = (FabricanteViewModel)fabricantesBindingSource.Current;

            //componentesFabricadosBindingSource.DataSource = fabricanteViewModel.ComponentesFabricados;
        }

        private void ComponentesFabricadosBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var fabricanteViewModel = (FabricanteViewModel)fabricantesBindingSource.Current;

            var fabricacaoDeComponenteViewModel = (FabricacaoDeComponenteViewModel)componentesFabricadosBindingSource.Current;

            if (fabricacaoDeComponenteViewModel == null)
            {
                return;
            }

            fabricacaoDeComponenteViewModel.FabricanteId = fabricanteViewModel.Id;
        }

        private void SetStatusBar(string value)
        {
            mainToolStripStatusLabel.Text = value;

            //statusBarTimer.Enabled = true;
        }

        private void FabricantesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            mainToolStripStatusLabel.Text = e.Exception.Message;
        }

        private void ComponentesFabricadosDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            mainToolStripStatusLabel.Text = e.Exception.Message;
        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            var bindingList = (FabricantesBindingList)fabricantesBindingSource.DataSource;

            await bindingList.SaveChanges();
        }
    }
}

using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelie.Cadastro.Materiais
{
    public partial class MateriaisForm : Form
    {
        private readonly IConsultaDeMateriais consultaDeMateriais;

        private readonly ICadastroDeMateriais cadastroDeMateriais;

        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        public MateriaisForm(
            IConsultaDeMateriais consultaDeMateriais,
            ICadastroDeMateriais cadastroDeMateriais,
            IConsultaDeComponentes consultaDeComponentes,
            IConsultaDeFabricantes consultaDeFabricantes
        )
        {
            this.consultaDeMateriais = consultaDeMateriais;

            this.cadastroDeMateriais = cadastroDeMateriais;

            this.consultaDeComponentes = consultaDeComponentes;

            this.consultaDeFabricantes = consultaDeFabricantes;

            InitializeComponent();

            //materialBindingSource.AllowNew = false;

            SetMode(false);

            //var groupedKeyPresses =
            //    Observable.FromEventPattern<KeyPressEventHandler, KeyPressEventArgs>(
            //        h => KeyPress += h,
            //        h => KeyPress -= h)
            //        .Select(k => k.EventArgs.KeyChar)
            //        .GroupBy(k => k);

            //groupedKeyPresses.Subscribe((p) =>
            //{
            //    SetStatusBar(p.Key.ToString());
            //});

            var obs = Observable.FromEventPattern<DataGridViewRowsAddedEventHandler, DataGridViewRowsAddedEventArgs>(
                h => materialDataGridView.RowsAdded += h,
                h => materialDataGridView.RowsAdded -= h);

            obs.Subscribe((p) =>
            {
                SetStatusBar("linha adicionada...");
            });
        }

        private async void MateriaisForm_Load(object sender, EventArgs e)
        {
            componentesBindingSource.DataSource = await consultaDeComponentes.ParaDropdown();

            //

            var fabricantes = await consultaDeFabricantes.ObtemObservavelDeFabricantes();

            fabricanteDataGridViewComboBoxColumn.DataSource = fabricantes.ToList();

            fabricanteDataGridViewComboBoxColumn.ValueMember = "Id";

            fabricanteDataGridViewComboBoxColumn.DisplayMember = "Nome";

            //

            var materiais = await consultaDeMateriais.ObtemObservavelDeMateriais();

            var list = materiais.Select(p => MaterialViewModel.From(p)).ToList();

            var bindingList = new MateriaisBindingList(
                consultaDeMateriais,
                cadastroDeMateriais,
                consultaDeComponentes,
                consultaDeFabricantes,
                list
            );

            materialBindingSource.DataSource = bindingList;

            bindingList.StatusChanged += SetStatusBar;
        }

        private void NovoMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoMaterial();
        }

        private void NovoMaterialToolStripButton_Click(object sender, EventArgs e)
        {
            NovoMaterial();
        }

        private void MaterialDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var item = (MaterialViewModel)materialDataGridView.Rows[e.RowIndex].DataBoundItem;

            var materialId = (item == null ? new int?() : item.Id);

            NovoMaterial(materialId);
        }

        private void NovoMaterial(int? materialId = null)
        {
            var cadastroDeMateriaisForm = new MaterialForm(
                consultaDeMateriais,
                cadastroDeMateriais,
                consultaDeComponentes,
                consultaDeFabricantes,
                materialId
            );

            cadastroDeMateriaisForm.Show();
        }

        private void MaterialDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MaterialDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var cell = materialDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            var item = (MaterialViewModel)materialDataGridView.Rows[e.RowIndex].DataBoundItem;

            if (materialDataGridView.Columns[e.ColumnIndex].Name == "fabricanteDataGridViewLinkColumn")
            {
                var linkCell = (DataGridViewLinkCell)cell;

                var cadastroDeMateriaisForm = new MaterialForm(
                    consultaDeMateriais,
                    cadastroDeMateriais,
                    consultaDeComponentes,
                    consultaDeFabricantes,
                    item.Id
                );

                SetStatusBar("Cadastrando material...");

                cadastroDeMateriaisForm.Show();
            }
            else if (materialDataGridView.Columns[e.ColumnIndex].Name == "fabricanteSiteDataGridViewLinkColumn")
            {
                var linkCell = (DataGridViewLinkCell)cell;

                string value = linkCell.Value.ToString();

                SetStatusBar("Abrindo site do fabricante...");

                Process.Start(value);
            }
        }

        private void MaterialDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            mainToolStripStatusLabel.Text = e.Exception.Message;
        }

        private void EditModeToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(editModeToolStripButton.Checked);
        }

        private void SetMode(bool edit)
        {
            componenteDataGridViewComboBoxColumn.Visible = edit;

            componenteDataGridViewLinkColumn.Visible = !edit;

            fabricanteDataGridViewComboBoxColumn.Visible = edit;

            fabricanteDataGridViewLinkColumn.Visible = !edit;
        }

        private void SetStatusBar(string value)
        {
            mainToolStripStatusLabel.Text = value;

            statusBarTimer.Enabled = true;
        }

        private void StatusBarTimer_Tick(object sender, EventArgs e)
        {
            mainToolStripStatusLabel.Text = "Pronto.";

            statusBarTimer.Enabled = false;
        }

        private void MaterialDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            var bindingList = (MateriaisBindingList)materialBindingSource.DataSource;

            await bindingList.SaveChanges();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Atelie.Cadastro.Materiais
{
    public partial class MaterialForm : Form
    {
        private readonly IConsultaDeMateriais consultaDeMateriais;

        private readonly ICadastroDeMateriais cadastroDeMateriais;

        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        private readonly int? materialId;

        public MaterialForm(
            IConsultaDeMateriais consultaDeMateriais,
            ICadastroDeMateriais cadastroDeMateriais,
            IConsultaDeComponentes consultaDeComponentes,
            IConsultaDeFabricantes consultaDeFabricantes,
            int? materialId = null
        )
        {
            this.consultaDeMateriais = consultaDeMateriais;

            this.cadastroDeMateriais = cadastroDeMateriais;

            this.consultaDeComponentes = consultaDeComponentes;

            this.consultaDeFabricantes = consultaDeFabricantes;

            this.materialId = materialId;

            InitializeComponent();
        }

        private async void MaterialForm_Load(object sender, EventArgs e)
        {
            var componentes = await consultaDeComponentes.ObtemObservavelDeComponentes();

            componentesComboBox.DataSource = componentes.ToList();

            componentesComboBox.ValueMember = "Id";

            componentesComboBox.DisplayMember = "Nome";

            //

            var fabricantes = await consultaDeFabricantes.ObtemObservavelDeFabricantes();

            fabricantesComboBox.DataSource = fabricantes.ToList();

            fabricantesComboBox.ValueMember = "Id";

            fabricantesComboBox.DisplayMember = "Nome";

            //

            if (materialId.HasValue)
            {
                idTextBox.Text = materialId.Value.ToString();

                var materiais = await consultaDeMateriais.ObtemObservavelDeMateriais();

                var material = materiais.Where(p => p.Id == materialId).FirstOrDefault();

                if (material == default(IMaterial))
                {
                    return;
                }

                nomeTextBox.Text = material.Nome;

                custoPadraoTextBox.Text = material.CustoPadrao.ToString();

                descricaoTextBox.Text = material.Descricao;

                componentesComboBox.SelectedValue = material.Componente.Id;

                fabricantesComboBox.SelectedValue = material.Fabricante.Id;
            }
        }

        private async void SalvarButton_Click(object sender, EventArgs e)
        {
            var solicitacao = new SolicitacaoDeCadastroDeMaterial
            {
                Id = Convert.ToInt32(idTextBox.Text),
                Nome = nomeTextBox.Text,
                CustoPadrao = Convert.ToDecimal(custoPadraoTextBox.Text),
                Descricao = descricaoTextBox.Text,
                ComponenteId = Convert.ToInt32(componentesComboBox.SelectedValue),
                FabricanteId = Convert.ToInt32(fabricantesComboBox.SelectedValue)
            };

            var resposta = await cadastroDeMateriais.CadastraMaterial(solicitacao);

            Close();
        }
    }
}

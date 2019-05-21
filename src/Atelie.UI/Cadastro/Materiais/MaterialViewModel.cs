using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public class MaterialViewModel : ObservableObject, INotifyPropertyChanged //, IEditableObject
    {
        //public MateriaisBindingList BindingList { get; internal set; }

        public int Id { get; set; }

        string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        public string Descricao { get; set; }

        //public decimal? CustoPadrao { get; set; }

        int componenteId = 0;
        public int ComponenteId
        {
            get { return componenteId; }
            set
            {

                SetProperty(ref componenteId, value);
            }
        }

        public string ComponenteNome { get; set; }

        public int? ComponentePaiId { get; set; }

        public string ComponentePaiNome { get; set; }

        public string ComponenteUnidadePadraoSigla { get; set; }

        public int FabricanteId { get; set; }

        public string FabricanteNome { get; set; }

        public string FabricanteMarca { get; set; }

        public string FabricanteSite { get; set; }

        string cor = string.Empty;
        public string Cor
        {
            get { return cor; }
            set { SetProperty(ref cor, value); }
        }

        double tamanho = 0;
        public double Tamanho
        {
            get { return tamanho; }
            set { SetProperty(ref tamanho, value); }
        }

        string unidadeSigla = string.Empty;
        public string UnidadeSigla
        {
            get { return unidadeSigla; }
            set
            {

                SetProperty(ref unidadeSigla, value);
            }
        }

        public static MaterialViewModel From(IMaterial material)
        {
            var viewModel = new MaterialViewModel
            {
                Id = material.Id,
                Nome = material.Nome,
                Descricao = material.Descricao,
                //CustoPadrao = material.CustoPadrao,
                ComponenteId = material.Componente.Id,
                ComponenteNome = material.Componente.Nome,
                ComponentePaiId = (material.Componente.ComponentePai == null ? new int?() : material.Componente.ComponentePai.Id),
                ComponentePaiNome = (material.Componente.ComponentePai == null ? null : material.Componente.ComponentePai.Nome),
                ComponenteUnidadePadraoSigla = material.Componente.UnidadePadrao.Sigla,
                FabricanteId = material.Fabricante.Id,
                FabricanteNome = material.Fabricante.Nome,
                FabricanteMarca = material.Fabricante.Marca,
                FabricanteSite = material.Fabricante.Site,
                Cor = material.Cor,
                Tamanho = material.Tamanho,
                UnidadeSigla = material.Unidade.Sigla,
            };

            return viewModel;
        }

        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {

        }

        public void EndEdit()
        {

        }
    }

    public class MateriaisBindingList : ExtendedBindingList<MaterialViewModel>
    {
        private readonly IConsultaDeMateriais consultaDeMateriais;

        private readonly ICadastroDeMateriais cadastroDeMateriais;

        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        public MateriaisBindingList()
            : base()
        {

        }

        public MateriaisBindingList(
            IConsultaDeMateriais consultaDeMateriais,
            ICadastroDeMateriais cadastroDeMateriais,
            IConsultaDeComponentes consultaDeComponentes,
            IConsultaDeFabricantes consultaDeFabricantes,
            IList<MaterialViewModel> list
        )
            : base(list)
        {
            this.consultaDeMateriais = consultaDeMateriais;

            this.cadastroDeMateriais = cadastroDeMateriais;

            this.consultaDeComponentes = consultaDeComponentes;

            this.consultaDeFabricantes = consultaDeFabricantes;


        }

        public MateriaisBindingList(IList<MaterialViewModel> list)
            : base(list)
        {

        }

        protected override void OnAddNew(MaterialViewModel item)
        {
            //item.BindingList = this;

            base.OnAddNew(item);
        }

        public override async Task SaveChanges()
        {
            var newItems = GetItemsBy(ObjectState.New);

            foreach (var newItem in newItems)
            {
                var solicitacaoDeCadastroDeMaterial = new SolicitacaoDeCadastroDeMaterial
                {
                    Id = newItem.Id,
                    Nome = newItem.Nome,
                    ComponenteId = newItem.ComponenteId,
                    FabricanteId = newItem.FabricanteId,
                };

                try
                {
                    var resposta = await cadastroDeMateriais.CadastraMaterial(solicitacaoDeCadastroDeMaterial);

                    SetStatus($"Novo material '{resposta.Id}' cadastrado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var modifiedItems = GetItemsBy(ObjectState.Modified);

            foreach (var modifiedItem in modifiedItems)
            {
                var solicitacaoDeCadastroDeMaterial = new SolicitacaoDeCadastroDeMaterial
                {
                    Id = modifiedItem.Id,
                    Nome = modifiedItem.Nome,
                    ComponenteId = modifiedItem.ComponenteId,
                    FabricanteId = modifiedItem.FabricanteId,
                };

                try
                {
                    var resposta = await cadastroDeMateriais.AtualizaMaterial(modifiedItem.Id, solicitacaoDeCadastroDeMaterial);

                    SetStatus($"Material '{resposta.Id}' atualizado com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }

            //

            var deletedItems = GetItemsBy(ObjectState.Deleted);

            foreach (var deletedItem in deletedItems)
            {
                try
                {
                    await cadastroDeMateriais.ExcluiMaterial(deletedItem.Id);

                    SetStatus($"Material '{deletedItem.Id}' excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }
    }

    public class MateriaisObservableCollection : ObservableCollection<MaterialViewModel>
    {
        public MateriaisObservableCollection(IList<MaterialViewModel> list)
            : base(list)
        {

        }
    }
}

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

        public static MaterialViewModel From(Material material)
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

    public class MateriaisObservableCollection : ObservableCollection<MaterialViewModel>
    {
        public MateriaisObservableCollection(IList<MaterialViewModel> list)
            : base(list)
        {

        }
    }
}

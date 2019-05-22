using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercial : IPlanoComercial
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public decimal ReceitaBrutaMensal { get; set; }

        public decimal CustoFixo { get; set; }

        public decimal CustoFixoPercentual { get; set; }

        public decimal CustoVariavel { get; set; }

        public decimal CustoPercentual { get; set; }

        public decimal Margem { get; set; }

        public decimal MargemPercentual { get; set; }

        public decimal TaxaDeMarcacao
        {
            get
            {
                return 100 / (100 - (CustoFixoPercentual + CustoVariavel + MargemPercentual));
            }
        }

        public virtual ICollection<CustoFixo> CustosFixos { get; set; }

        public virtual ICollection<CustoVariavel> CustosVariaveis { get; set; }

        public virtual ICollection<ItemDePlanoComercial> Itens { get; set; }

        public PlanoComercial(
            string id,
            string nome,
            decimal rendaBrutaMensal,
            decimal margem
        )
        {
            Id = id;

            Nome = nome;

            ReceitaBrutaMensal = rendaBrutaMensal;

            Margem = margem;

            CustosFixos = new HashSet<CustoFixo>();

            CustosVariaveis = new HashSet<CustoVariavel>();

            Itens = new HashSet<ItemDePlanoComercial>();
        }

        public void DefineNome(string nome)
        {
            Nome = nome;
        }

        public void DefineRendaBrutaMensal(decimal rendaBrutaMensal)
        {
            ReceitaBrutaMensal = rendaBrutaMensal;
        }

        public void DefineMargem(decimal margem)
        {
            Margem = margem;
        }

        public void DefineMargemPercentual(decimal margemPercentual)
        {
            MargemPercentual = margemPercentual;
        }

        #region IPlanoComercial

        ICusto[] IPlanoComercial.CustosFixos => CustosFixos.ToArray();

        ICusto[] IPlanoComercial.CustosVariaveis => CustosVariaveis.ToArray();

        IItemDePlanoComercial[] IPlanoComercial.Itens => Itens.ToArray();

        #endregion

        public PlanoComercial()
        {
            CustosFixos = new HashSet<CustoFixo>();

            CustosVariaveis = new HashSet<CustoVariavel>();

            Itens = new HashSet<ItemDePlanoComercial>();
        }
    }

    public class ItemDePlanoComercial : IItemDePlanoComercial
    {
        public int Id { get; set; }

        public virtual PlanoComercial PlanoComercial { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual CustoDeProducao CustoDeProducao { get; set; }

        public decimal PrecoDeVenda { get; set; }

        #region IItemDePlanoComercial

        IPlanoComercial IItemDePlanoComercial.PlanoComercial => PlanoComercial;

        IModelo IItemDePlanoComercial.Modelo => Modelo;

        ICustoDeProducao IItemDePlanoComercial.CustoDeProducao => CustoDeProducao;

        #endregion
    }

    public class CustoFixo : ICusto
    {
        public string Descricao { get; internal set; }

        public decimal Valor { get; internal set; }

        public decimal ValorPercentual { get; internal set; }
    }

    public class CustoVariavel : ICusto
    {
        public string Descricao { get; internal set; }

        public decimal Valor { get; internal set; }

        public decimal ValorPercentual { get; internal set; }
    }

    public class PrecoDePrateleiraDesejado //: IPrecoDePrateleiraDesejado
    {
        public decimal Valor { get; internal set; }
    }

    public class PrecoDeConsignacao //: IPrecoDeConsignacao
    {
        public decimal Valor { get; internal set; }
    }

    public interface IRepositorioDePlanosComerciais
    {
        Task<PlanoComercial> ObtemPlanoComercial(string id);

        Task Add(PlanoComercial planoComercial);

        Task Update(PlanoComercial planoComercial);

        Task Remove(PlanoComercial planoComercial);
    }
}

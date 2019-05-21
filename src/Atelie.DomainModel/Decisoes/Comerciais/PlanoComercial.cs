using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercial : IPlanoComercial
    {
        public string Id { get; internal set; }

        public string Nome { get; internal set; }

        public decimal ReceitaBrutaMensal { get; internal set; }

        public decimal CustoFixo { get; internal set; }

        public decimal CustoFixoPercentual { get; internal set; }

        public decimal CustoVariavel { get; internal set; }

        public decimal CustoPercentual { get; internal set; }

        public decimal Margem { get; internal set; }

        public decimal MargemPercentual { get; internal set; }

        public decimal TaxaDeMarcacao { get; internal set; }

        public virtual ICollection<CustoFixo> CustosFixos { get; internal set; }

        public virtual ICollection<CustoVariavel> CustosVariaveis { get; internal set; }

        public virtual ICollection<ItemDePlanoComercial> Itens { get; internal set; }

        public PlanoComercial(
            string id,
            string nome
        )
        {
            Id = id;

            Nome = nome;

            CustosFixos = new HashSet<CustoFixo>();

            CustosVariaveis = new HashSet<CustoVariavel>();

            Itens = new HashSet<ItemDePlanoComercial>();
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
        public int Id { get; internal set; }

        public virtual PlanoComercial PlanoComercial { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public virtual CustoDeProducao CustoDeProducao { get; internal set; }

        public decimal Margem { get; internal set; }

        public decimal MargemPercentual { get; internal set; }

        public decimal PrecoDeVenda { get; internal set; }

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

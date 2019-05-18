using Atelie.Comum.Comercial;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class DisponibilidadeDeMeioDePagamento : IDisponibilidadeDeMeioDePagamento
    {
        public virtual Fornecedor Fornecedor { get; internal set; }

        public virtual MeioDePagamento MeioDePagamento { get; internal set; }

        IFornecedor IDisponibilidadeDeMeioDePagamento.Fornecedor => Fornecedor;

        IMeioDePagamento IDisponibilidadeDeMeioDePagamento.MeioDePagamento => MeioDePagamento;

        public int FornecedorId { get; internal set; }

        public int MeioDePagamentoId { get; internal set; }
    }
}

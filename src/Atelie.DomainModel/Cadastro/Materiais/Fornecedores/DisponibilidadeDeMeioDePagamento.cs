using Atelie.Comum.Comercial;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class DisponibilidadeDeMeioDePagamento
    {
        public virtual Fornecedor Fornecedor { get; internal set; }

        public virtual MeioDePagamento MeioDePagamento { get; internal set; }

        public int FornecedorId { get; internal set; }

        public int MeioDePagamentoId { get; internal set; }
    }
}

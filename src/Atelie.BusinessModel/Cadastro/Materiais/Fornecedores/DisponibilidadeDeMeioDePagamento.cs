using Atelie.Comum.Comercial;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public interface IDisponibilidadeDeMeioDePagamento
    {
        IFornecedor Fornecedor { get; }

        IMeioDePagamento MeioDePagamento { get; }
    }
}

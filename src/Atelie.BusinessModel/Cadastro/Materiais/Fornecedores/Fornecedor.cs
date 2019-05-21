using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public interface IFornecedor : IPessoaJuridica
    {
        IDisponibilidadeDeMeioDePagamento[] MeiosDePagamento { get; }

        //IFornecimentoDeMaterial[] MateriaisFornecidos { get; }
    }
}

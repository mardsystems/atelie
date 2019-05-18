using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Materiais.Fornecedores;
using Atelie.Comum;
using System;

namespace Atelie.Operacoes.Compra
{
    public interface ICotacao
    {
        int Id { get; }

        DateTime Data { get; }

        IFornecedor Fornecedor { get; }

        IMaterial Material { get; }

        ICorDeFabricante Cor { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        IUnidade Unidade { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        double Quantidade { get; }

        decimal Valor { get; }
    }
}

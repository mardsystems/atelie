using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;
using Atelie.Comum;

namespace Atelie.Cadastro.Modelos.Producao
{
    public interface INecessidadeDeMaterial
    {
        IModelo Modelo { get; }

        ITamanhoDeModelo TamanhoDeModelo { get; }

        IMaterial Material { get; }

        ICorDeFabricante Cor { get; }

        /// <summary>
        /// Tamanho do material utilizado.
        /// </summary>
        ITamanho TamanhoDeMaterial { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        IUnidade Unidade { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        double Quantidade { get; }

        double CustoPadrao { get; }
    }
}

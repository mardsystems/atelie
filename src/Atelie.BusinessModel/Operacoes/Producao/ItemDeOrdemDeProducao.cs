using Atelie.Cadastro.Modelos;

namespace Atelie.Operacoes.Producao
{
    public interface IItemDeOrdemDeProducao
    {
        IOrdemDeProducao Ordem { get; }

        ITamanhoDeModelo Tamanho { get; }

        int Quantidade { get; }

        int QuantidadeProduzida { get; }

        IAlocacaoDeMaterial[] MateriaisAlocados { get; }

        IAlocacaoDeRecurso[] RecursosAlocados { get; }
    }
}

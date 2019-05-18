using Atelie.Cadastro.Modelos;
using System;

namespace Atelie.Operacoes.Producao
{
    public interface IOrdemDeProducao
    {
        int Id { get; }

        IModelo Modelo { get; }

        StatusDeOrdemDeProducao Status { get; }

        DateTime Data { get; }

        string NumeroDeLote { get; }

        IItemDeOrdemDeProducao[] Itens { get; }
    }
}

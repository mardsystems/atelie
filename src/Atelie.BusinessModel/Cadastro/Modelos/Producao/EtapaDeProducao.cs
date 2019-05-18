using Atelie.Cadastro.Modelos.Producao.Ferramentas;
using System;

namespace Atelie.Cadastro.Modelos.Producao
{
    public interface IEtapaDeProducao
    {
        [Obsolete]
        int Id { get; }

        int Ordem { get; }

        string Descricao { get; }

        INecessidadeDeTipoDeRecurso[] TiposDeRecursoNecessarios { get; }

        INecessidadeDeFerramentaDeProducao[] FerramentasNecessarias { get; }
    }
}

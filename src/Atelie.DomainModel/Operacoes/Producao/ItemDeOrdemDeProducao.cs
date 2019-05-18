using Atelie.Cadastro.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Operacoes.Producao
{
    public class ItemDeOrdemDeProducao : IItemDeOrdemDeProducao
    {
        public virtual OrdemDeProducao Ordem { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public virtual TamanhoDeModelo Tamanho { get; internal set; }

        public int Quantidade { get; internal set; }

        public int QuantidadeProduzida { get; internal set; }

        public virtual ICollection<AlocacaoDeMaterial> MateriaisAlocados { get; internal set; }

        public virtual ICollection<AlocacaoDeRecurso> RecursosAlocados { get; internal set; }

        IOrdemDeProducao IItemDeOrdemDeProducao.Ordem => throw new System.NotImplementedException();

        ITamanhoDeModelo IItemDeOrdemDeProducao.Tamanho => throw new System.NotImplementedException();

        IAlocacaoDeMaterial[] IItemDeOrdemDeProducao.MateriaisAlocados => MateriaisAlocados.ToArray();

        IAlocacaoDeRecurso[] IItemDeOrdemDeProducao.RecursosAlocados => RecursosAlocados.ToArray();

        public ItemDeOrdemDeProducao()
        {
            MateriaisAlocados = new HashSet<AlocacaoDeMaterial>();

            RecursosAlocados = new HashSet<AlocacaoDeRecurso>();
        }

        public ItemDeOrdemDeProducao(Modelo modelo, TamanhoDeModelo tamanho, int quantidade)
        {
            Modelo = modelo;

            Tamanho = tamanho;

            Quantidade = quantidade;
        }
    }
}
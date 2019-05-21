using Atelie.Comum;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class Fornecedor : PessoaJuridica, IFornecedor
    {
        public string Site { get; internal set; }

        public virtual IEnumerable<DisponibilidadeDeMeioDePagamento> MeiosDePagamento { get; internal set; }

        //public virtual IEnumerable<FornecimentoDeMaterial> MateriaisFornecidos { get; internal set; }

        IDisponibilidadeDeMeioDePagamento[] IFornecedor.MeiosDePagamento => MeiosDePagamento.ToArray();

        //IFornecimentoDeMaterial[] IFornecedor.MateriaisFornecidos => MateriaisFornecidos.ToArray();

        public Fornecedor()
        {
            MeiosDePagamento = new HashSet<DisponibilidadeDeMeioDePagamento>();

            //MateriaisFornecidos = new HashSet<FornecimentoDeMaterial>();
        }
    }
}

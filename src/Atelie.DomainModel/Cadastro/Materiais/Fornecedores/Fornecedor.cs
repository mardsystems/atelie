using Atelie.Comum;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class Fornecedor : PessoaJuridica
    {
        public string Site { get; internal set; }

        public virtual IEnumerable<DisponibilidadeDeMeioDePagamento> MeiosDePagamento { get; internal set; }

        //public virtual IEnumerable<FornecimentoDeMaterial> MateriaisFornecidos { get; internal set; }

        public Fornecedor()
        {
            MeiosDePagamento = new HashSet<DisponibilidadeDeMeioDePagamento>();

            //MateriaisFornecidos = new HashSet<FornecimentoDeMaterial>();
        }
    }
}

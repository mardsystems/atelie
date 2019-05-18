using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class FornecedorDTO : IFornecedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        //public IInformacoesBancarias InformacoesBancarias { get; set; }

        public IDisponibilidadeDeMeioDePagamento[] MeiosDePagamento { get; set; }

        public IFornecimentoDeMaterial[] MateriaisFornecidos { get; set; }

        public string CNPJ { get; set; }

        //public IEndereco Endereco { get; set; }

        public IContatoDeTelefone[] ContatosDeTelefone { get; set; }

        public IContatoDeEmail[] ContatosDeEmail { get; set; }
    }
}

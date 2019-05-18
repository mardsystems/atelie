namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class DisponibilidadeDeEmbalagemDTO : IDisponibilidadeDeEmbalagem
    {
        public CatalogoDTO Catalogo { get; set; }

        public EmbalagemDTO Embalagem { get; set; }

        public string EmbalagemNome { get; set; }

        ICatalogo IDisponibilidadeDeEmbalagem.Catalogo => Catalogo;

        IEmbalagem IDisponibilidadeDeEmbalagem.Embalagem => Embalagem;
    }
}

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class DisponibilidadeDeEmbalagem : IDisponibilidadeDeEmbalagem
    {
        public virtual Catalogo Catalogo { get; internal set; }

        public virtual Embalagem Embalagem { get; internal set; }

        ICatalogo IDisponibilidadeDeEmbalagem.Catalogo => Catalogo;

        IEmbalagem IDisponibilidadeDeEmbalagem.Embalagem => Embalagem;

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        public string CatalogoNome { get; internal set; }

        public string EmbalagemNome { get; internal set; }
    }
}

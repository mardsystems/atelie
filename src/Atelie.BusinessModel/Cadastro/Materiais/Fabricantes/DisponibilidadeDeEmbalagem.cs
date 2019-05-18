namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface IDisponibilidadeDeEmbalagem
    {
        ICatalogo Catalogo { get; }

        string EmbalagemNome { get; }

        IEmbalagem Embalagem { get; }        
    }
}

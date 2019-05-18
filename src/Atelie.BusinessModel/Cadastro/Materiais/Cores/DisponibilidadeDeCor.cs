namespace Atelie.Cadastro.Materiais.Cores
{
    public interface IDisponibilidadeDeCor
    {
        IMaterial Material { get; }

        ICorDeMaterial Cor { get; }

        decimal? CustoPadrao { get; }
    }
}

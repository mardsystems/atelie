namespace Atelie.Cadastro.Materiais.Cores
{
    public interface ICartelaDeCores
    {
        IMaterial Material { get; }

        /// <summary>
        /// Ex.: Padrão.
        /// </summary>
        string Nome { get; }

        ICorDeMaterial[] Cores { get; }
    }
}

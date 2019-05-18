namespace Atelie.Cadastro.Modelos
{
    public class TamanhoDeModelo : ITamanhoDeModelo
    {
        public string Sigla { get; internal set; }

        public string Nome { get; internal set; }

        public int Posicao { get; internal set; }

        public TamanhoDeModelo(string sigla)
        {
            Sigla = sigla;
        }
    }
}

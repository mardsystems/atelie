using System;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public interface IConsultaDeComponentes
    {
        IObservable<IComponente[]> ObtemObservavelDeComponentes();
    }
}

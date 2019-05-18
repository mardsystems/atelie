using System;

namespace Atelie.Comum
{
    public interface ConsultaDeUnidades<TUnidade> where TUnidade : IUnidade
    {
        IObservable<TUnidade[]> ObtemObservavelDeUnidades();
    }
}

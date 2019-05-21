using System;

namespace Atelie.Decisoes.Comerciais
{
    public interface IConsultaDePlanosComerciais
    {
        IObservable<IPlanoComercial[]> ObtemObservavelDePlanosComerciais();
    }
}

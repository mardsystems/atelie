using System;

namespace Atelie.Cadastro.Materiais
{
    public interface IConsultaDeMateriais
    {
        IObservable<IMaterial[]> ObtemObservavelDeMateriais();
    }
}

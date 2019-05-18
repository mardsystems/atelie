using System;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface IConsultaDeFabricantes
    {
        IObservable<IFabricante[]> ObtemObservavelDeFabricantes();
    }
}

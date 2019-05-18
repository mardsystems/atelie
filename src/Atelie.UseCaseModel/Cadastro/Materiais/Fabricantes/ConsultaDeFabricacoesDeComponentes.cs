using System;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface IConsultaDeFabricacoesDeComponentes
    {
        IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentes();

        IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorFabricante(int fabricanteId);

        IObservable<IFabricacaoDeComponente[]> ObtemObservavelDeFabricacoesDeComponentesPorComponente(int componenteId);
    }
}

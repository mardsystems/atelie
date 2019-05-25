using Atelie.Cadastro.Materiais.Fabricantes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponenteViewModel : ObservableObject, INotifyPropertyChanged //, IEditableObject
    {
        public int Id { get; set; }

        string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        public int? ComponentePaiId { get; set; }

        public string ComponentePaiNome { get; set; }

        public string UnidadePadraoSigla { get; set; }

        public BindingList<FabricanteViewModel> Fabricantes { get; set; }

        public static ComponenteViewModel From(Componente componente)
        {
            var viewModel = new ComponenteViewModel
            {
                Id = componente.Id,
                Nome = componente.Nome,
                ComponentePaiId = (componente.ComponentePai == null ? new int?() : componente.ComponentePai.Id),
                ComponentePaiNome = (componente.ComponentePai == null ? null : componente.ComponentePai.Nome),
                UnidadePadraoSigla = componente.UnidadePadrao.Sigla,
            };

            return viewModel;
        }

        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {

        }

        public void EndEdit()
        {

        }
    }

    public class ComponentesObservableCollection : ObservableCollection<ComponenteViewModel>
    {
        public ComponentesObservableCollection(IList<ComponenteViewModel> list)
            : base(list)
        {

        }
    }

    //public static class ExtensaoDeComponentes
    //{
    //    public static IObservable<ComponentesObservableCollection> ParaDropdown(this IConsultaDeComponentes consultaDeComponentes)
    //    {
    //        var observable = consultaDeComponentes.ObtemObservavelDeComponentes()
    //            .Select(componentes =>
    //            {
    //                var list = componentes.Select(p => ComponenteViewModel.From(p)).ToList();

    //                list.Add(new ComponenteViewModel { Id = 0, Nome = "Selecione" });

    //                var observableCollection = new ComponentesObservableCollection(list);

    //                return Observable.Return(observableCollection);
    //            })
    //            .Switch();

    //        return observable;
    //    }
    //}
}

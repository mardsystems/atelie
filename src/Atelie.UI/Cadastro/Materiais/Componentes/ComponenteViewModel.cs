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

        public static ComponenteViewModel From(IComponente componente)
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

    public class ComponentesBindingList : ExtendedBindingList<ComponenteViewModel>
    {
        public ComponentesBindingList(IList<ComponenteViewModel> list)
            : base(list)
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

    public static class ExtensaoDeComponentes
    {
        public static IObservable<ComponentesBindingList> ParaDropdown(this IConsultaDeComponentes consultaDeComponentes)
        {
            var observable = consultaDeComponentes.ObtemObservavelDeComponentes()
                .Select(componentes =>
                {
                    var list = componentes.Select(p => ComponenteViewModel.From(p)).ToList();

                    list.Add(new ComponenteViewModel { Id = 0, Nome = "Selecione" });

                    var bindingList = new ComponentesBindingList(list);

                    return Observable.Return(bindingList);
                })
                .Switch();

            return observable;
        }
    }
}

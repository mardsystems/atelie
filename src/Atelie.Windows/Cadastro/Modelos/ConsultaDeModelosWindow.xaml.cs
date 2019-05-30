﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atelie.Cadastro.Modelos
{
    /// <summary>
    /// Interaction logic for ConsultaDeModelosWindow.xaml
    /// </summary>
    public partial class ConsultaDeModelosWindow : Window
    {
        private readonly ModelosLocalService modelosLocalService;

        public ConsultaDeModelosWindow(
            ModelosLocalService modelosLocalService
        )
        {
            this.modelosLocalService = modelosLocalService;

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var modelos = await modelosLocalService.ObtemObservavelDeModelos();

            var list = modelos.Select(p => ItemDeConsultaDeModeloViewModel.From(p, selecteds)).ToList();

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = list;
        }

        private IEnumerable<ModeloViewModel> selecteds;

        public void SetSelecteds(IEnumerable<ModeloViewModel> selecteds)
        {
            this.selecteds = selecteds;
        }

        public IEnumerable<ModeloViewModel> GetSelecteds()
        {
            var list = new List<ModeloViewModel>();

            foreach (var item in modelosDataGrid.Items)
            {
                var viewModel = item as ItemDeConsultaDeModeloViewModel;

                if (viewModel.Selected)
                {
                    list.Add(viewModel.Modelo);
                }                
            }

            return list;
        }
    }

    public class ItemDeConsultaDeModeloViewModel
    {
        public bool Selected { get; set; }

        public ModeloViewModel Modelo { get; set; }

        public static ItemDeConsultaDeModeloViewModel From(Modelo modelo, IEnumerable<ModeloViewModel> selecteds)
        {
            var selected = selecteds.Any(p => p.Codigo == modelo.Codigo);

            var modeloViewModel = ModeloViewModel.From(modelo);

            var viewModel = new ItemDeConsultaDeModeloViewModel
            {
                Selected = selected,
                Modelo = modeloViewModel,
            };

            return viewModel;
        }
    }
}

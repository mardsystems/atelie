﻿using System.Linq;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;


namespace Atelie
{
    public sealed partial class NewControlsPage : ItemsPageBase
    {
        public NewControlsPage()
        {
            this.InitializeComponent();
        }

        private IEnumerable<ControlInfoDataItem> _updateditems;

        public IEnumerable<ControlInfoDataItem> UpdatedItems
        {
            get { return _updateditems; }
            set { SetProperty(ref _updateditems, value); }
        }

        private IEnumerable<ControlInfoDataItem> _previewitems;

        public IEnumerable<ControlInfoDataItem> PreviewItems
        {
            get { return _previewitems; }
            set { SetProperty(ref _previewitems, value); }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var menuItem = MainPage.Current.NavigationView.MenuItems.Cast<Microsoft.UI.Xaml.Controls.NavigationViewItem>().First();
            menuItem.IsSelected = true;
            MainPage.Current.NavigationView.Header = menuItem.Content;
            Items = ControlInfoDataSource.Instance.Groups.SelectMany(g => g.Items.Where(i => i.IsNew)).OrderBy(i => i.Title).ToList();
            UpdatedItems = ControlInfoDataSource.Instance.Groups.SelectMany(g => g.Items.Where(i => i.IsUpdated)).OrderBy(i => i.Title).ToList();
            PreviewItems = ControlInfoDataSource.Instance.Groups.SelectMany(g => g.Items.Where(i => i.IsPreview)).OrderBy(i => i.Title).ToList();
        }

        protected override bool GetIsNarrowLayoutState()
        {
            return LayoutVisualStates.CurrentState == NarrowLayout;
        }
    }
}
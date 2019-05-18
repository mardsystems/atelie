using System.Linq;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Atelie
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class AllControlsPage : ItemsPageBase
    {
        public AllControlsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var menuItem = MainPage.Current.NavigationView.MenuItems.Cast<Microsoft.UI.Xaml.Controls.NavigationViewItem>().ElementAt(1);
            menuItem.IsSelected = true;
            MainPage.Current.NavigationView.Header = menuItem.Content;
            Items = ControlInfoDataSource.Instance.Groups.SelectMany(g => g.Items).OrderBy(i => i.Title).ToList();
        }

        protected override bool GetIsNarrowLayoutState()
        {
            return LayoutVisualStates.CurrentState == NarrowLayout;
        }
    }
}
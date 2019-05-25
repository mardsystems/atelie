﻿using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.Devices.Input;
using Windows.Gaming.Input;
using Windows.System;
using Windows.System.Profile;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Atelie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly Container container;

        public static MainPage Current;
        public static Frame RootFrame = null;

        public VirtualKey ArrowKey;

        private RootFrameNavigationHelper _navHelper;
        private PageHeader _header;
        private bool _isGamePadConnected;
        private bool _isKeyboardConnected;
        private Microsoft.UI.Xaml.Controls.NavigationViewItem _allControlsMenuItem;
        private Microsoft.UI.Xaml.Controls.NavigationViewItem _newControlsMenuItem;
        private Microsoft.UI.Xaml.Controls.NavigationViewItem _cadastroDeFabricantesMenuItem;

        public Microsoft.UI.Xaml.Controls.NavigationView NavigationView
        {
            get { return NavigationViewControl; }
        }

        public DeviceType DeviceFamily { get; set; }

        public bool IsFocusSupported
        {
            get
            {
                return DeviceFamily == DeviceType.Xbox || _isGamePadConnected || _isKeyboardConnected;
            }
        }

        public PageHeader PageHeader
        {
            get
            {
                return _header ?? (_header = UIHelper.GetDescendantsOfType<PageHeader>(NavigationViewControl).FirstOrDefault());
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            var package = new InfrastructurePackage();

            container = new Container();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            container.RegisterPackages(assemblies);

            _navHelper = new RootFrameNavigationHelper(rootFrame, NavigationViewControl);

            SetDeviceFamily();
            AddNavigationMenuItems();
            Current = this;
            RootFrame = rootFrame;

            this.GotFocus += (object sender, RoutedEventArgs e) =>
            {
                // helpful for debugging focus problems w/ keyboard & gamepad
                if (FocusManager.GetFocusedElement() is FrameworkElement focus)
                {
                    Debug.WriteLine("got focus: " + focus.Name + " (" + focus.GetType().ToString() + ")");
                }
            };

            Gamepad.GamepadAdded += OnGamepadAdded;
            Gamepad.GamepadRemoved += OnGamepadRemoved;

            Window.Current.SetTitleBar(AppTitleBar);

            CoreApplication.GetCurrentView().TitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle(s);

            _isKeyboardConnected = Convert.ToBoolean(new KeyboardCapabilities().KeyboardPresent);
        }

        private void CadastroDeFabricantesButton_Click(object sender, RoutedEventArgs e)
        {
            //var cadastroDeFabricantes = container.GetInstance<ICadastroDeFabricantes>();

            //var consultaDeComponentes = container.GetInstance<IConsultaDeComponentes>();

            //var consultaDeFabricantes = container.GetInstance<IConsultaDeFabricantes>();

            //var fabricantesPage = new FabricantesPage(
            //    cadastroDeFabricantes,
            //    consultaDeComponentes,
            //    consultaDeFabricantes
            //);

            var parameter = new FabricantesPageParameter
            {
                //CadastroDeFabricantes = cadastroDeFabricantes,
                //ConsultaDeComponentes = consultaDeComponentes,
                //ConsultaDeFabricantes = consultaDeFabricantes,
            };

            this.Frame.Navigate(typeof(FabricantesPage), parameter);
        }

        void UpdateAppTitle(CoreApplicationViewTitleBar coreTitleBar)
        {
            var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
            var left = 12 + (full ? 0 : coreTitleBar.SystemOverlayLeftInset);
            AppTitle.Margin = new Thickness(left, 8, 0, 0);
            AppTitleBar.Height = coreTitleBar.Height;
        }

        public bool CheckNewControlSelected()
        {
            return _newControlsMenuItem.IsSelected;
        }

        private void AddNavigationMenuItems()
        {
            foreach (var group in ControlInfoDataSource.Instance.Groups.OrderBy(i => i.Title))
            {
                var item = new Microsoft.UI.Xaml.Controls.NavigationViewItem() { Content = group.Title, Tag = group.UniqueId, DataContext = group };
                AutomationProperties.SetName(item, group.Title);
                if (group.ImagePath.ToLowerInvariant().EndsWith(".png"))
                {
                    item.Icon = new BitmapIcon() { UriSource = new Uri(group.ImagePath, UriKind.RelativeOrAbsolute) };
                }
                else
                {
                    item.Icon = new FontIcon()
                    {
                        FontFamily = new FontFamily("Segoe MDL2 Assets"),
                        Glyph = group.ImagePath
                    };
                }
                NavigationViewControl.MenuItems.Add(item);

                if (group.UniqueId == "AllControls")
                {
                    this._allControlsMenuItem = item;
                }
                else if (group.UniqueId == "NewControls")
                {
                    this._newControlsMenuItem = item;
                }
                else if (group.UniqueId == "CadastroDeFabricantes")
                {
                    this._cadastroDeFabricantesMenuItem = item;
                }
            }

            // Move "What's New" and "All Controls" to the top of the NavigationView
            NavigationViewControl.MenuItems.Remove(_allControlsMenuItem);
            NavigationViewControl.MenuItems.Remove(_newControlsMenuItem);
            NavigationViewControl.MenuItems.Remove(_cadastroDeFabricantesMenuItem);
            NavigationViewControl.MenuItems.Insert(0, _allControlsMenuItem);
            NavigationViewControl.MenuItems.Insert(0, _newControlsMenuItem);
            NavigationViewControl.MenuItems.Insert(0, _cadastroDeFabricantesMenuItem);

            // Separate the All/New items from the rest of the categories.
            NavigationViewControl.MenuItems.Insert(2, new Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator());

            //_newControlsMenuItem.Loaded += OnNewControlsMenuItemLoaded;
        }

        private void SetDeviceFamily()
        {
            var familyName = AnalyticsInfo.VersionInfo.DeviceFamily;

            if (!Enum.TryParse(familyName.Replace("Windows.", string.Empty), out DeviceType parsedDeviceType))
            {
                parsedDeviceType = DeviceType.Other;
            }

            DeviceFamily = parsedDeviceType;
        }

        private void OnNewControlsMenuItemLoaded(object sender, RoutedEventArgs e)
        {
            if (IsFocusSupported)
            {
                _newControlsMenuItem.Focus(FocusState.Keyboard);
            }
            _newControlsMenuItem.IsSelected = true;
        }

        private void OnGamepadRemoved(object sender, Gamepad e)
        {
            _isGamePadConnected = Gamepad.Gamepads.Any();
        }

        private void OnGamepadAdded(object sender, Gamepad e)
        {
            _isGamePadConnected = Gamepad.Gamepads.Any();
        }

        private void OnNavigationViewItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            // Close any open teaching tips before navigation
            CloseTeachingTips();

            if (args.IsSettingsInvoked)
            {
                //rootFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                var invokedItem = args.InvokedItemContainer;

                if (invokedItem == _allControlsMenuItem)
                {
                    rootFrame.Navigate(typeof(AllControlsPage));
                }
                else if (invokedItem == _newControlsMenuItem)
                {
                    rootFrame.Navigate(typeof(NewControlsPage));
                }
                else if (invokedItem == _cadastroDeFabricantesMenuItem)
                {
                    //var cadastroDeFabricantes = container.GetInstance<ICadastroDeFabricantes>();

                    //var consultaDeComponentes = container.GetInstance<IConsultaDeComponentes>();

                    //var consultaDeFabricantes = container.GetInstance<IConsultaDeFabricantes>();

                    //var fabricantesPage = new FabricantesPage(
                    //    cadastroDeFabricantes,
                    //    consultaDeComponentes,
                    //    consultaDeFabricantes
                    //);

                    var parameter = new FabricantesPageParameter
                    {
                        //CadastroDeFabricantes = cadastroDeFabricantes,
                        //ConsultaDeComponentes = consultaDeComponentes,
                        //ConsultaDeFabricantes = consultaDeFabricantes,
                    };

                    //this.Frame.Navigate(typeof(FabricantesPage), parameter);

                    rootFrame.Navigate(typeof(FabricantesPage), parameter);
                }
                else
                {
                    var itemId = ((ControlInfoDataGroup)invokedItem.DataContext).UniqueId;
                    //rootFrame.Navigate(typeof(SectionPage), itemId);
                }
            }
        }

        private void OnRootFrameNavigated(object sender, NavigationEventArgs e)
        {
            // Close any open teaching tips before navigation
            CloseTeachingTips();

            if (e.SourcePageType == typeof(AllControlsPage)
                || e.SourcePageType == typeof(NewControlsPage))
            {
                NavigationViewControl.AlwaysShowHeader = false;
            }
            else
            {
                //NavigationViewControl.AlwaysShowHeader = true;

                bool isFilteredPage = false;
                //bool isFilteredPage = e.SourcePageType == typeof(SectionPage) || e.SourcePageType == typeof(SearchResultsPage);
                PageHeader?.UpdateBackground(isFilteredPage);
            }
        }

        private void CloseTeachingTips()
        {
            if (Current?.PageHeader != null)
            {
                Current.PageHeader.TeachingTip1.IsOpen = false;
                Current.PageHeader.TeachingTip3.IsOpen = false;
            }
        }

        private void OnControlsSearchBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = new List<ControlInfoDataItem>();

                foreach (var group in ControlInfoDataSource.Instance.Groups)
                {
                    var matchingItems = group.Items.Where(
                        item => item.Title.IndexOf(sender.Text, StringComparison.CurrentCultureIgnoreCase) >= 0);

                    foreach (var item in matchingItems)
                    {
                        suggestions.Add(item);
                    }
                }
                if (suggestions.Count > 0)
                {
                    controlsSearchBox.ItemsSource = suggestions.OrderByDescending(i => i.Title.StartsWith(sender.Text, StringComparison.CurrentCultureIgnoreCase)).ThenBy(i => i.Title);
                }
                else
                {
                    controlsSearchBox.ItemsSource = new string[] { "No results found" };
                }
            }
        }

        private void OnControlsSearchBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //if (args.ChosenSuggestion != null && args.ChosenSuggestion is ControlInfoDataItem)
            //{
            //    var itemId = (args.ChosenSuggestion as ControlInfoDataItem).UniqueId;
            //    MainPage.RootFrame.Navigate(typeof(ItemPage), itemId);
            //}
            //else if (!string.IsNullOrEmpty(args.QueryText))
            //{
            //    MainPage.RootFrame.Navigate(typeof(SearchResultsPage), args.QueryText);
            //}
        }

        private void NavigationViewControl_PaneClosing(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewPaneClosingEventArgs args)
        {
            AppTitle.Visibility = Visibility.Collapsed;
        }

        private void NavigationViewControl_PaneOpened(Microsoft.UI.Xaml.Controls.NavigationView sender, object args)
        {
            AppTitle.Visibility = Visibility.Visible;
            if (sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Expanded)
            {
                AppTitleBar.Margin = new Thickness(40, 0, 0, 0);
            }
            else
            {
                AppTitleBar.Margin = new Thickness();
            }
        }
    }


    public enum DeviceType
    {
        Desktop,
        Mobile,
        Other,
        Xbox
    }
}

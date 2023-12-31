﻿using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.UI.Xaml;

namespace XamlBrewer.WinUI3.LiveCharts2.Sample
{
    public sealed partial class Shell : Window
    {
        public Shell()
        {
            Title = "XAML Brewer WinUI 3 LiveCharts 2 Sample";

            InitializeComponent();

            AppWindow.SetIcon("Assets/Beer.ico");

            (Application.Current as App).EnsureSettings();
            ApplyTheme();
        }

        internal FrameworkElement AppRoot => Root;

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = (Application.Current as App).Settings;
            settings.IsLightTheme = !settings.IsLightTheme;
            (Application.Current as App).SaveSettings();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var settings = (Application.Current as App).Settings;
            Root.RequestedTheme = settings.IsLightTheme ? ElementTheme.Light : ElementTheme.Dark;
        }

        private void Root_ActualThemeChanged(FrameworkElement sender, object args)
        {
            // Theme change refinements (e.g. content dialogs and title bar).
            if ((Application.Current as App).Settings.IsLightTheme)
            {
                LiveCharts.Configure(config => config.AddLightTheme());
            }
            else
            {
                LiveCharts.Configure(config => config.AddDarkTheme());
            }
        }
    }
}

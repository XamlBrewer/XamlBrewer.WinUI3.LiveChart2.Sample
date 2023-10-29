using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System.Collections.Generic;
using XamlBrewer.WinUI3.LiveCharts2.Sample.ViewModels;

namespace XamlBrewer.WinUI3.LiveCharts2.Sample.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private HelloWorldViewModel ViewModel => DataContext as HelloWorldViewModel;

        private void Chart_ActualThemeChanged(FrameworkElement sender, object args)
        {
            if ((Application.Current as App).Settings.IsLightTheme)
            {
                LiveCharts.Configure(config => config.AddLightTheme());
            }
            else
            {
                LiveCharts.Configure(config => config.AddDarkTheme());
            }

            // Invalidate chart.
            Chart.Series = new List<ISeries>();
            Chart.SetBinding(CartesianChart.SeriesProperty, new Binding { Source = ViewModel.Series });
        }
    }
}

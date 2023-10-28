using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace XamlBrewer.WinUI3.LiveCharts2.Sample.ViewModels
{
    public class HelloWorldViewModel
    {
        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
            };
    }
}

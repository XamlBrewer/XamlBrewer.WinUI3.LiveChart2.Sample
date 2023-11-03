using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace XamlBrewer.WinUI3.LiveCharts2.Sample.ViewModels
{
    public class FunctionsViewModel
    {
        public FunctionsViewModel()
        {
            static double batFunction1(double x) => 2 * Math.Sqrt(-Math.Abs(Math.Abs(x) - 1) * Math.Abs(3 - Math.Abs(x)) / ((Math.Abs(x) - 1) * (3 - Math.Abs(x)))) * (1 + Math.Abs(Math.Abs(x) - 3) / (Math.Abs(x) - 3)) * Math.Sqrt(1 - Math.Pow((x / 7), 2)) + (5 + 0.97 * (Math.Abs(x - 0.5) + Math.Abs(x + 0.5)) - 3 * (Math.Abs(x - 0.75) + Math.Abs(x + 0.75))) * (1 + Math.Abs(1 - Math.Abs(x)) / (1 - Math.Abs(x)));
            static double batFunction2(double x) => -3 * Math.Sqrt(1 - Math.Pow((x / 7), 2)) * Math.Sqrt(Math.Abs(Math.Abs(x) - 4) / (Math.Abs(x) - 4));
            static double batFunction3(double x) => Math.Abs(x / 2) - 0.0913722 * (Math.Pow(x, 2)) - 3 + Math.Sqrt(1 - Math.Pow((Math.Abs(Math.Abs(x) - 2) - 1), 2));
            static double batFunction4(double x) => (2.71052 + (1.5 - .5 * Math.Abs(x)) - 1.35526 * Math.Sqrt(4 - Math.Pow((Math.Abs(x) - 1), 2))) * Math.Sqrt(Math.Abs(Math.Abs(x) - 1) / (Math.Abs(x) - 1)) + 0.9;

            Series = new ISeries[]
            {
            new LineSeries<ObservablePoint>
                {
                    Values =  FunctionValues(batFunction1, -7, +7, .01),
                    GeometrySize = 0,
                    Fill = null,
                    Name = "na na"
                },
            new LineSeries<ObservablePoint>
                {
                    Values =  FunctionValues(batFunction2, -7, +7, .01),
                    GeometrySize = 0,
                    Fill = null,
                    Name = "na na"
                },
            new LineSeries<ObservablePoint>
                {
                    Values =  FunctionValues(batFunction3, -7, +7, .01),
                    GeometrySize = 0,
                    Fill = null,
                    Name = "na na"
                },
           new LineSeries<ObservablePoint>
                {
                    Values =  FunctionValues(batFunction4, -7, +7, .01),
                    GeometrySize = 0,
                    Fill = null,
                    Name = "na na"
                }
            };
        }

        public static SolidColorPaint LegendTextPaint => new(SKColors.Gray);
        
        public ISeries[] Series { get; set; }

        private static IEnumerable<ObservablePoint> FunctionValues(Func<double, double> function, double x0, double x1, double dx)
        {
            for (double x = x0; x < x1; x += dx)
            {
                var y = function(x);
                yield return(new ObservablePoint(x, double.IsNaN(y) ? null : y));
            }
        }
    }
}

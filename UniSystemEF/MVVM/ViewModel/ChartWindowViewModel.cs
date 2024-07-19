using OxyPlot;
using OxyPlot.Series;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.MVVM.ViewModel
{
    public class ChartWindowViewModel
    {
        public PlotModel PlotModel { get; private set; }

        public ChartWindowViewModel(List<Group> groups, Group selectedGroup)
        {
            PlotModel = new PlotModel { Title = "Group Average Scores" };

            // Обчислення середнього арифметичного балів усіх груп
            var averageScore = groups.Average(g => g.GroupAverage);

            var series = new LineSeries
            {
                Title = "Group Averages",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4
            };

            foreach (var group in groups)
            {
                series.Points.Add(new DataPoint(group.GroupId, group.GroupAverage));
            }

            PlotModel.Series.Add(series);

            // Додаємо середній бал усіх груп як додаткову серію
            var averageSeries = new LineSeries
            {
                Title = "Average Score of All Groups",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.None
            };

            // Додаємо лише один пункт для середнього балу
            averageSeries.Points.Add(new DataPoint(0, averageScore)); // Пункт на осі X = 0, Y = середній бал

            PlotModel.Series.Add(averageSeries);

            // Додаємо точку для вибраної групи
            var selectedGroupSeries = new LineSeries
            {
                Title = "Selected Group Average Score",
                Color = OxyColors.Red,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4
            };

            selectedGroupSeries.Points.Add(new DataPoint(selectedGroup.GroupId, selectedGroup.GroupAverage));
            PlotModel.Series.Add(selectedGroupSeries);

            PlotModel.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Key = "GroupAxis",
                ItemsSource = groups.Select(g => g.GroupName).ToList()
            });

            PlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Minimum = 0,
                Title = "Average Score"
            });
        }
    }
}

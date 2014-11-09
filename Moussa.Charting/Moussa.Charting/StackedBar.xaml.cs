using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Moussa_Charting
{
	public partial class StackedBar : UserControl
	{
        private Dictionary<string, List<float>> dataDictionary;
        public List<Brush> Brushes;
        public StackedBar()
		{
			// Required to initialize variables
			InitializeComponent();
            dataDictionary = new Dictionary<string, List<float>>();
            Brushes = new List<Brush>();
            Brushes.Add(new SolidColorBrush(GetColorFromHexa("#FFFF0097")));
            Brushes.Add(new SolidColorBrush(GetColorFromHexa("#FF005B77")));
            Brushes.Add(new SolidColorBrush(GetColorFromHexa("#FFFFFFFF")));


		}
        private Color GetColorFromHexa(string hexaColor)
        {
            return Color.FromArgb(
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16),
                    Convert.ToByte(hexaColor.Substring(7, 2), 16));
        }

        public void BindData(Data.StackedDataSeries stackedDataSeries)
        {
            //int seriesID = 0;
            foreach (Data.DataSeries series in stackedDataSeries)
            {
                foreach (Data.DataPoint data in series)
                {
                    if (!dataDictionary.ContainsKey(data.Name))
                    {
                        dataDictionary.Add(data.Name, new List<float>());
                    }
                    dataDictionary[data.Name].Add(data.Value);
                }
            }
            BuildAxesLabels();
            BuildData();
        }
        public void BuildData()
        {
            int numberofBars = dataDictionary.Count;
            double ChartAreaHeight = chartingArea.ActualHeight;
            double ChartItemHeight = Math.Round((ChartAreaHeight - ((numberofBars + 1) * 5)) / numberofBars);
            int itemCount = 0;
            foreach (List<float> values in dataDictionary.Values)
            {
                StackedBarDataItem item = new StackedBarDataItem();
                item.Height = ChartItemHeight;
                item.Width = chartingArea.ActualWidth;
                item.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                item.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                item.Margin = new Thickness(0, 0, 0, ((5 * (itemCount + 1)) + (ChartItemHeight * itemCount)));
                item.BindDataPoints(values, Brushes);
                chartingArea.Children.Add(item);
                itemCount++;

            }

        }

        public void BuildAxesLabels()
        {
            int numberofBars = dataDictionary.Count;
            double AxesAreaHight = AxesName.ActualHeight;
            double AxesItemWidth = Math.Round((AxesAreaHight - ((numberofBars + 1)*5)) / numberofBars);
            int itemCount = 0;
            foreach (string key in dataDictionary.Keys)
            {
                TextBlock label = new TextBlock();
                label.TextAlignment = TextAlignment.Right;
                label.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                label.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                label.FontFamily = new FontFamily("Segoe UI Light");
                label.Height = AxesItemWidth;
                label.Foreground = new SolidColorBrush(Colors.White);
                label.FontSize = 10;
                label.Text = key;
                label.Margin = new Thickness(0, 0, 0, ((5 * (itemCount + 1)) + (AxesItemWidth * itemCount)));
                AxesName.Children.Add(label);
                itemCount++;
            }

        }

        

	}
}
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
	public partial class StackedBarDataItem : UserControl
	{
		public StackedBarDataItem()
		{
			// Required to initialize variables
			InitializeComponent();
		}
        public void BindDataPoints(List<float> values,List<Brush> Brushes)
        {
            double totalvalues = 0;
            foreach (float point in values)
            {
                totalvalues += point;
            }
            double leftmargin = 0;
            int SeriesID = 0;
            foreach (float point in values)
            {
                DataBarContent.Width = this.Width;
                DataBarContent.Height = this.Height;
                double width = Math.Round((point * DataBarContent.Width) / totalvalues);
                StackedBarDataPoint datapoint = new StackedBarDataPoint();
                datapoint.Width = width;
                datapoint.Height = DataBarContent.Height;
                datapoint.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                datapoint.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                datapoint.Margin = new Thickness(leftmargin, 0, 0, 0);
                datapoint.container.Background = Brushes[SeriesID];
                //datapoint.SetTextValue(Math.Round((point * 100 / totalvalues)).ToString());
                
                DataBarContent.Children.Add(datapoint);
                leftmargin += width;
                SeriesID++;
            }
        }
	}
}
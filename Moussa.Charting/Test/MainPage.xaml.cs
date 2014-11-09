using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Moussa_Charting;

namespace Test
{
    public partial class MainPage : PhoneApplicationPage
    {
        Moussa_Charting.Data.StackedDataSeries stacked;
        List<Brush> Brushes;
        public MainPage()
        {
            InitializeComponent();
            Brushes = new List<Brush>();
            Brushes.Add(new SolidColorBrush(Color.FromArgb(255,255,255,255)));
            Brushes.Add(new SolidColorBrush(Color.FromArgb(100,0, 91, 119)));
            Brushes.Add(new SolidColorBrush(Color.FromArgb(100,255, 255, 255)));
            Moussa_Charting.Data.DataSeries dataSeries = new Moussa_Charting.Data.DataSeries();
            dataSeries.Add(new Moussa_Charting.Data.DataPoint("Gulf",11));
            dataSeries.Add(new Moussa_Charting.Data.DataPoint("Test2",11));
            dataSeries.Add(new Moussa_Charting.Data.DataPoint("Test",11));
            dataSeries.Add(new Moussa_Charting.Data.DataPoint("Mea",11));
            dataSeries.Add(new Moussa_Charting.Data.DataPoint("Egypt",11));
            Moussa_Charting.Data.DataSeries dataSeries2 = new Moussa_Charting.Data.DataSeries();
            dataSeries2.Add(new Moussa_Charting.Data.DataPoint("Gulf", 11));
            dataSeries2.Add(new Moussa_Charting.Data.DataPoint("Test2", 11));
            dataSeries2.Add(new Moussa_Charting.Data.DataPoint("Test", 11));
            dataSeries2.Add(new Moussa_Charting.Data.DataPoint("Mea", 11));
            dataSeries2.Add(new Moussa_Charting.Data.DataPoint("Egypt", 11));
            Moussa_Charting.Data.DataSeries dataSeries3 = new Moussa_Charting.Data.DataSeries();
            dataSeries3.Add(new Moussa_Charting.Data.DataPoint("Gulf", 11));
            dataSeries3.Add(new Moussa_Charting.Data.DataPoint("Test2", 11));
            dataSeries3.Add(new Moussa_Charting.Data.DataPoint("Test", 11));
            dataSeries3.Add(new Moussa_Charting.Data.DataPoint("Mea", 11));
            dataSeries3.Add(new Moussa_Charting.Data.DataPoint("Egypt", 11));
            stacked = new Moussa_Charting.Data.StackedDataSeries();
            stacked.Add(dataSeries);
            stacked.Add(dataSeries2);
            stacked.Add(dataSeries3);
            chart.Loaded += new RoutedEventHandler(chart_Loaded);
            //dataItem.Loaded += new RoutedEventHandler(dataItem_Loaded);
        }

     

        void chart_Loaded(object sender, RoutedEventArgs e)
        {
            chart.BindData(stacked);
        }
    }
}
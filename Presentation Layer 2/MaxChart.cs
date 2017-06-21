using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Business_Layer;

namespace Presentation_Layer_
{
    public partial class MaxChart : Form
    {
        StatsManager SM;
        double[] prices;
        public MaxChart(DateTime start, DateTime end)
        {
            SM = new StatsManager();
            InitializeComponent();
            prices = SM.MaxMinPrices(true,start,end);
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Max Price",
                    Values = new ChartValues<double> { prices[0],prices[1],prices[2],prices[3],prices[4],prices[5],prices[6],prices[7],prices[8],prices[9] }
                }
            };


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Commodity ID",
                Labels = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString("N")
            });
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}

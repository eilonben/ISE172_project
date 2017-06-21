using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using Business_Layer;

namespace Presentation_Layer_
{
    public partial class MinChart : Form
    {
        StatsManager SM;
        double[] prices;
        public MinChart(DateTime start, DateTime end)
        {

            SM = new StatsManager();
            InitializeComponent();
            prices = SM.MaxMinPrices(false,start,end);
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Min Price",
                    Values = new ChartValues<double> { prices[0],prices[1],prices[2],prices[3],prices[4],prices[5],prices[6],prices[7],prices[8],prices[9] },
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))

                }

            };
           

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Commodity ID",
                Labels = new[] { "0","1", "2", "3", "4" ,"5" ,"6" ,"7" ,"8" , "9" }
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

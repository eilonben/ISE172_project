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

namespace Presentation_Layer_
{
    public partial class MinChart : Form
    {
        public MinChart()
        {
            InitializeComponent();
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Min Price",
                    Values = new ChartValues<double> { 10, 50, 39, 50,10,12,12,14,15,16 },
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

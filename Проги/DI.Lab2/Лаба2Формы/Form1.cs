using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Лаба2Формы
{
    public partial class Form1 : Form
    {
        List<Line> X1 = new List<Line>();
        List<Line> Y = new List<Line>();

        double A, B, C, a, b, y;
        int k = 6;
        int t = 0;
        const int T = 1;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(double[] ABCaby, int[] kt)
        {
            InitializeComponent();
            A = ABCaby[0];
            B = ABCaby[1];
            C = ABCaby[2];
            a = ABCaby[3];
            b = ABCaby[4];
            y = ABCaby[5];
            k = kt[0];
            t = kt[1];
          
            CountX();
            Draw(chart1, X1);
            CountY();
            Draw(chart2, Y);
            
        }

        private void chart1_Click(object sender, EventArgs e) { }
        

        

        private void CountY()
        {
            int[] K = new int[6] { 2, 4, 1, 5, 3, 0 };
            for (int i = 0; i < X1.Count; i += k)
            {
                for (int j = 0; i + j < X1.Count && j < k; j++)
                {
                    if (K[j] >= X1.Count)
                        continue;
                    Y.Add(X1[K[j]]);
                }
            }
        }

        private void Draw(Chart ch, List<Line> data)
        {
            //создаем элемент Chart
            Chart myChart = new Chart();
            //кладем его на форму и растягиваем на все окно.
            myChart.Parent = ch;
            myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            myChart.ChartAreas.Add(new ChartArea("Line Chart"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Line Chart";
            mySeriesOfPoint.Color = Color.Red;
            mySeriesOfPoint.Points.AddXY(0, data[0].secondPoint);
            for (int x = 0; x < data.Count; x += 1)
            {

                if (x != 0)
                    mySeriesOfPoint.Points.AddXY(x, data[x - 1].secondPoint);
                mySeriesOfPoint.Points.AddXY(x, data[x].firstPoint);
                mySeriesOfPoint.Points.AddXY(x + 1, data[x].secondPoint);
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);
        }

        private void CountX()
        {
            const int T = 1;
            for (int i = 0; i <= t - 1; i += T)
            {
                double x1 = A * Math.Sin(a * i) + B * Math.Cos(b * i) + i * C * Math.Cos(Math.Cos(y * i));
                double x2 = A * Math.Sin(a * (i + 1)) + B * Math.Cos(b * (i + 1)) + (i + 1) * C * Math.Cos(Math.Cos(y * (i + 1)));
                X1.Add(new Line { firstPoint = x1, secondPoint = x2 });
            }

        }


        private void Form1_Load(object sender, EventArgs e) { }
    }
}

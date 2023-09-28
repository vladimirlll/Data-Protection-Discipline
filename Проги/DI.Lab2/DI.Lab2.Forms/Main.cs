using DI.Lab2.Services.Algorithms;
using DI.Lab2.Services.Models;
using DI.Lab2.Services.Utils;
using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace DI.Lab2.Forms
{
    public partial class Main : Form
    {
        double A, B, C, 
            alpha, beta, gamma, 
            T, t,
            msgDuration;

        public Main()
        {
            InitializeComponent();
        }

        private bool IsInputSafe()
        {
            if (double.TryParse(tbA.Text, out A) &&
                double.TryParse(tbB.Text, out B) &&
                double.TryParse(tbC.Text, out C) &&
                double.TryParse(tbAlpha.Text, out alpha) &&
                double.TryParse(tbBeta.Text, out beta) &&
                double.TryParse(tbGamma.Text, out gamma) &&
                double.TryParse(tbBigSegment.Text, out T) &&
                double.TryParse(tbSmallSegment.Text, out t) &&
                double.TryParse(tbMessageDuration.Text, out msgDuration))
                return true;
            return false;
        }

        private ScramblerSettings BuildSettings()
        {
            var settings = new ScramblerSettings.Builder()
                .SetA(A)
                .SetB(B)
                .SetC(C)
                .SetAlpha(alpha)
                .SetBeta(beta)
                .SetGamma(gamma)
                .SetT(T)
                .Sett(t)
                .SetKey(KeyGenerator.Generate(T, t))
                .Build();

            return settings;
        }

        private void CleanUpPlots()
        {
            chartInitMsg.Series.Clear();
            chartEncodedMsg.Series.Clear();
            chartInitMsg.Series.Add("XOft");
            chartEncodedMsg.Series.Add("YOft");
            chartInitMsg.Series[0].ChartType =
                SeriesChartType.Line;
            chartEncodedMsg.Series[0].ChartType =
                SeriesChartType.Line;
            chartInitMsg.Series[0].BorderWidth = 3;
            chartEncodedMsg.Series[0].BorderWidth = 3;

            chartInitMsg.ChartAreas[0].AxisX.Minimum =
                chartEncodedMsg.ChartAreas[0].AxisX.Minimum = 0;
            chartInitMsg.ChartAreas[0].AxisX.Maximum =
                chartEncodedMsg.ChartAreas[0].AxisX.Maximum = msgDuration;

            chartInitMsg.Titles.Clear();
            chartInitMsg.Titles.Add("График функции X(t)");
            chartEncodedMsg.Titles.Clear();
            chartEncodedMsg.Titles.Add("График функции Y(t)");


        }

        private void DrawPlotOf(PhoneMessageScrambler scrambler)
        {
            for(double t = 0; t <= scrambler.MessageDuration; t+= scrambler.Settings.t)
            {
                double XOftValue = scrambler.InputSignalValueAt(t);
                var YOftValues = scrambler.OutputSignalValueAt(t);

                // Add points to charts
                chartInitMsg.Series[0].Points.AddXY(t, XOftValue);
                foreach (var y in YOftValues)
                    chartEncodedMsg.Series[0].Points.AddXY(t, y);
            }
        }

        private void DrawWithInputData()
        {
            if (IsInputSafe())
            {
                CleanUpPlots();
                try
                {
                    var settings = BuildSettings();
                    var scrambler = new PhoneMessageScrambler(
                        settings,
                        msgDuration);
                    DrawPlotOf(scrambler);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
                MessageBox.Show("Значения констант заданы некорректно");
        }

        private void DrawWithTestData()
        {
            A = 1; B = 1; C = 1;
            alpha = 1; beta = 1; gamma = 1;
            T = 1; t = 0.5;
            msgDuration = 10;
            CleanUpPlots();
            try
            {
                var settings = BuildSettings();
                var scrambler = new PhoneMessageScrambler(
                    settings,
                    msgDuration);
                DrawPlotOf(scrambler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawWithTestData();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}

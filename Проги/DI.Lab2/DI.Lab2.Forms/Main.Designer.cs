namespace DI.Lab2.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartInitMsg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEncodedMsg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBeta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbGamma = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBigSegment = new System.Windows.Forms.TextBox();
            this.tbSmallSegment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMessageDuration = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartInitMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEncodedMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // chartInitMsg
            // 
            chartArea1.Name = "ChartArea1";
            this.chartInitMsg.ChartAreas.Add(chartArea1);
            this.chartInitMsg.Location = new System.Drawing.Point(12, 12);
            this.chartInitMsg.Name = "chartInitMsg";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Name = "Series1";
            this.chartInitMsg.Series.Add(series1);
            this.chartInitMsg.Size = new System.Drawing.Size(788, 484);
            this.chartInitMsg.TabIndex = 0;
            this.chartInitMsg.Text = "chart1";
            title1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "График функции X(t)";
            this.chartInitMsg.Titles.Add(title1);
            // 
            // chartEncodedMsg
            // 
            chartArea2.Name = "ChartArea1";
            this.chartEncodedMsg.ChartAreas.Add(chartArea2);
            this.chartEncodedMsg.Location = new System.Drawing.Point(12, 532);
            this.chartEncodedMsg.Name = "chartEncodedMsg";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Green;
            series2.Name = "Series1";
            this.chartEncodedMsg.Series.Add(series2);
            this.chartEncodedMsg.Size = new System.Drawing.Size(788, 484);
            this.chartEncodedMsg.TabIndex = 0;
            this.chartEncodedMsg.Text = "chart1";
            title2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Title1";
            title2.Text = "График функции Y(t)";
            this.chartEncodedMsg.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1379, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Установка констант в функции:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1379, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "X(t) = A*sin(alpha*t) + B*cos(beta * t) + t * C * cos(cos(gamma*t))\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1379, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "A:";
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(1421, 191);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(100, 29);
            this.tbA.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1379, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "B:";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(1421, 230);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(100, 29);
            this.tbB.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1379, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "C:";
            // 
            // tbC
            // 
            this.tbC.Location = new System.Drawing.Point(1421, 269);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(100, 29);
            this.tbC.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1364, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "alpha:";
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(1421, 306);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(100, 29);
            this.tbAlpha.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1372, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "beta:";
            // 
            // tbBeta
            // 
            this.tbBeta.Location = new System.Drawing.Point(1421, 347);
            this.tbBeta.Name = "tbBeta";
            this.tbBeta.Size = new System.Drawing.Size(100, 29);
            this.tbBeta.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1349, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "gamma:";
            // 
            // tbGamma
            // 
            this.tbGamma.Location = new System.Drawing.Point(1421, 389);
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(100, 29);
            this.tbGamma.TabIndex = 2;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(1349, 450);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(0, 21);
            this.lblKey.TabIndex = 1;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(1653, 360);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(189, 58);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "Нарисовать графики";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1394, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "T:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1397, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "t:";
            // 
            // tbBigSegment
            // 
            this.tbBigSegment.Location = new System.Drawing.Point(1421, 426);
            this.tbBigSegment.Name = "tbBigSegment";
            this.tbBigSegment.Size = new System.Drawing.Size(100, 29);
            this.tbBigSegment.TabIndex = 2;
            // 
            // tbSmallSegment
            // 
            this.tbSmallSegment.Location = new System.Drawing.Point(1421, 468);
            this.tbSmallSegment.Name = "tbSmallSegment";
            this.tbSmallSegment.Size = new System.Drawing.Size(100, 29);
            this.tbSmallSegment.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1218, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Длительность сообщения:";
            // 
            // tbMessageDuration
            // 
            this.tbMessageDuration.Location = new System.Drawing.Point(1421, 69);
            this.tbMessageDuration.Name = "tbMessageDuration";
            this.tbMessageDuration.Size = new System.Drawing.Size(100, 29);
            this.tbMessageDuration.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.tbSmallSegment);
            this.Controls.Add(this.tbGamma);
            this.Controls.Add(this.tbBigSegment);
            this.Controls.Add(this.tbBeta);
            this.Controls.Add(this.tbAlpha);
            this.Controls.Add(this.tbC);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbMessageDuration);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartEncodedMsg);
            this.Controls.Add(this.chartInitMsg);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartInitMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEncodedMsg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartInitMsg;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEncodedMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBeta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbGamma;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBigSegment;
        private System.Windows.Forms.TextBox tbSmallSegment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMessageDuration;
    }
}


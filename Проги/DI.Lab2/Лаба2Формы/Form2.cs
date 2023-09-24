using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба2Формы
{
    public partial class Form2 : Form
    {

        double A, B, C, a, b, y;
        int k = 6;
        int t = 0;
        bool g = false;

        public Form2()
        {
            InitializeComponent();
        }
        void labelInit()
        {
            //проверка на дурака
            g = (int.TryParse(textBox1.Text, out t) && double.TryParse(textBox2.Text, out A) &&
                double.TryParse(textBox3.Text, out B) && double.TryParse(textBox4.Text, out C) &&
                double.TryParse(textBox5.Text, out a) && double.TryParse(textBox6.Text, out b) &&
                double.TryParse(textBox7.Text, out y));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //инициализация полей
            labelInit();
            if(g)
            {
                Form1 f = new Form1(new double[] { A, B, C, a, b, y }, new int[] { k, t });
                f.Show();
            }
        }
    }
}

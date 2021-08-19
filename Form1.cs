using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Simulation_Lab5
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = rand.Next();
            string answer = "No";

            if (n % 2 == 1)
            {
                answer = "Yes";
            }

            label1.Text = answer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int n1 = int.Parse(textBox1.Text);
            int n2 = int.Parse(textBox2.Text);
            int n3 = int.Parse(textBox3.Text);
            int n4 = int.Parse(textBox4.Text);
            int n5 = int.Parse(textBox5.Text);

            int n = int.Parse(textBox6.Text);

            int[] experiments = new int[5];
            double[] frequency = new double[5];

            experiments[0] = 0;
            experiments[1] = 0;
            experiments[2] = 0;
            experiments[3] = 0;
            experiments[4] = 0;

            while(i < n)
            {
                int r = rand.Next(20);
                if (n1 == r) experiments[0]++;
                else if (n2 == r) experiments[1]++;
                else if (n3 == r) experiments[2]++;
                else if (n4 == r) experiments[3]++;
                else if (n5 == r) experiments[4]++;
                i++;
            }

            i = 0;
            foreach (var item in experiments)
            {
                frequency[i] = item / 20;
            }

            string[] series = { "1", "2", "3", "4", "5" };

            this.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.000}";

            i = 0;
            foreach (var item in series)
            {
                /*
                 *Here we should use values from frequency array, but doubles are not
                 *showing for some reason
                 *The values end up like 0.0 and the real value is something like 0.0#
                 */

                this.chart1.Series["Series1"].Points.AddXY(series[i], (double) experiments[i]);
                i++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace test
{
    public partial class Form2 : Form
    {
        Stopwatch sw = new Stopwatch();
        LinkedList<long> liststored = new LinkedList<long>();
        public Form2()
        {
            InitializeComponent();
        }
        long[] list /*liststored = { 0, 115, 8, 8, 195, 125, 250, 125, 230, 125, 380, 115, 10, 8, 190, 125 },*/ ;

        int i = 0;



        private void textBox1_MouseDownOrUp(object sender, MouseEventArgs e)
        {
            if (i < liststored.Count)
            {
                sw.Stop();
                list[i] = sw.ElapsedMilliseconds;
                sw.Reset();
                sw.Start();
                i++;
            }
        }

        private void save_MouseDownOrUp(object sender, MouseEventArgs e)
        {
            sw.Stop();
            liststored.AddLast(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            i++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.Stop();
            sw.Reset();
            Boolean pass = true;
            for (i = 0; i < liststored.Count; i++)
            {
                if (Math.Abs(list[i] - liststored.ElementAt(i)) > liststored.ElementAt(i)/2)
                {
                    textBox1.Text = "Wrong rhythm. pls hit me again :)";
                    i = 0;
                    pass = false;
                    break;
                }
            }
            if (pass)
                textBox1.Text = "Correct rhythm";
            i = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = true;
            textBox1.MouseDown -= save_MouseDownOrUp;
            textBox1.MouseUp -= save_MouseDownOrUp;
            textBox1.MouseDown += new MouseEventHandler(textBox1_MouseDownOrUp);
            textBox1.MouseUp += new MouseEventHandler(textBox1_MouseDownOrUp);
            i = 0;
            sw.Stop();
            sw.Reset();
            list = new long[liststored.Count];
            textBox1.Text = "Now tap your rhythm again on me and click \"check\" to check whether it matches with the stored rhythm.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
            textBox1.MouseDown -= textBox1_MouseDownOrUp;
            textBox1.MouseUp -= textBox1_MouseDownOrUp;
            textBox1.MouseDown += new MouseEventHandler(save_MouseDownOrUp);
            textBox1.MouseUp += new MouseEventHandler(save_MouseDownOrUp);
            i = 0;
            sw.Stop();
            sw.Reset();
            liststored = new LinkedList<long>();
            textBox1.Text = "Save your rhythm by tapping on me. :)";
        }








    }
}

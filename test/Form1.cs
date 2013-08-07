using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace test
{
    public partial class Form1 : Form
    {
        Boolean wait=true;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            this.SetBounds(Screen.PrimaryScreen.Bounds.Right, 0, Size.Width, Size.Height);
        }

        private void save_Click(object sender, EventArgs e)
        {
            Person per=new Person();
            per.name = name.Text;
            per.age = int.Parse(age.Text);

            Stream stream = File.Create(@"..\"+per.name);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, per);
            stream.Close();
        }

        private void load_Click(object sender, EventArgs e)
        {
            Person per;
            Stream stream = File.OpenRead(@"..\"+name.Text);
            BinaryFormatter bFormatter = new BinaryFormatter();
            per = (Person)bFormatter.Deserialize(stream);
            stream.Close();
            age.Text = per.age.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SetBounds((Location.X) - 2, 0, Size.Width, Size.Height);
            //Refresh();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }
    }

    [Serializable()]
    public class Person
    {
        public string name;
        public int age;

    }
}

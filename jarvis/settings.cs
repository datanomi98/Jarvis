using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace jarvis
{
    public partial class settings : Form
    {
        //public static string firefoxpath = "";
        


        public settings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(+500, +300);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog firefox = new OpenFileDialog();
            if (firefox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                TextWriter tw = new StreamWriter(@"F:\jarvispath\firefoxpath.txt");

                tw.WriteLine(firefox.FileName);
                tw.Close();



            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog skype = new OpenFileDialog();
            if (skype.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextWriter skypepath = new StreamWriter(@"F:\jarvispath\skypepath.txt");
                
                skypepath.WriteLine(skype.FileName);
                skypepath.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog origin = new OpenFileDialog();
            if(origin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextWriter originpath = new StreamWriter(@"F:\jarvispath\originpath.txt");
                originpath.WriteLine(origin.FileName);
                originpath.Close();
            }
        }
       

        private void settings_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
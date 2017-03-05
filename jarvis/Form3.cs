using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jarvis
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            pictureBox1.Image = Jarvis.bg;
            Fadeout(this, 100);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(+1050, +500);
          

        }

        
        private void Form3_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 100;
            
        }
       
        public async void Fadeout(Form3 o, int interval = 80)
        {
           
                while (o.Opacity > 0.0)
                {
                    await Task.Delay(interval);
                    o.Opacity -= 0.02;
                    
                if(o.Opacity == 0.0)
                {
                    this.Close();
                }


                
            }
           
            

        }
        







        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form4 : Form
    {
        const int datanum = 39;
        Label[] label = new Label[0];
        int index = -1;
        Form5 f5;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private Label createLabel(int i)
        {
            Label lb = new Label();
            lb.Text = ((Form1)this.Owner).f2.label[i].Text;
            lb.Font = new Font("新細明體", 14);
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Width = 360;
            lb.Height = 80;
            lb.Name = ((Form1)this.Owner).f2.num[i].ToString();
            lb.Click += new System.EventHandler(lb_Click);
            return lb;
        }

        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            f5 = new Form5();
            f5.SheetName = int.Parse(lb.Name);
            f5.Show();
        }

        public void showFavorite()
        {           
            if (index > -1)
                for (int i = 0; i <= index; ++i)
                    Controls.Remove(label[i]);
            index = -1;
            int posy = 62;
            for (int i = 0; i < datanum; ++i)
            {
                if (((Form1)this.Owner).f2.btnstar[i])
                {
                    index++;
                    Array.Resize(ref label, label.Length + 1);
                    label[index] = createLabel(i);
                    label[index].Left = 1;
                    label[index].Top = posy;
                    Controls.Add(label[index]);
                    posy += 80;
                }
            }
            
        }
    }

}
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
    public partial class Form1 : Form
    {
        public Form2 f2;
        Form3 f3;
        public Form4 f4;
        Form7 f7;
        int fontsize = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.clean();
            f2.Show();      
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Owner = this;
            f3 = new Form3();
            f3.Owner = this;
            f4 = new Form4();
            f4.Owner = this;
            f7 = new Form7();
            f7.Owner = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f7.Show();
        }

        public void foreSetting()
        {
            if (f7.forecolor == 0)
            {
                foreach (Control items in this.Controls)
                    items.ForeColor = Color.Black;
                foreach (Control items in f2.Controls)
                    items.ForeColor = Color.Black;
                foreach (Control items in f4.Controls)
                    items.ForeColor = Color.Black;
            }
            else if (f7.forecolor == 1)
            {
                foreach (Control items in this.Controls)
                    items.ForeColor = Color.Green;
                foreach (Control items in f2.Controls)
                    items.ForeColor = Color.Green;
                foreach (Control items in f4.Controls)
                    items.ForeColor = Color.Green;
            }
            else if (f7.forecolor == 2)
            {
                foreach (Control items in this.Controls)
                    items.ForeColor = Color.Blue;
                foreach (Control items in f2.Controls)
                    items.ForeColor = Color.Blue;
                foreach (Control items in f4.Controls)
                    items.ForeColor = Color.Blue;
            }
        }

        public void fontsizeSetting()
        {
            if (f7.fontsize == 0)
            {
                if (fontsize != 0)
                {
                    foreach (Control items in this.Controls)
                    {
                        if (fontsize == 1)
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size - 4);
                        else
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size - 8);
                    }
                }
                
                foreach (Control items in f2.Controls)
                {
                    if (items is Label)
                        if (((Label)items).Font.Size != 14)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), 14);
                    if (items is Button)
                        if (((Button)items).Font.Size != 12)
                            ((Button)items).Font = new Font(((Button)items).Font.Style.ToString(), 12);
                }
                foreach (Control items in f4.Controls)
                    items.Font = new Font(items.Font.Style.ToString(), 14);

                fontsize = 0;
            }
            else if(f7.fontsize == 1)
            {
                if (fontsize != 1)
                {
                    foreach (Control items in this.Controls)
                    {
                        if (fontsize == 0)
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size + 4);
                        else
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size - 4);
                    }
                }
                
                foreach (Control items in f2.Controls)
                {
                    if (items is Label)
                        if (((Label)items).Font.Size != 18)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), 18);
                    if (items is Button)
                        if (((Button)items).Font.Size != 16)
                            ((Button)items).Font = new Font(((Button)items).Font.Style.ToString(), 16);
                }
                foreach (Control items in f4.Controls)
                    items.Font = new Font(items.Font.Style.ToString(), 18);
                fontsize = 1;
            }
            else if (f7.fontsize == 2)
            {
                if(fontsize!=2)
                {
                    foreach (Control items in this.Controls)
                    {
                        if (fontsize == 0)
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size + 8);
                        else
                            items.Font = new Font(items.Font.Style.ToString(), items.Font.Size + 4);
                    }
                }
                
                foreach (Control items in f2.Controls)
                {
                    if (items is Label)
                        if (((Label)items).Font.Size != 22)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), 22);
                    if (items is Button)
                        if (((Button)items).Font.Size != 20)
                            ((Button)items).Font = new Font(((Button)items).Font.Style.ToString(), 20);
                }
                foreach (Control items in f4.Controls)
                    items.Font = new Font(items.Font.Style.ToString(), 22);
                fontsize = 2;
            }
        }

        public void fontSetting()
        {
            if (f7.font == 0)
            {
                foreach (Control items in this.Controls)
                    items.Font = new Font("新細明體", items.Font.Size);
                foreach (Control items in f2.Controls)
                    items.Font = new Font("新細明體", items.Font.Size);
                foreach (Control items in f4.Controls)
                    items.Font = new Font("新細明體", items.Font.Size);
            }
            else if(f7.font==1)
            {
                foreach (Control items in this.Controls)
                    items.Font = new Font("標楷體", items.Font.Size);
                foreach (Control items in f2.Controls)
                    items.Font = new Font("標楷體", items.Font.Size);
                foreach (Control items in f4.Controls)
                    items.Font = new Font("標楷體", items.Font.Size);
            }
            else if (f7.font ==2)
            {
                foreach (Control items in this.Controls)
                    items.Font = new Font("微軟正黑體", items.Font.Size);
                foreach (Control items in f2.Controls)
                    items.Font = new Font("微軟正黑體", items.Font.Size);
                foreach (Control items in f4.Controls)
                    items.Font = new Font("微軟正黑體", items.Font.Size);
            }
        }
    }
}

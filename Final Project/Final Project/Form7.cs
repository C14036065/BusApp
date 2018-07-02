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
    public partial class Form7 : Form
    {
        public int fontsize = 1, font = 0, forecolor = 0;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "黑")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).ForeColor = Color.Black;
                    if (items is ComboBox)
                        ((ComboBox)items).ForeColor = Color.Black;
                }
                forecolor = 0;
            }
            else if (comboBox2.SelectedItem.ToString() == "綠")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).ForeColor = Color.Green;
                    if (items is ComboBox)
                        ((ComboBox)items).ForeColor = Color.Green;
                }
                forecolor = 1;
            }
            else if (comboBox2.SelectedItem.ToString() == "藍")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).ForeColor = Color.Blue;
                    if (items is ComboBox)
                        ((ComboBox)items).ForeColor = Color.Blue;
                }
                forecolor = 2;
            }
            ((Form1)this.Owner).foreSetting();
        }//文字顏色

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "小" && fontsize != 0)
            {               
                foreach (Control items in this.Controls)
                {
                    if(fontsize==1)
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size - 4);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size - 6);
                    }
                    else
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size - 8);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size - 12);
                    }                   
                }
                fontsize = 0;
                ((Form1)this.Owner).fontsizeSetting();
            }
            else if(comboBox3.SelectedItem.ToString() == "中" && fontsize != 1)
            {
                foreach (Control items in this.Controls)
                {
                    if (fontsize == 0)
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size + 4);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size + 6);
                    }
                    else
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size - 4);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size - 6);
                    }
                }
                fontsize = 1;
                ((Form1)this.Owner).fontsizeSetting();
            }
            else if(comboBox3.SelectedItem.ToString() == "大" && fontsize != 2)
            {
                foreach (Control items in this.Controls)
                {
                    if (fontsize == 0)
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size + 8);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size + 12);
                    }
                    else
                    {
                        if (items is Label)
                            ((Label)items).Font = new Font(((Label)items).Font.Style.ToString(), ((Label)items).Font.Size + 4);
                        if (items is ComboBox)
                            ((ComboBox)items).Font = new Font(((ComboBox)items).Font.Style.ToString(), ((ComboBox)items).Font.Size + 6);
                    }
                }
                fontsize = 2;
                ((Form1)this.Owner).fontsizeSetting();
            }          
        }//字體大小


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox4.SelectedItem.ToString() == "新細明體")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).Font = new Font("新細明體", ((Label)items).Font.Size);
                    if (items is ComboBox)
                        ((ComboBox)items).Font = new Font("新細明體", ((ComboBox)items).Font.Size);
                }
                font = 0;
            }
            else if(comboBox4.SelectedItem.ToString() == "標楷體")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).Font = new Font("標楷體", ((Label)items).Font.Size);
                    if (items is ComboBox)
                        ((ComboBox)items).Font = new Font("標楷體", ((ComboBox)items).Font.Size);
                }
                font = 1;
            }
            else if (comboBox4.SelectedItem.ToString() == "微軟正黑體")
            {
                foreach (Control items in this.Controls)
                {
                    if (items is Label)
                        ((Label)items).Font = new Font("微軟正黑體", ((Label)items).Font.Size);
                    if (items is ComboBox)
                        ((ComboBox)items).Font = new Font("微軟正黑體", ((ComboBox)items).Font.Size);
                }
                font = 2;
            }
            ((Form1)this.Owner).fontSetting();
        }//字型

        
    }
}

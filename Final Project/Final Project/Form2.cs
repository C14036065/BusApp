using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Final_Project
{
    public partial class Form2 : Form
    {
        public Form5 f5;
        //index=39
        public string str = "";       
        public int[] num = new int[] { 6, 8, 11, 14, 15, 26, 27, 28, 29, 33, 49, 54, 60, 66, 69, 70, 71, 72, 93, 101, 102, 107, 108, 128, 131, 132, 133, 142, 154, 156, 157, 163, 284, 290, 307, 323, 324, 325, 659 };
        public const int datanum = 39;
        public Label[] label = new Label[datanum];
        public Button[] button = new Button[datanum];
        public bool[] btnstar = new bool[datanum];
        int[] list = new int[datanum];
        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        public Form2()
        {
            InitializeComponent();
            button4.Click += new System.EventHandler(button3_Click);
            button5.Click += new System.EventHandler(button3_Click);
            button8.Click += new System.EventHandler(button3_Click);
            button9.Click += new System.EventHandler(button3_Click);
            button10.Click += new System.EventHandler(button3_Click);
            button13.Click += new System.EventHandler(button3_Click);
            button14.Click += new System.EventHandler(button3_Click);
            button15.Click += new System.EventHandler(button3_Click);
            button17.Click += new System.EventHandler(button3_Click);
        }
        BindingManagerBase bm;
        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                "AttachDbFilename=|DataDirectory|Database1.mdf;" +
                "Integrated Security=True";
            DataSet ds = new DataSet();
            SqlDataAdapter daBus = new SqlDataAdapter("SELECT * FROM Bus", cn);
            daBus.Fill(ds, "Bus");
            Controls.Add(tb1);
            Controls.Add(tb2);
            tb1.DataBindings.Add("Text", ds, "Bus.起點");
            tb2.DataBindings.Add("Text", ds, "Bus.終點");
            bm = this.BindingContext[ds, "Bus"];


            for (int i = 0; i < 39; ++i)
            {
                label[i] = createLabel(num[i], tb1.Text, tb2.Text);
                button[i] = createButton(i);
                bm.Position++;
            }
        }

        public void clean()
        {
            int i = 0;
            if (str.Length > 0)
            {
                while (i < 39)
                {
                    if (num[i].ToString() == str)
                    {
                        Controls.Remove(label[i]);
                        Controls.Remove(button[i]);
                        break;
                    }
                    i++;
                }
            }
            str = "";
            label4.Text = str;
        }

        private Label createLabel(int i, string starting, string destination)
        {
            Label lb = new Label();
            lb.Text = i.ToString() + "  " + starting + "-" + destination;
            lb.Font = new Font("新細明體", 14);
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Width = 270;
            lb.Height = 80;
            lb.Click += new System.EventHandler(lb_Click);
            return lb;
        }

        private Button createButton(int i)
        {
            Button btn = new Button();
            btn.Width = 80;
            btn.Height = 80;
            btn.Name = i.ToString();
            btn.Click += new System.EventHandler(btn_Click);
            return btn;
        }

        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            f5 = new Form5();
            f5.Owner = this;
            f5.SheetName = int.Parse(str);
            f5.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!btnstar[int.Parse(btn.Name)])
            {
                btn.BackColor = Color.Red;
                btnstar[int.Parse(btn.Name)] = true;
                ((Form1)this.Owner).f4.showFavorite();
            }
            else
            {
                btn.BackColor = SystemColors.Control;
                btnstar[int.Parse(btn.Name)] = false;
                ((Form1)this.Owner).f4.showFavorite();
            }
            ((Form1)this.Owner).foreSetting();
            ((Form1)this.Owner).fontSetting();
            ((Form1)this.Owner).fontsizeSetting();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int i = 0;
            if (str.Length > 0)
            {            
                while (i < 39)
                {
                    if (num[i].ToString() == str)
                    {
                        Controls.Remove(label[i]);
                        Controls.Remove(button[i]);
                        break;
                    }                        
                    i++;
                }                
            }
            i = 0;      
            str += btn.Text;
            label4.Text = str;
            while (i < 39)
            {
                if (num[i].ToString() == str)
                {
                    label[i].Left = 1;
                    label[i].Top = 50;
                    button[i].Left = 280;
                    button[i].Top = 50;
                    Controls.Add(label[i]);
                    Controls.Add(button[i]);
                    break;
                }
                i++;
            }
            ((Form1)this.Owner).foreSetting();
            ((Form1)this.Owner).fontSetting();
            ((Form1)this.Owner).fontsizeSetting();
        }

        private void button18_Click(object sender, EventArgs e)//clear
        {
            int i = 0;
            if (str.Length > 0)
            {
                while (i < 39)
                {
                    if (num[i].ToString() == str)
                    {
                        Controls.Remove(label[i]);
                        Controls.Remove(button[i]);
                        break;
                    }
                    i++;
                }
            }
            str = "";
            label4.Text = str;
        }

        private void button16_Click(object sender, EventArgs e)//back
        {
            int i = 0;
            if (str.Length > 0)
            {
                while (i < 39)
                {
                    if (num[i].ToString() == str)
                    {
                        Controls.Remove(label[i]);
                        Controls.Remove(button[i]);
                        break;
                    }
                    i++;
                }
            }
            i = 0;
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                label4.Text = str;
            }
            if (str.Length > 0)
            {
                while (i < 39)
                {
                    if (num[i].ToString() == str)
                    {
                        label[i].Left = 1;
                        label[i].Top = 50;
                        button[i].Left = 280;
                        button[i].Top = 50;
                        Controls.Add(label[i]);
                        Controls.Add(button[i]);
                        break;
                    }
                    i++;
                }
            }
            ((Form1)this.Owner).foreSetting();
            ((Form1)this.Owner).fontSetting();
            ((Form1)this.Owner).fontsizeSetting();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project
{
    public partial class Form5 : Form
    {
        private const string FileName = "台中公車.xlsx";
        private const string ProviderName = "Microsoft.ACE.OLEDB.12.0;";
        private const string ExtendedString = "'Excel 8.0;";
        private const string Hdr = "Yes;";
        private const string IMEX = "0';";

        string cs = "Data Source=" + FileName + ";" +
            "Provider=" + ProviderName +
            "Extended Properties=" + ExtendedString +
            "HDR=" + Hdr +
            "IMEX=" + IMEX;
        public int SheetName;

        public Form5()
        {
            InitializeComponent();           
            //FileLoad();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void FileLoad()
        {           
            using (OleDbConnection cn = new OleDbConnection(cs))
            {
                cn.Open();           
                string qs_left = "SELECT Stop FROM[" + SheetName + "$] WHERE Direction = 0";
                string qs_right = "SELECT Stop FROM[" + SheetName + "$] WHERE Direction = 1";
                try
                {
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs_left, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        this.dataGridView1.DataSource = dt;
                    }
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs_right, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        this.dataGridView2.DataSource = dt;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView2.DataSource = null;
                this.dataGridView3.DataSource = null;

                e.Cancel = true;
                this.Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            FileLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string chosen = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            using (OleDbConnection cn = new OleDbConnection(cs))
            {
                cn.Open();
                string qs = "SELECT * FROM[" + SheetName + "$] WHERE Direction = 0 AND Stop = '" + chosen + "'";
                try
                {
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        dt.Columns.RemoveAt(0);

                        this.dataGridView3.DataSource = dt;
                        this.dataGridView3.Rows[0].DefaultCellStyle.Format = "HH:mm";
                        this.dataGridView3.Rows[0].MinimumHeight = 60;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string chosen = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            using (OleDbConnection cn = new OleDbConnection(cs))
            {
                cn.Open();
                string qs = "SELECT * FROM[" + SheetName + "$] WHERE Direction = 1 AND Stop = '" + chosen + "'";
                try
                {
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(qs, cn))
                    {
                        DataTable dt = new DataTable();
                        dr.Fill(dt);
                        dt.Columns.RemoveAt(0);

                        this.dataGridView3.DataSource = dt;
                        this.dataGridView3.Rows[0].DefaultCellStyle.Format = "HH:mm";
                        this.dataGridView3.Rows[0].MinimumHeight = 60;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

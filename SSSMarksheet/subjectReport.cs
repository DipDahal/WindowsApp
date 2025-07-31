using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

using System.Data.OleDb;

namespace SSSMarksheet
{
    public partial class subjectReport : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public subjectReport()
        {
            InitializeComponent();
        }

        private void comboStream_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboClass.Focus();

                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
            }
            catch (Exception)
            {

            }
        }
        protected void LoadDatagridview()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("select stream, classes, subject from AddSubject where stream like '%" + comboStream.Text + "%' and classes like '%" + comboClass.Text + "%' ", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                da.SelectCommand = cmd;
                da.Fill(dt);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells[1].Value = dt.Rows[j].ItemArray[0].ToString();
                    dataGridView1.Rows[j].Cells[2].Value = dt.Rows[j].ItemArray[1].ToString();
                    dataGridView1.Rows[j].Cells[3].Value = dt.Rows[j].ItemArray[2].ToString();
                    conn.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void subjectReport_Load(object sender, EventArgs e)
        {
            LoadDatagridview();
        }

        private void comboStream_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadDatagridview();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboStream.Text = "";
            comboStream.SelectedIndex = -1;
            comboClass.Text = "";
            comboClass.SelectedIndex = -1;

            dataGridView1.Rows.Clear();
            LoadDatagridview();
        }
    }
}

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
    public partial class StudentsCertificateReport : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public StudentsCertificateReport()
        {
            InitializeComponent();
            regIdFillCombobox();
            NameFillCombobox();
            symbolFillCombobox();

        }
        protected void regIdFillCombobox()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select regid from certificateDetails", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboRegId.DisplayMember = "regid";
                comboRegId.ValueMember = "regid";
                comboRegId.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void NameFillCombobox()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select studName from certificateDetails", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboName.DisplayMember = "studName";
                comboName.ValueMember = "studName";
                comboName.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void symbolFillCombobox()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select symbol from certificateDetails", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboSymbNo.DisplayMember = "symbol";
                comboSymbNo.ValueMember = "symbol";
                comboSymbNo.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        
        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void comboRegId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboSymbNo.Focus();

                }
            }
        }

        private void comboSymbNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboStream.Focus();

                }
            }
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

        private void comboClass_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboSec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboName.Focus();

                }
            }
        }

        private void comboName_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        protected void LoadDatagridview()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select regid, symbol, studName, streamName, className, fatherName, motherName, dobBS, municipal, wardNo, district, issuedate, gpa from certificateDetails", conn);
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
                        dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j].ItemArray[3].ToString();
                        dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j].ItemArray[4].ToString();
                        dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j].ItemArray[5].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j].ItemArray[6].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j].ItemArray[7].ToString();
                        dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j].ItemArray[8].ToString();
                        dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j].ItemArray[9].ToString();
                        dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j].ItemArray[10].ToString();
                        dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j].ItemArray[11].ToString();
                        dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j].ItemArray[12].ToString();
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
        protected void LoadDatagridviewThroughRegId()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select regid, symbol, studName, streamName, className, fatherName, motherName, dobBS, municipal, wardNo, district, issuedate, gpa from certificateDetails where regid like '%" + comboRegId.Text + "%' and symbol like '%" + comboSymbNo.Text + "%'", conn);
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
                    dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j].ItemArray[3].ToString();
                    dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j].ItemArray[4].ToString();
                    dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j].ItemArray[5].ToString();
                    dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j].ItemArray[6].ToString();
                    dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j].ItemArray[7].ToString();
                    dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j].ItemArray[8].ToString();
                    dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j].ItemArray[9].ToString();
                    dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j].ItemArray[10].ToString();
                    dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j].ItemArray[11].ToString();
                    dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j].ItemArray[12].ToString();
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
        protected void LoadDatagridviewThroughName()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select regid, symbol, studName, streamName, className, fatherName, motherName, dobBS, municipal, wardNo, district, issuedate, gpa from certificateDetails where studName like '%" + comboName.Text + "%' and className like '%" + comboClass.Text + "%' and streamName like '%" + comboStream.Text + "%'", conn);
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
                    dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j].ItemArray[3].ToString();
                    dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j].ItemArray[4].ToString();
                    dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j].ItemArray[5].ToString();
                    dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j].ItemArray[6].ToString();
                    dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j].ItemArray[7].ToString();
                    dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j].ItemArray[8].ToString();
                    dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j].ItemArray[9].ToString();
                    dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j].ItemArray[10].ToString();
                    dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j].ItemArray[11].ToString();
                    dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j].ItemArray[12].ToString();
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
        protected void LoadDatagridviewThroughrollNo()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select regid, symbol, studName, streamName, className, fatherName, motherName, dobBS, municipal, wardNo, district, issuedate, gpa from certificateDetails where streamName like '%" + comboStream.Text + "%' and className like '%" + comboClass.Text + "%' ", conn);
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
                    dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j].ItemArray[3].ToString();
                    dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j].ItemArray[4].ToString();
                    dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j].ItemArray[5].ToString();
                    dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j].ItemArray[6].ToString();
                    dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j].ItemArray[7].ToString();
                    dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j].ItemArray[8].ToString();
                    dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j].ItemArray[9].ToString();
                    dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j].ItemArray[10].ToString();
                    dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j].ItemArray[11].ToString();
                    dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j].ItemArray[12].ToString();
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
        
        private void StudentsReport_Load(object sender, EventArgs e)
        {
            LoadDatagridview();
            
            comboRegId.SelectedIndex = -1;
            comboSymbNo.SelectedIndex = -1;
            comboStream.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboName.SelectedIndex = -1;
        }

        private void comboRegId_SelectedValueChanged(object sender, EventArgs e)
        {
            //LoadDatagridviewThroughRegId();
        }

        private void comboRegId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDatagridviewThroughRegId();
            }catch(Exception)
            {
            }
        }

        private void comboSymbNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comboRegId.SelectedIndex = -1;
                comboName.SelectedIndex = -1;
                LoadDatagridviewThroughRegId();
            }
            catch (Exception)
            {
            }
        }

        private void comboName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comboSymbNo.SelectedIndex = -1;
                comboRegId.SelectedIndex = -1;

                LoadDatagridviewThroughName();
            }
            catch (Exception)
            {
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboRegId.Text = "";
            comboSymbNo.Text = "";
            comboStream.Text = "";
            comboClass.Text = "";
            comboName.Text = "";

            comboRegId.SelectedIndex = -1;
            comboSymbNo.SelectedIndex = -1;
            comboStream.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboName.SelectedIndex = -1;

            dataGridView1.Rows.Clear();
            LoadDatagridview();

        }

        private void comboStream_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comboSymbNo.SelectedIndex = -1;
                comboRegId.SelectedIndex = -1;
                LoadDatagridviewThroughName();

            }
            catch (Exception)
            {
            }
        }

        private void comboRollNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboClass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comboSymbNo.SelectedIndex = -1;
                comboRegId.SelectedIndex = -1;
                LoadDatagridviewThroughName();

            }
            catch (Exception)
            {
            }
        }

        private void comboSec_TextChanged(object sender, EventArgs e)
        {

            try
            {
                comboSymbNo.SelectedIndex = -1;
                comboRegId.SelectedIndex = -1;
                LoadDatagridviewThroughName();

            }
            catch (Exception)
            {
            }
        }

        private void comboRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void yearFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    yearTo.Focus();
                    yearTo.SelectAll();

                }
            }
        }

        private void yearFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                yearFrom.BackColor = System.Drawing.Color.Red;
                yearFrom.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                yearFrom.BackColor = System.Drawing.Color.White;
                yearFrom.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void yearTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                yearTo.BackColor = System.Drawing.Color.Red;
                yearTo.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                yearTo.BackColor = System.Drawing.Color.White;
                yearTo.ForeColor = System.Drawing.Color.Black;
            }
        }
        protected void LoadDatagridviewThroughYear()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select regid, symbol, studName, streamName, className, fatherName, motherName, dobBS, municipal, wardNo, district, issuedate, gpa from certificateDetails where sessionFrom like '%" + yearFrom.Text + "%' and sessionTo like '%" + yearTo.Text + "%'", conn);
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
                    dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j].ItemArray[3].ToString();
                    dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j].ItemArray[4].ToString();
                    dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j].ItemArray[5].ToString();
                    dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j].ItemArray[6].ToString();
                    dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j].ItemArray[7].ToString();
                    dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j].ItemArray[8].ToString();
                    dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j].ItemArray[9].ToString();
                    dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j].ItemArray[10].ToString();
                    dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j].ItemArray[11].ToString();
                    dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j].ItemArray[12].ToString();
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

        private void comboName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yearFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDatagridviewThroughYear();
            }
            catch (Exception)
            {
            }
        }
    }
}

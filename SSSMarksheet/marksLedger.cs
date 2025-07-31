using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using System.Threading;

namespace SSSMarksheet
{
    public partial class marksLedger : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");
        OleDbConnection connect = new OleDbConnection(@"Provider=SQLOLEDB;Data Source=DESKTOP-SV6O88M\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=SSPI");
        //int RecordCount = 0;

        decimal creditForAllSubject = 0;

        public marksLedger()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
        protected void DataGridViewHeaderfill()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject from AddSubject where classes='" + comboClass.Text + "' and stream = '" + comboStream.Text + "' ORDER BY subject ASC", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                dataGridView1.ColumnCount = dt.Rows.Count * 3 + 8;
                int a = dt.Rows.Count * 3 + 3;
                int fetchcount = 0;
                for (int i = 3; i < dt.Rows.Count * 3 + 3; i += 3)
                {
                    dataGridView1.Columns[0].Name = "SNo";
                    dataGridView1.Columns[0].HeaderText = "SNo";
                    dataGridView1.Columns[1].Name = "Names";
                    dataGridView1.Columns[1].HeaderText = "Name";
                    dataGridView1.Columns[2].Name = "RollNo";
                    dataGridView1.Columns[2].HeaderText = "Roll";

                    dataGridView1.Columns[i + 1].Name = dt.Rows[fetchcount][0].ToString();
                    dataGridView1.Columns[i + 1].HeaderText = dt.Rows[fetchcount][0].ToString();
                    // dataGridView1.Columns[i + 1].Visible = false;

                    dataGridView1.Columns[a].Name = "Total";
                    dataGridView1.Columns[a].HeaderText = "Total";
                    dataGridView1.Columns[a + 1].Name = "Grade";
                    dataGridView1.Columns[a + 1].HeaderText = "GPA";
                    dataGridView1.Columns[a + 2].Name = "Percentage";
                    dataGridView1.Columns[a + 2].HeaderText = "%";
                    dataGridView1.Columns[a + 3].Name = "Position";
                    dataGridView1.Columns[a + 3].HeaderText = "Pos";
                    dataGridView1.Columns[a + 4].Name = "Attendance";
                    dataGridView1.Columns[a + 4].HeaderText = "Attd";

                    dataGridView1.Columns[0].Width = 35;
                    dataGridView1.Columns[1].Width = 200;
                    dataGridView1.Columns[2].Width = 35;
                    dataGridView1.Columns[a].Width = 50;
                    dataGridView1.Columns[a + 1].Width = 40;
                    dataGridView1.Columns[a + 2].Width = 40;
                    dataGridView1.Columns[a + 3].Width = 35;
                    dataGridView1.Columns[a + 4].Width = 35;
                    dataGridView1.Columns[i].Width = 35;
                    dataGridView1.Columns[i + 1].Width = 35;
                    dataGridView1.Columns[i + 2].Width = 35;

                    nonsortable();
                    fetchcount++;
                }
                conn.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void addPR_TH_TOTAL()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject from AddSubject where classes='" + comboClass.Text + "' and stream = '" + comboStream.Text + "' ORDER BY subject ASC", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            conn.Close();

            for (int k = 3; k < dt.Rows.Count * 3 + 3; k += 3)
            {
                //dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Cells[k].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[k + 1].Value = "PR".ToString();
                dataGridView1.Rows[0].Cells[k + 2].Value = "Tot".ToString();
            }
        }
        private String DataGridmerge(int a)
        {
            return dataGridView1.Columns[a].Name;
        }

        protected void DataGridViewCellfill()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select name,rollno from addStudents where sec='" + comboSec.Text + "' and stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' ORDER BY rollno ASC", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                int a = dt.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[1].Cells[1].Value = "Full Mark".ToString();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[2].Cells[1].Value = "Pass Mark".ToString();

                for (int i = 3; i < a + 3; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i - 3][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i - 3][1].ToString();
                }
                conn.Close();
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void SubjectPassFullMarks()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 3; j < dataGridView1.Columns.Count - 4; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select fullmark,passmark,pFullmark,pPassmark from AddSubjectMarks where subject='" + dataGridView1.Columns[j].HeaderText.ToString() + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[1].Cells[j - 1].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[1].Cells[j].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[2].Cells[j - 1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[2].Cells[j].Value = dt.Rows[i][3].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void ObtainedMarks()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int k = 3; k < dataGridView1.Rows.Count; k++)
                {
                    for (int j = 3; j < dataGridView1.Columns.Count - 4; j++)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select theory,practical,total from markEntry where subject='" + dataGridView1.Columns[j].HeaderText.ToString() + "'and terminal='" + comboExam.Text + "' and classes='" + comboClass.Text + "' and stream = '" + comboStream.Text + "' and sec = '" + comboSec.Text + "' and name='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "' and rollno='" + dataGridView1.Rows[k].Cells[2].Value.ToString() + "' ", conn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            dataGridView1.Rows[k].Cells[j - 1].Value = dt.Rows[i][0].ToString();
                            dataGridView1.Rows[k].Cells[j].Value = dt.Rows[i][1].ToString();
                            dataGridView1.Rows[k].Cells[j + 1].Value = dt.Rows[i][2].ToString();

                            dataGridView1.Rows[k].Cells[j + 1].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void nonsortable()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void marksLedger_Load(object sender, EventArgs e)
        {
            comboExam.Focus();
            //dataGridView1.Rows.Add();
        }

        private void total_OF_thPr()
        {
            for (int j = 3; j < dataGridView1.Columns.Count - 5; j += 3)
            {
                double Fth = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                double Fpr = Convert.ToDouble(dataGridView1.Rows[1].Cells[j + 1].Value);
                double Pth = Convert.ToDouble(dataGridView1.Rows[2].Cells[j].Value);
                double Ppr = Convert.ToDouble(dataGridView1.Rows[2].Cells[j + 1].Value);

                double Fulltotal = Fth + Fpr;
                double Passtotal = Pth + Ppr;
                dataGridView1.Rows[1].Cells[j + 2].Value = Fulltotal.ToString();
                dataGridView1.Rows[2].Cells[j + 2].Value = Passtotal.ToString();
                dataGridView1.Rows[1].Cells[j + 2].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                dataGridView1.Rows[2].Cells[j + 2].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                //cashBookRowsMarchTotals.Rows[1].DefaultCellStyle.Font = new Font(cashBookRowsMarchTotals.Font, FontStyle.Bold);

            }
        }
        private void total_OF_All()
        {
            double totalFullMarks = 0;
            double totalPassMarks = 0;

            int tot = dataGridView1.Columns.Count - 5;
            for (int j = 3; j < dataGridView1.Columns.Count - 5; j += 3)
            {
                double Fth = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value);
                double Fpr = Convert.ToDouble(dataGridView1.Rows[1].Cells[j + 1].Value);
                double Pth = Convert.ToDouble(dataGridView1.Rows[2].Cells[j].Value);
                double Ppr = Convert.ToDouble(dataGridView1.Rows[2].Cells[j + 1].Value);

                double Fulltotal = Fth + Fpr;
                double Passtotal = Pth + Ppr;
                totalFullMarks += Fulltotal;
                totalPassMarks += Passtotal;
            }
            dataGridView1.Rows[1].Cells[tot].Value = totalFullMarks.ToString();
            dataGridView1.Rows[2].Cells[tot].Value = totalPassMarks.ToString();
            dataGridView1.Rows[1].Cells[tot].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
            dataGridView1.Rows[2].Cells[tot].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
            totalFullMarkss.Text = totalFullMarks.ToString();
            totalPassMarkss.Text = totalPassMarks.ToString();
        }

        private void ObtainedMarksIndividual()
        {
            int tot = dataGridView1.Columns.Count - 5;
            for (int k = 3; k < dataGridView1.Rows.Count; k++)
            {
                double totalObtMarks = 0;
                for (int j = 3; j < dataGridView1.Columns.Count - 4; j += 3)
                {
                    double Fth = Convert.ToDouble(dataGridView1.Rows[k].Cells[j].Value);
                    double Fpr = Convert.ToDouble(dataGridView1.Rows[k].Cells[j + 1].Value);

                    double Fulltotal = Fth + Fpr;
                    totalObtMarks += Fulltotal;
                }

                dataGridView1.Rows[k].Cells[tot].Value = totalObtMarks.ToString();
                dataGridView1.Rows[k].Cells[tot].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                dataGridView1.Columns["RollNo"].Frozen = true;
                dataGridView1.Rows[2].Frozen = true;

            }

        }
        private void comboSec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows[e.RowIndex + 3].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
                //DatagridviewTotalcalculate();
            }
            catch (Exception)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataGridViewCellfill();
        }

        private void comboExam_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboSec.Focus();

                }
            }
        }

        private void comboSec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    buttGoGo.PerformClick();
                }
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            int count = 4;
            //int countPass = 0;
            //int countFail = 0;
            for (int i = 3; i < dataGridView1.Columns.Count - 5; i += 3)
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset = 5;
                int widthOffset = 33;
                int xOffset = 0;
                int yOffset = -2;

                //Index of Header column from where the merging will start.
                int columnIndex = i;

                //Number of Header columns to be merged.
                int columnCount = 3;

                //Get the position of the Header Cell.
                Rectangle headerCellRectangle = dataGridView1.GetCellDisplayRectangle(columnIndex, 0, true);

                //X coordinate of the merged Header Column.
                int xCord = headerCellRectangle.Location.X + xOffset;

                //Y coordinate of the merged Header Column.
                int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;

                //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
                int mergedHeaderWidth = dataGridView1.Columns[columnIndex].Width + dataGridView1.Columns[columnIndex + columnCount - 1].Width + widthOffset;

                //Generate the merged Header Column Rectangle.
                Rectangle mergedHeaderRect = new Rectangle(xCord + 1, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset - 10);

                //Draw the merged Header Column Rectangle.
                e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

                //Draw the merged Header Column Text.
                {
                    e.Graphics.DrawString(DataGridmerge(count), dataGridView1.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 20, yCord + 1);
                }
                /*{
                   e.Graphics.DrawString(DataGridmerge(countPass), dataGridView1.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 4, yCord + 44);
                }
                {
                    e.Graphics.DrawString(DataGridmerge(countFail), dataGridView1.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 4, yCord + 64);
                }*/
                count += 3;
                //countPass++;
                //countFail++;
            }

        }

        
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboNameSearch.SelectedIndex = -1;
            comboRollSearch.SelectedIndex = -1;
            comboGradeSearch.SelectedIndex = -1;

            comboNameSearch.Enabled = true;
            comboRollSearch.Enabled = true;
            comboGradeSearch.Enabled = true;
            dataGridView1.Rows.Clear();

        }

        private void comboNameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboRollSearch.Enabled = false;
            comboGradeSearch.Enabled = false;
            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                comboNameSearch.BackColor = System.Drawing.Color.Red;
                comboNameSearch.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                comboNameSearch.BackColor = System.Drawing.Color.White;
                comboNameSearch.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void comboRollSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboNameSearch.Enabled = false;
            comboGradeSearch.Enabled = false;
            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                comboRollSearch.BackColor = System.Drawing.Color.Red;
                comboRollSearch.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                comboRollSearch.BackColor = System.Drawing.Color.White;
                comboRollSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void comboGradeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboRollSearch.Enabled = false;
            comboNameSearch.Enabled = false;
        }

        private void comboNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboRollSearch.Enabled = false;
            comboGradeSearch.Enabled = false;
        }

        private void comboRollSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboNameSearch.Enabled = false;
            comboGradeSearch.Enabled = false;
        }

        private void comboGradeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboRollSearch.Enabled = false;
            comboNameSearch.Enabled = false;
        }

        private void comboNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    buttGoS.PerformClick();
                }
            }
        }

        private void comboRollSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    buttGoS.PerformClick();
                }
            }
        }

        private void comboGradeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    buttGoS.PerformClick();
                }
            }
        }

        private void txtrollno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
        private void fetchNameForSearch()
        {

            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select name from addStudents where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and sec ='" + comboSec.Text + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboNameSearch.DisplayMember = "Name";
                comboNameSearch.ValueMember = "Name";
                comboNameSearch.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboExam.Text == "")
            {
                MessageBox.Show("Exam Terminal cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboExam.Focus();
                return;
            }
            if (comboStream.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboStream.Focus();
                return;
            }
            if (comboClass.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboClass.Focus();
                return;
            }
            if (comboSec.Text == "")
            {
                MessageBox.Show("Section cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSec.Focus();
                return;
            }

            lblStatus.Text = "";
            lblStatus.Visible = false;
            dataGridView1.Rows.Clear();
            DataGridViewHeaderfill();
            //dataGridView1.Rows.Add();
            DataGridViewCellfill();
            SubjectPassFullMarks();
            addPR_TH_TOTAL();
            total_OF_thPr();
            total_OF_All();
            ObtainedMarks();
            ObtainedMarksIndividual();
            TotalSubjectCreditCalculation();
            TotalGPACalc();
            failColorChange();
            CalculateRankORPosition();
            TotalWorkingDaysAndPresent();
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttGoS_Click(object sender, EventArgs e)
        {
            if (comboExam.Text == "")
            {
                MessageBox.Show("Exam Terminal cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboExam.Focus();
                return;
            }
            if (comboStream.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboStream.Focus();
                return;
            }
            if (comboClass.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboClass.Focus();
                return;
            }
            if (comboSec.Text == "")
            {
                MessageBox.Show("Section cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSec.Focus();
                return;
            }

        }
        DataTable dtSales = new DataTable();
        private void comboNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            comboNameSearch.Enabled = true;
            comboRollSearch.Enabled = true;
            comboGradeSearch.Enabled = true;
            fetchNameForSearch();

        }
        private void TotalSubjectCreditCalculation()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                decimal creditCount = 0;
                creditForAllSubject = 0;
                for (int i = 3; i < dataGridView1.Columns.Count - 5; i += 3)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Columns[i + 1].HeaderText.ToString() + "' and classes='" + comboClass.Text + "' and stream ='" + comboStream.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        creditCount = decimal.Parse(dt.Rows[0]["credit"].ToString());
                    }
                    else
                    {
                        creditCount = 4;
                    }

                    creditForAllSubject += creditCount;

                    conn.Close();

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void TotalGPACalc()
        {
            decimal ObtainedMark = 0;
            decimal totalCreditIndividual = 0;
            decimal creditCount = 0;
            decimal CreditMultiply = 0;
            decimal fullMarks = 0;
            decimal PercTotal = 0;
            decimal PercIndi = 0;
            decimal PercCalculate = 0;

            //creditForAllSubject = 0;
            decimal finalGpa = 0;
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();

            try
            {
                for (int k = 3; k < dataGridView1.Rows.Count; k++)
                {
                    CreditMultiply = 0;

                    finalGpa = 0;
                    for (int j = 3; j < dataGridView1.Columns.Count - 5; j += 3)
                    {
                        ObtainedMark = 0;
                        totalCreditIndividual = 0;
                        creditCount = 0;
                        fullMarks = 0;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Columns[j + 1].HeaderText.ToString() + "' and classes='" + comboClass.Text + "' and stream ='" + comboStream.Text + "' ", conn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            creditCount = decimal.Parse(dt.Rows[0]["credit"].ToString());
                        }
                        else
                        {
                            creditCount = 4.0m;
                        }
                        conn.Close();

                        ObtainedMark = Convert.ToDecimal(dataGridView1.Rows[k].Cells[j + 2].Value);

                        fullMarks = Convert.ToDecimal(dataGridView1.Rows[1].Cells[j + 2].Value);

                        decimal div = ObtainedMark / fullMarks;
                        decimal percentage = div * 100;




                        if (percentage >= 1 && percentage < 20)
                        {
                            totalCreditIndividual = 0.8M;
                        }
                        else if (percentage >= 20 && percentage < 40)
                        {
                            totalCreditIndividual = 1.6M;
                        }
                        else if (percentage >= 40 && percentage < 50)
                        {
                            totalCreditIndividual = 2.0M;
                        }
                        else if (percentage >= 50 && percentage < 60)
                        {
                            totalCreditIndividual = 2.4M;
                        }
                        else if (percentage >= 60 && percentage < 70)
                        {
                            totalCreditIndividual = 2.8M;
                        }
                        else if (percentage >= 70 && percentage < 80)
                        {
                            totalCreditIndividual = 3.2M;
                        }
                        else if (percentage >= 80 && percentage < 90)
                        {
                            totalCreditIndividual = 3.6M;
                        }
                        else if (percentage >= 90 && percentage <= 100)
                        {
                            totalCreditIndividual = 4;
                        }
                        else
                        {
                            totalCreditIndividual = 0.0M;
                        }

                        CreditMultiply += (totalCreditIndividual * creditCount);
                    }

                    PercTotal = Convert.ToDecimal(dataGridView1.Rows[1].Cells[dataGridView1.Columns.Count - 5].Value);

                    PercIndi = Convert.ToDecimal(dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 5].Value);

                    PercCalculate = Math.Round(((PercIndi / PercTotal) * 100), 1);

                    dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 3].Value = PercCalculate.ToString();

                    finalGpa = Math.Round((CreditMultiply / creditForAllSubject), 1);

                    dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = finalGpa.ToString();
                    /*

                    if (finalGpa > 0.8M && finalGpa <= 1.6M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "E".ToString();
                    }
                    else if (finalGpa > 0.8M && finalGpa <= 1.6M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "D".ToString();
                    }
                    else if (finalGpa > 1.6M && finalGpa <= 2.0M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "C".ToString();
                    }
                    else if (finalGpa > 2.0M && finalGpa <= 2.4M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "C+".ToString();
                    }
                    else if (finalGpa > 2.4M && finalGpa <= 2.8M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "B".ToString();
                    }
                    else if (finalGpa > 2.8M && finalGpa <= 3.2M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "B+".ToString();
                    }
                    else if (finalGpa > 3.2M && finalGpa <= 3.6M)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "A".ToString();
                    }
                    else if (finalGpa > 3.6M && finalGpa <= 4)
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "A+".ToString();
                    }
                    
                    else
                    {
                        dataGridView1.Rows[k].Cells[dataGridView1.Columns.Count - 4].Value = "N".ToString();
                    }
                     * */

                }

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.StackTrace);

            }
        }


        public void DenseRank(Dictionary<int, double> data)
        {
            // Rank Vector 
            //Console.WriteLine("Dense Rank");
            var list = data.Values.Distinct().ToList();
            list.Sort((a, b) => b.CompareTo(a));

            int rank = 1;
            foreach (var value in list)
            {
                foreach (var k in data.Keys)
                {
                    if (data[k] == value)
                    {
                        if (dataGridView1.Rows[k + 3].Cells[dataGridView1.Columns.Count - 5].Style.ForeColor != Color.White)
                        {
                            for (int i = k+3 ; i < dataGridView1.Columns.Count; i++)
                            {
                                if (dataGridView1.Rows[k+3].Cells[i].Style.ForeColor == Color.Red)
                                {
                                    dataGridView1.Rows[k + 3].Cells[dataGridView1.Columns.Count - 5].Style.ForeColor = Color.White;
                                    break;
                                }
                                
                            }
                            if (dataGridView1.Rows[k + 3].Cells[dataGridView1.Columns.Count - 5].Style.ForeColor != Color.White)
                            {
                                dataGridView1.Rows[k + 3].Cells[dataGridView1.Columns.Count - 2].Value = rank.ToString();
                            }
                            
                        }
                        else
                        {

                            rank--;
                        }
                    }
                }
                rank++;
            }
            
        }

        // Driver code 
        public void CalculateRankORPosition()
        {
            try
            {
                double[] array = new double[dataGridView1.Rows.Count - 3];
                double[] arrayResult = new double[dataGridView1.Rows.Count - 3];
                Dictionary<int, double> wordDictionary = new Dictionary<int, double>();
                for (int i = 0; i < dataGridView1.Rows.Count - 3; i++)
                {
                    array[i] = Convert.ToDouble(dataGridView1.Rows[i + 3].Cells[dataGridView1.Columns.Count - 5].Value);
                    wordDictionary.Add(i, array[i]);
                }

                DenseRank(wordDictionary);
                
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.StackTrace);
            }
        }
        private void failColorChange()
        {
            string srt = "";
            int tot = dataGridView1.Columns.Count - 5;
            for (int i = 3; i < dataGridView1.Rows.Count; i++)
            {
                srt = "";
                for (int j = 5; j < dataGridView1.Columns.Count - 5; j += 3)
                {
                    double inputs = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                    double passMarks = Convert.ToDouble(dataGridView1.Rows[2].Cells[j].Value);
                    if (inputs < passMarks)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        srt = "Red";
                    }

                }
                if(srt=="Red")
                    dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 5].Style.ForeColor = Color.DarkBlue;

            }
            
        }
        protected void TotalWorkingDaysAndPresent()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string working="";
                
                for (int i = 3; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select distinct workingDays,present from Attendance where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and name = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and sec ='" + comboSec.Text + "' and rollno = '" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "' ", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        working = reader["workingDays"].ToString();
                        dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count-1].Value = reader["present"].ToString();

                        reader.Close();
                        conn.Close();
                    }
                }
                totWorkingDaysTxt.Text = working.ToString();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("Processing...{0}", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Thread.Sleep(100);
                lblStatus.Text = "Your Data has been successfully exported";
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Marks Ledger.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;

                backgroundWorker.RunWorkerAsync();
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format column D as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dataGridView1.ClearSelection();

                // Open the newly saved excel file
                // if (File.Exists(sfd.FileName))
                //  System.Diagnostics.Process.Start(sfd.FileName);
                lblStatus.Visible = true;
            }
        }
    }
}

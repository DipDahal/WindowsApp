using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using PagedList;
using System.Data.OleDb;
using SSSMarksheet.Properties;

namespace SSSMarksheet
{
    public partial class Marksheet : Form
    {
        public Marksheet()
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void comboExams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboStream.Focus();
                    comboStream.SelectAll();
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
                    comboClass.SelectAll();
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
                    comboSec.SelectAll();
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
                    comboName.Focus();
                    comboName.SelectAll();
                }
            }
        }

        private void comboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    button3.PerformClick();
                }
            }
        }

        private void comboroll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                button3.PerformClick();
            }
        }

        private void comboReg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                buttGo.PerformClick();
            }
        }

        private void comboExams_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                comboExams.BackColor = System.Drawing.Color.Red;
                comboExams.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                comboExams.BackColor = System.Drawing.Color.White;
                comboExams.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void comboroll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                comboroll.BackColor = System.Drawing.Color.Red;
                comboroll.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                comboroll.BackColor = System.Drawing.Color.White;
                comboroll.ForeColor = System.Drawing.Color.Black;
            }
        }
        protected void DataGridViewCellfill()
        {
            dataGridView1.Rows.Add();
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject from AddSubject where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' ORDER BY subject ASC", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                int a = dt.Rows.Count;
                dataGridView1.Rows[0].Cells[2].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[3].Value = "PR".ToString();

                dataGridView1.Rows[0].Cells[4].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[5].Value = "PR".ToString();

                dataGridView1.Rows[0].Cells[6].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[7].Value = "PR".ToString();

                dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                for (int i = 1; i <= a; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i - 1][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                }
                conn.Close();
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

        protected void SubjectPassFullMarks()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 1; j <= dataGridView1.Rows.Count; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select fullmark,pFullmark,passmark,pPassmark from AddSubjectMarks where subject='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comboClass.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[j].Cells[2].Value = dt.Rows[0].ItemArray[0].ToString();
                        dataGridView1.Rows[j].Cells[3].Value = dt.Rows[0].ItemArray[1].ToString();
                        dataGridView1.Rows[j].Cells[4].Value = dt.Rows[0].ItemArray[2].ToString();
                        dataGridView1.Rows[j].Cells[5].Value = dt.Rows[0].ItemArray[3].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ee.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }


        protected void ObtainedMarksByName()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 1; j <= dataGridView1.Rows.Count; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select theory,practical,total from markEntry where subject='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comboClass.Text + "' and name = '" + comboName.Text + "' and sec ='" + comboSec.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                   // for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[j].Cells[6].Value = dt.Rows[0].ItemArray[0].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt.Rows[0].ItemArray[1].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt.Rows[0].ItemArray[2].ToString();
                    }
                    dataGridView1.Rows[j].Cells[8].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                    conn.Close();
                }
            }
            catch (Exception )
            {
               //MessageBox.Show(ee.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void ObtainedMarksByRollNo()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 1; j <= dataGridView1.Rows.Count; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select theory,practical,total from markEntry where subject='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comboClass.Text + "' and rollno = '" + comboroll.Text + "' and sec ='" + comboSec.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[j].Cells[6].Value = dt.Rows[0].ItemArray[0].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt.Rows[0].ItemArray[1].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt.Rows[0].ItemArray[2].ToString();
                    }
                    dataGridView1.Rows[j].Cells[8].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                    conn.Close();
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ee.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows[e.RowIndex + 1].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
                //DatagridviewTotalcalculate();
            }
            catch (Exception)
            {

            }
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataGridViewCellfill();
            SubjectPassFullMarks();

            comboName.SelectedIndex = -1;
            comboroll.SelectedIndex = -1;

            txtNameNew.Text = "";
            txxtrollNew.Text = "";
            if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
            {
                fetchName();
                fetchRollno();
                comboroll.Visible = false;
                txxtrollNew.Visible = true;
            }
        }

        private void nonsortable()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);
            }
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //Offsets to adjust the position of the merged Header.
            nonsortable();
            int heightOffset = 5;
            int widthOffset = -1;
            int widthOffset1 = -41;
            int widthOffset2 = 8;
            int xOffset = 0;
            int yOffset = 2;

            //Index of Header column from where the merging will start.
            int columnIndex = 2;
            int columnIndex1 = 4;
            int columnIndex2 = 6;

            //Number of Header columns to be merged.
            int columnCount = 3;

            //Get the position of the Header Cell.
            Rectangle headerCellRectangle = dataGridView1.GetCellDisplayRectangle(columnIndex, 0, true);
            Rectangle headerCellRectangle1 = dataGridView1.GetCellDisplayRectangle(columnIndex1, 0, true);
            Rectangle headerCellRectangle2 = dataGridView1.GetCellDisplayRectangle(columnIndex2, 0, true);

            //X coordinate of the merged Header Column.
            int xCord = headerCellRectangle.Location.X + xOffset;
            int xCord1 = headerCellRectangle1.Location.X + xOffset;
            int xCord2 = headerCellRectangle2.Location.X + xOffset;

            //Y coordinate of the merged Header Column.
            int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;
            int yCord1 = headerCellRectangle1.Location.Y - headerCellRectangle1.Height + yOffset;
            int yCord2 = headerCellRectangle2.Location.Y - headerCellRectangle2.Height + yOffset;

            //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
            int mergedHeaderWidth = dataGridView1.Columns[columnIndex].Width + dataGridView1.Columns[columnIndex + columnCount - 1].Width + widthOffset;

            int mergedHeaderWidth1 = dataGridView1.Columns[columnIndex1].Width + dataGridView1.Columns[columnIndex1 + columnCount - 1].Width + widthOffset1;

            int mergedHeaderWidth2 = dataGridView1.Columns[columnIndex2].Width + dataGridView1.Columns[columnIndex2 + columnCount - 1].Width + widthOffset2;

            //Generate the merged Header Column Rectangle.
            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset - 8);
            Rectangle mergedHeaderRect1 = new Rectangle(xCord1, yCord1, mergedHeaderWidth1, headerCellRectangle1.Height + heightOffset - 8);
            Rectangle mergedHeaderRect2 = new Rectangle(xCord2, yCord2, mergedHeaderWidth2, headerCellRectangle2.Height + heightOffset - 8);

            //Draw the merged Header Column Rectangle.
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect1);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect2);

            //Draw the merged Header Column Text.
            {
                e.Graphics.DrawString(" Full Marks", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, xCord + 40, yCord + 2);
                e.Graphics.DrawString(" Pass Marks", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, xCord1 + 45, yCord1 + 2);
                e.Graphics.DrawString("Obtained Marks", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, xCord2 + 60, yCord2 + 2);
            }
        }

        
         protected void FillTextrollNo()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select rollno from addStudents where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and name = '" + comboName.Text + "' and sec ='" + comboSec.Text + "' ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    txxtrollNew.Text = reader["rollno"].ToString();

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

         protected void FillTextName()
         {
             string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
             SqlConnection conn = new SqlConnection(conString);
             try
             {
                 conn.Open();
                 SqlCommand cmd = new SqlCommand("select name from addStudents where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and rollno = '" + comboroll.Text + "' and sec ='" + comboSec.Text + "' ", conn);

                 SqlDataReader reader = cmd.ExecuteReader();

                 if (reader.Read())
                 {

                     txtNameNew.Text = reader["name"].ToString();

                     reader.Close();
                     conn.Close();
                 }
             }
             catch (Exception ex)
             {
                // MessageBox.Show(ex.StackTrace);
             }
             finally
             {
                 conn.Close();
                 conn.Dispose();
             }
         }
        private void comboName_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void comboName_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void fetchName()
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
                comboName.DisplayMember = "Name";
                comboName.ValueMember = "Name";
                comboName.DataSource = ds.Tables[0];
            }
            catch (Exception )
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void fetchRollno()
        {
            comboroll.Visible = true;
            txxtrollNew.Visible = false;
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select distinct rollno from addStudents where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and sec ='" + comboSec.Text + "' order by rollno ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    comboroll.DisplayMember = "rollno";
                    comboroll.ValueMember = "rollno";
                    comboroll.DataSource = ds.Tables[0];
                    conn.Close();
                
            }
            catch (Exception )
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void comboSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboName.SelectedIndex = -1;
            comboroll.SelectedIndex = -1;

            txtNameNew.Text = "";
            txxtrollNew.Text = "";

            if (radName.Checked == true)
            {
                if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
                {
                    fetchName();
                    fetchRollno();
                    comboName.Visible = true;
                    txxtrollNew.Visible = true;

                    comboroll.Visible = false;
                    txtNameNew.Visible = false;
                }
            }

            if (radRoll.Checked == true)
            {
                if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
                {
                    fetchName();
                    fetchRollno();
                    comboName.Visible = false;
                    txxtrollNew.Visible = false;

                    comboroll.Visible = true;
                    txtNameNew.Visible = true;
                }
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            resultttt.Text = "-----";
            percentagetxt.Text = "-----";
            txxtrollNew.Text = "";
            AttendanceTxt.Text = "-----";
            txtNameNew.Text = "";
            txtTotalFullMarks.Text = "-----";
            totWorkingDaysTxt.Text = "-----";
            totalGPAtxt.Text = "-----";
            totalMarkssstxt.Text = "-----";
            totalCredittxt.Text = "-----";
            comRegName.Visible = false;
            //comboname
            if (comboName.Text != "")
            {
                button16.Visible = true;
                buttByRoll.Visible = false;
                buttByReg.Visible = false;
                dataGridView1.Rows.Clear();
                DataGridViewCellfill();
                SubjectPassFullMarks();
                FillTextrollNo();
                ObtainedMarksByName();
                datagridviewZero();
                gpaCalculation();
                //HighestGpaCalculationForRollAndName();
                totalCreditHourCalculation();
                totalMarksCalculation();
                TotalGPACalculationForNameRollNo();
                ResultCalculation();
                TotalWorkingDaysAndPresentForName();
                avoidSpaceDatagridView();
                datagridviewZeroForPractical();
            }
            //comboRoll
            else if (comboroll.Text!="")
            {
                button16.Visible = false;
                buttByRoll.Visible = true;
                buttByReg.Visible = false;
                //comboroll.SelectedIndex = -1;
                dataGridView1.Rows.Clear();
                DataGridViewCellfill();
                SubjectPassFullMarks();
                FillTextName();
                ObtainedMarksByRollNo();
                datagridviewZero();
                gpaCalculation();
                //HighestGpaCalculationForRollAndName();
                totalCreditHourCalculation();
                totalMarksCalculation();
                TotalGPACalculationForNameRollNo();
                ResultCalculation();
                TotalWorkingDaysAndPresentForRoll();
                avoidSpaceDatagridView();
                datagridviewZeroForPractical();

            }


        }

        private void comborollNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
            {
                //comboroll.SelectedIndex = -1;
                dataGridView1.Rows.Clear();
                DataGridViewCellfill();
                SubjectPassFullMarks();
                ObtainedMarksByRollNo();
                FillTextName();
            }
        }

        private void comboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboName.SelectedIndex = -1;
            comboroll.SelectedIndex = -1;

            txtNameNew.Text = "";
            txxtrollNew.Text = "";
            if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
            {
                fetchName();
                fetchRollno();
                comboroll.Visible = false;
                txxtrollNew.Visible = true;
            }
        }

        private void Marksheet_Load(object sender, EventArgs e)
        {
            comRegClass.Visible = false;
            comRegStream.Visible = false;
            comRegsec.Visible = false;
            comRegRoll.Visible = false;
            comRegName.Visible = false;

            txtNameNew.Visible = false;
            txxtrollNew.Visible = true;
            comboName.Visible = true;
            comboroll.Visible = false;
            radName.Checked = true;
            radRoll.Checked = false;
            radreg.Checked = false;

            comboReg.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            resultttt.Text = "-----";
            percentagetxt.Text = "-----";
            txxtrollNew.Text = "";
            AttendanceTxt.Text = "-----";
            txtNameNew.Text = "";
            txtTotalFullMarks.Text = "-----";
            totWorkingDaysTxt.Text = "-----";
            totalGPAtxt.Text = "-----";
            totalMarkssstxt.Text = "-----";
            totalCredittxt.Text = "-----";

            comRegClass.Visible = false;
            comRegStream.Visible = false;
            comRegsec.Visible = false;
            comRegRoll.Visible = false;
            comRegName.Visible = false;
            
            radName.Checked = true;
            radRoll.Checked = false;
            radreg.Checked = false;

            txtNameNew.Visible = false;
            txxtrollNew.Visible = true;
            comboName.Visible = true;
            comboroll.Visible = false;

            comboName.Enabled = true;
            comboStream.Enabled = true;
            comboClass.Enabled = true;
            comboroll.Enabled = true;
            comboSec.Enabled = true;
            txtNameNew.Enabled = true;
            txxtrollNew.Enabled = true;

            comboReg.Enabled = false;

            comboroll.SelectedIndex = -1;
            comboName.SelectedIndex = -1;
            comboReg.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            resultttt.Text = "-----";
            percentagetxt.Text = "-----";
            txxtrollNew.Text = "";
            AttendanceTxt.Text = "-----";
            txtNameNew.Text = "";
            txtTotalFullMarks.Text = "-----";
            totWorkingDaysTxt.Text = "-----";
            totalGPAtxt.Text = "-----";
            totalMarkssstxt.Text = "-----";
            totalCredittxt.Text = "-----";

            comRegClass.Visible = false;
            comRegStream.Visible = false;
            comRegsec.Visible = false;
            comRegRoll.Visible = false;
            comRegName.Visible = false;
            
            radName.Checked = false;
            radRoll.Checked = true;
            radreg.Checked = false;

            txtNameNew.Visible = true;
            txxtrollNew.Visible = false;
            comboName.Visible = false;
            comboroll.Visible = true;

            comboName.Enabled = true;
            comboStream.Enabled = true;
            comboClass.Enabled = true;
            comboroll.Enabled = true;
            comboSec.Enabled = true;
            txtNameNew.Enabled = true;
            txxtrollNew.Enabled = true;

            comboReg.Enabled = false;
            comboroll.SelectedIndex = -1;
            comboReg.SelectedIndex = -1;
            comboName.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            resultttt.Text = "-----";
            percentagetxt.Text = "-----";
            txxtrollNew.Text = "";
            AttendanceTxt.Text = "-----";
            txtNameNew.Text = "";
            txtTotalFullMarks.Text = "-----";
            totWorkingDaysTxt.Text = "-----";
            totalGPAtxt.Text = "-----";
            totalMarkssstxt.Text = "-----";
            totalCredittxt.Text = "-----";

            comRegClass.Visible = true;
            comRegStream.Visible = true;
            comRegsec.Visible = true;
            comRegRoll.Visible = true;
            comRegName.Visible = true;

            radName.Checked = false;
            radRoll.Checked = false;
            radreg.Checked = true;

            comboName.Enabled = false;
            comboStream.Enabled = false;
            comboClass.Enabled = false;
            comboroll.Enabled = false;
            comboSec.Enabled = false;
            txtNameNew.Enabled = false;
            txxtrollNew.Enabled = false;

            comboName.SelectedIndex = -1;
            comboStream.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboroll.SelectedIndex = -1;
            comboSec.SelectedIndex = -1;
            txtNameNew.Text = "";
            txxtrollNew.Text = "";

            comboReg.Enabled = true;

            fetchRegistrationNumber();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            

        }

        private void comboroll_SelectedValueChanged(object sender, EventArgs e)
        {
            ObtainedMarksByRollNo();
        }

        private void comboExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboName.SelectedIndex = -1;
            comboroll.SelectedIndex = -1;

            txtNameNew.Text = "";
            txxtrollNew.Text = "";
            if (comboExams.Text != "" && comboStream.Text != "" && comboClass.Text != "" && comboSec.Text != "")
            {
                fetchName();
                fetchRollno();
                comboroll.Visible = false;
                txxtrollNew.Visible = true;
            }
        }
        protected void fetchRegistrationNumber()
        {
            comboroll.Visible = true;
            txxtrollNew.Visible = false;
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct regid from addStudents order by regid ", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboReg.DisplayMember = "regid";
                comboReg.ValueMember = "regid";
                comboReg.DataSource = ds.Tables[0];
                conn.Close();

            }
            catch (Exception )
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void FillAllFromRegistration()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select stream,classes,sec,name,rollno from addStudents where regid='" + comboReg.Text + "' ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    comRegStream.Text = reader["stream"].ToString();
                    comRegClass.Text = reader["classes"].ToString();
                    comRegsec.Text = reader["sec"].ToString();
                    comRegName.Text = reader["name"].ToString();
                    comRegRoll.Text = reader["rollno"].ToString();

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void DataGridViewCellfillForRegistration()
        {
            dataGridView1.Rows.Add();
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject from AddSubject where stream='" + comRegStream.Text + "' and classes='" + comRegClass.Text + "' ORDER BY subject ASC", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                int a = dt.Rows.Count;
                dataGridView1.Rows[0].Cells[2].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[3].Value = "PR".ToString();

                dataGridView1.Rows[0].Cells[4].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[5].Value = "PR".ToString();

                dataGridView1.Rows[0].Cells[6].Value = "TH".ToString();
                dataGridView1.Rows[0].Cells[7].Value = "PR".ToString();

                dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                for (int i = 1; i <= a; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i - 1][0].ToString();

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void SubjectPassFullMarksForRegistration()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 1; j <= dataGridView1.Rows.Count; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select fullmark,passmark,pFullmark,pPassmark from AddSubjectMarks where subject='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comRegClass.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[j].Cells[2].Value = dt.Rows[0].ItemArray[0].ToString();
                        dataGridView1.Rows[j].Cells[3].Value = dt.Rows[0].ItemArray[2].ToString();
                        dataGridView1.Rows[j].Cells[4].Value = dt.Rows[0].ItemArray[1].ToString();
                        dataGridView1.Rows[j].Cells[5].Value = dt.Rows[0].ItemArray[3].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception )
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void comboReg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboReg_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void buttGo_Click(object sender, EventArgs e)
        {
            resultttt.Text = "";
            comRegClass.Text = "";
            comRegStream.Text = "";
            comRegsec.Text = "";
            comRegRoll.Text = "";
            comRegName.Text = "";

            resultttt.Text = "-----";
            percentagetxt.Text = "-----";
            txxtrollNew.Text = "";
            AttendanceTxt.Text = "-----";
            txtNameNew.Text = "";
            txtTotalFullMarks.Text = "-----";
            totWorkingDaysTxt.Text = "-----";
            totalGPAtxt.Text = "-----";
            totalMarkssstxt.Text = "-----";
            totalCredittxt.Text = "-----";

            button16.Visible = false;
            buttByRoll.Visible = false;
            buttByReg.Visible = true;

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            FillAllFromRegistration();
            if (comboExams.Text != "" && comRegStream.Text != "" && comRegClass.Text != "" && comRegsec.Text != "")
            {
                dataGridView1.Rows.Clear();
                DataGridViewCellfillForRegistration();
                SubjectPassFullMarksForRegistration();
                ObtainedMarksByRollNoInRegistration();
                datagridviewZero();
                gpaCalculation();
                //HighestGpaCalculationForReg();
                totalCreditHourCalculationForReg();
                totalMarksCalculation();
                TotalGPACalculationForReg();
                ResultCalculation();
                TotalWorkingDaysAndPresentForReg();
                avoidSpaceDatagridView();
                datagridviewZeroForPractical();

            }
        }

        protected void ObtainedMarksByRollNoInRegistration()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int j = 1; j <= dataGridView1.Rows.Count; j++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select theory,practical,total from markEntry where subject='" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comRegClass.Text + "' and rollno = '" + comRegRoll.Text + "' and sec ='" + comRegsec.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows[j].Cells[6].Value = dt.Rows[0].ItemArray[0].ToString();
                        dataGridView1.Rows[j].Cells[7].Value = dt.Rows[0].ItemArray[1].ToString();
                        dataGridView1.Rows[j].Cells[8].Value = dt.Rows[0].ItemArray[2].ToString();
                    }
                    dataGridView1.Rows[j].Cells[8].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                    conn.Close();
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ee.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void comboroll_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTextName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gpaCalculation()
        {
            try
            {
                decimal TotalfullMarks= 0;
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    decimal theoryFull = 0;
                    decimal practicalFull = 0;
                    decimal theoryObt = 0;
                    decimal practicalObt = 0;
                    decimal fullMarks = 0;
                    decimal obtMarks = 0;

                    if (dataGridView1.Rows[i].Cells[2].Value != null || dataGridView1.Rows[i].Cells[2].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        theoryFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value != null || dataGridView1.Rows[i].Cells[4].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                    {
                        practicalFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[6].Value != null || dataGridView1.Rows[i].Cells[6].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[6].Value.ToString()))
                    {
                        theoryObt = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[7].Value != null || dataGridView1.Rows[i].Cells[7].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[7].Value.ToString()))
                    {
                        practicalObt = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                    }

                    fullMarks = theoryFull + practicalFull;
                    TotalfullMarks += fullMarks;
                    obtMarks = theoryObt + practicalObt;

                    decimal div =obtMarks / fullMarks;
                    decimal percentage = (div*100);

                    if (percentage >= 1 && percentage < 20)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "E".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "0.8".ToString();
                    }
                    else if (percentage >= 20 && percentage < 40)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "D".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "1.6".ToString();
                    }
                    else if (percentage >= 40 && percentage < 50)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "C".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "2.0".ToString();
                    }
                    else if (percentage >= 50 && percentage < 60)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "C+".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "2.4".ToString();
                    }
                    else if (percentage >= 60 && percentage < 70)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "B".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "2.8".ToString();
                    }
                    else if (percentage >= 70 && percentage < 80)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "B+".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "3.2".ToString();
                    }
                    else if (percentage >= 80 && percentage < 90)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "A".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "3.6".ToString();
                    }
                    else if (percentage >= 90 && percentage <= 100)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "A+".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "4".ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[10].Value = "N".ToString();
                        dataGridView1.Rows[i].Cells[9].Value = "0.0".ToString();
                    }
                    dataGridView1.Rows[i].Cells[10].Style.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
                }
                txtTotalFullMarks.Text = TotalfullMarks.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void HighestGpaCalculationForReg()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct MAX(total) as total from markEntry where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comRegClass.Text + "' and sec ='" + comRegsec.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    decimal theoryFull = 0;
                    decimal practicalFull = 0;
                    decimal fullMarks = 0;
                    decimal obtMarks =decimal.Parse(dt.Rows[0]["total"].ToString());

                    conn.Close();

                    if (dataGridView1.Rows[i].Cells[2].Value != null || dataGridView1.Rows[i].Cells[2].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        theoryFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value != null || dataGridView1.Rows[i].Cells[4].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                    {
                        practicalFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    }

                    fullMarks = theoryFull + practicalFull;

                    decimal div = obtMarks / fullMarks;
                    decimal percentage = div * 100;

                    if (percentage >= 1 && percentage < 20)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "E".ToString();
                    }
                    else if (percentage >= 20 && percentage < 40)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "D".ToString();
                    }
                    else if (percentage >= 40 && percentage < 50)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "C".ToString();
                    }
                    else if (percentage >= 50 && percentage < 60)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "C+".ToString();
                    }
                    else if (percentage >= 60 && percentage < 70)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "B".ToString();
                    }
                    else if (percentage >= 70 && percentage < 80)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "B+".ToString();
                    }
                    else if (percentage >= 80 && percentage < 90)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "A".ToString();
                    }
                    else if (percentage >= 90 && percentage <= 100)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "A+".ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "N".ToString();
                    }
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
        
        private void datagridviewZero()
        {
            for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 2; j < dataGridView1.Columns.Count - 4; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null ||dataGridView1.Rows[i].Cells[j].Value == DBNull.Value ||String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[j].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }
        private void datagridviewZeroForPractical()
        {
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count - 2; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "0")
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "-".ToString();
                    }
                }
            }
        }
        private void HighestGpaCalculationForRollAndName()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct MAX(total) as total from markEntry where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and terminal='" + comboExams.Text + "' and classes='" + comboClass.Text + "' and sec ='" + comboSec.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    
                    decimal theoryFull = 0;
                    decimal practicalFull = 0;
                    decimal fullMarks = 0;
                    decimal obtMarks = decimal.Parse(dt.Rows[0]["total"].ToString());

                    conn.Close();

                    if (dataGridView1.Rows[i].Cells[2].Value != null || dataGridView1.Rows[i].Cells[2].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        theoryFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value != null || dataGridView1.Rows[i].Cells[4].Value != DBNull.Value || !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                    {
                        practicalFull = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    }

                    fullMarks = theoryFull + practicalFull;

                    decimal div = obtMarks / fullMarks;
                    decimal percentage = div * 100;

                    if (percentage >= 1 && percentage < 20)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "E".ToString();
                    }
                    else if (percentage >= 20 && percentage < 40)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "D".ToString();
                    }
                    else if (percentage >= 40 && percentage < 50)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "C".ToString();
                    }
                    else if (percentage >= 50 && percentage < 60)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "C+".ToString();
                    }
                    else if (percentage >= 60 && percentage < 70)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "B".ToString();
                    }
                    else if (percentage >= 70 && percentage < 80)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "B+".ToString();
                    }
                    else if (percentage >= 80 && percentage < 90)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "A".ToString();
                    }
                    else if (percentage >= 90 && percentage <= 100)
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "A+".ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[11].Value = "N".ToString();
                    }
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

        private void totalCreditHourCalculation()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                decimal creditCount = 0;
                decimal totalCredit = 0;
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and classes='" + comboClass.Text + "' and stream ='" + comboStream.Text + "' ", conn);
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

                    totalCredit += creditCount;
                    conn.Close();

                }
                totalCredittxt.Text = totalCredit.ToString();

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
        private void totalCreditHourCalculationForReg()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                decimal creditCount = 0;
                decimal totalCredit = 0;
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and classes='" + comRegClass.Text + "' and stream ='" + comRegStream.Text + "' ", conn);
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

                    totalCredit += creditCount;
                    conn.Close();

                }
                totalCredittxt.Text = totalCredit.ToString();

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
        private void totalMarksCalculation()
        {
            try
            {
                decimal markssss = 0;
                decimal totalMarksssss = 0;
                decimal percent = 0;
                decimal totalFull = 0;
                totalFull = Convert.ToDecimal(txtTotalFullMarks.Text);

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {

                    markssss = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    totalMarksssss += markssss;
                }
                percent = Math.Round(((totalMarksssss / totalFull) * 100),2);

                percentagetxt.Text = percent + "%".ToString();
                totalMarkssstxt.Text = totalMarksssss.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void TotalGPACalculationForReg()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                decimal creditCount = 0;
                decimal CreditIndividual = 0;
                decimal CreditMultiply = 0;
                decimal creditHoursPlus = 0;
                decimal creditHoursMultiplyPlus = 0;
                decimal finalGpa = 0;

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and classes='" + comRegClass.Text + "' and stream ='" + comRegStream.Text + "' ", conn);
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
                    creditHoursPlus += creditCount;
                    CreditIndividual = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    CreditMultiply = CreditIndividual * creditCount;
                    creditHoursMultiplyPlus += CreditMultiply;
                    
                    conn.Close();

                }
                finalGpa = Math.Round((creditHoursMultiplyPlus / creditHoursPlus),2);

                totalGPAtxt.Text = finalGpa.ToString();
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
        private void TotalGPACalculationForNameRollNo()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                decimal creditCount = 0;
                decimal CreditIndividual = 0;
                decimal CreditMultiply = 0;
                decimal creditHoursPlus = 0;
                decimal creditHoursMultiplyPlus = 0;
                decimal finalGpa = 0;

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT distinct credit as credit from creditHour where subject='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and classes='" + comboClass.Text + "' and stream ='" + comboStream.Text + "' ", conn);
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
                    creditHoursPlus += creditCount;
                    CreditIndividual = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    CreditMultiply = CreditIndividual * creditCount;
                    creditHoursMultiplyPlus += CreditMultiply;

                    conn.Close();

                }
                finalGpa = Math.Round((creditHoursMultiplyPlus / creditHoursPlus), 1);

                totalGPAtxt.Text = finalGpa.ToString();
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
        private void ResultCalculation()
        {
            try
            {
                
                    //Note:  dont be confused with percentage below, it is just for easyness actually it is for result
                    decimal percentage = Convert.ToDecimal(totalGPAtxt.Text);
                    if (percentage > 0.0M && percentage <= 0.8M)
                    {
                        resultttt.Text = "E".ToString();
                    }
                    else if (percentage > 0.8M && percentage <= 1.6M)
                    {
                        resultttt.Text = "D".ToString();
                    }
                    else if (percentage > 1.6M && percentage <= 2.0M)
                    {
                        resultttt.Text = "C".ToString();
                    }
                    else if (percentage > 2.0M && percentage <= 2.4M)
                    {
                        resultttt.Text = "C+".ToString();
                    }
                    else if (percentage > 2.4M && percentage <= 2.8M)
                    {
                        resultttt.Text = "B".ToString();
                    }
                    else if (percentage > 2.8M && percentage <= 3.2M)
                    {
                        resultttt.Text = "B+".ToString();
                    }
                    else if (percentage > 3.2M && percentage < 3.6M)
                    {
                        resultttt.Text = "A".ToString();
                    }
                    else if (percentage > 3.6M && percentage <= 4)
                    {
                        resultttt.Text = "A+".ToString();
                    }
                    else
                    {
                        resultttt.Text = "N".ToString();
                    }
                    
            }
            catch (Exception)
            {
            }
        }

        private void comboReg_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FillTextrollNo();
        }
        protected void TotalWorkingDaysAndPresentForName()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct workingDays,present from Attendance where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and name = '" + comboName.Text + "' and sec ='" + comboSec.Text + "' and rollno = '" + txxtrollNew.Text + "' ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    totWorkingDaysTxt.Text = reader["workingDays"].ToString();
                    AttendanceTxt.Text = reader["present"].ToString();

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void TotalWorkingDaysAndPresentForRoll()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct workingDays,present from Attendance where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and name = '" + txtNameNew.Text + "' and sec ='" + comboSec.Text + "' and rollno = '" + comboroll.Text + "' ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    totWorkingDaysTxt.Text = reader["workingDays"].ToString();
                    AttendanceTxt.Text = reader["present"].ToString();

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void TotalWorkingDaysAndPresentForReg()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct workingDays,present from Attendance where stream='" + comRegStream.Text + "' and classes='" + comRegClass.Text + "' and name = '" + comRegName.Text + "' and sec ='" + comRegsec.Text + "' and rollno = '" + comRegRoll.Text + "' ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    totWorkingDaysTxt.Text = reader["workingDays"].ToString();
                    AttendanceTxt.Text = reader["present"].ToString();

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int rInG = 315;
            int cou = dataGridView1.Rows.Count;
            switch (cou)
            {
                case 1:
                    rInG += 40 * cou;
                    break;
                case 2:
                    rInG += 40 * cou;
                    break;
                case 3:
                    rInG += 40 * cou;
                    break;
                case 4:
                    rInG += 40 * cou;
                    break;
                case 5:
                    rInG += 40 * cou;
                    break;
                case 6:
                    rInG += 40 * cou;
                    break;
                case 7:
                    rInG += 40 * cou;
                    break;
                case 8:
                    rInG += 40 * cou;
                    break;
                case 9:
                    rInG += 40 * cou;
                    break;
                case 10:
                    rInG += 40 * cou;
                    break;
                case 11:
                    rInG += 40 * cou;
                    break;
                case 12:
                    rInG += 40 * cou;
                    break;
                case 13:
                    rInG += 40 * cou;
                    break;
                case 14:
                    rInG += 40 * cou;
                    break;
                default:
                    rInG = 860;
                    break;
            }

            Image image = Resources.head;
            e.Graphics.DrawImage(image, 0, 0, 900, 1300);
            e.Graphics.DrawString("PROGRESS REPORT", new Font("Cambria", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(310, 115));

            e.Graphics.DrawString(comboExams.Text.Trim(), new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(300, 150));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 190), new Point(833, 190));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 190), new Point(10, 287));

            e.Graphics.DrawString("Name : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 210));
            e.Graphics.DrawString(comboName.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 210));

            e.Graphics.DrawString("................................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 215));


            e.Graphics.DrawString("Stream : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 210));
            e.Graphics.DrawString(comboStream.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 210));
            e.Graphics.DrawString("......................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(530, 215));


            e.Graphics.DrawString("Class : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 240));
            e.Graphics.DrawString(comboClass.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 240));

            e.Graphics.DrawString("...................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 245));

            e.Graphics.DrawString("Sec : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(300, 240));
            e.Graphics.DrawString(comboSec.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(370, 240));
            e.Graphics.DrawString("..........................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 245));

            e.Graphics.DrawString("Roll No : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(520, 240));
            e.Graphics.DrawString(txxtrollNew.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(610, 240));
            e.Graphics.DrawString("........................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 245));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 285), new Point(833, 285));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(833, 190), new Point(833, 287));

            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(833, 295));

            e.Graphics.DrawString("S.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 310));
            e.Graphics.DrawString("No.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 330));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(50, 295), new Point(50, rInG));

            e.Graphics.DrawString("Subject", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(80, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 295), new Point(205, rInG));

            e.Graphics.DrawString("Full Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(235, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(345, 295), new Point(345, rInG));

            //for merge like for three columns
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 335), new Point(595, 335));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(225, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(275, 335), new Point(275, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(295, 340));

            e.Graphics.DrawString("Pass Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(465, 295), new Point(465, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(355, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 335), new Point(405, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(415, 340));

            e.Graphics.DrawString("Obt Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(490, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(595, 295), new Point(595, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(480, 340));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(530, 335), new Point(530, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 340));

            e.Graphics.DrawString("Total", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(660, 295), new Point(660, rInG));

            e.Graphics.DrawString("GPA", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(665, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(715, 295), new Point(715, rInG));

            e.Graphics.DrawString("Grade", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(720, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(775, 295), new Point(775, rInG));

            //draw horizontal line (datgridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 370), new Point(833, 370));
            //draw vertical line (left border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(10, rInG));
            //draw vertical line (right border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(833, 295), new Point(833, rInG));
            //draw horizontal line(bottom border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, rInG), new Point(833, rInG));

            int yPos = 380;
            int xPos = 20;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                yPos = 380;
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {
                    switch (i)
                    {
                        case 1:
                            xPos = 55;
                            break;
                        case 2:
                            xPos = 210;
                            break;
                        case 3:
                            xPos = 285;
                            break;
                        case 4:
                            xPos = 355;
                            break;
                        case 5:
                            xPos = 415;
                            break;
                        case 6:
                            xPos = 475;
                            break;
                        case 7:
                            xPos = 545;
                            break;
                        case 8:
                            xPos = 605;
                            break;
                        case 9:
                            xPos = 670;
                            break;
                        case 10:
                            xPos = 725;
                            break;
                        case 11:
                            xPos = 785;
                            break;
                    }
                    e.Graphics.DrawString(dataGridView1.Rows[j].Cells[i].Value.ToString().Trim(), new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(xPos, yPos));

                    yPos += 35;

                    
                }
            }
            //after datagridview horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 860), new Point(833, 860));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(250, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 1090), new Point(250, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(10, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(250, 870), new Point(250, 1090));

            e.Graphics.DrawString("Grade", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(20, 880));
            e.Graphics.DrawString("G.Point", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(75, 880));
            e.Graphics.DrawString("Description", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(140, 880));
            e.Graphics.DrawString("A+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 900));
            e.Graphics.DrawString("4.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 900));
            e.Graphics.DrawString("Outstanding", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 900));

            e.Graphics.DrawString("A", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 920));
            e.Graphics.DrawString("3.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 920));
            e.Graphics.DrawString("Excellent", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 920));

            e.Graphics.DrawString("B+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("3.2", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 940));
            e.Graphics.DrawString("Very Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 940));

            e.Graphics.DrawString("B", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 960));
            e.Graphics.DrawString("2.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 960));
            e.Graphics.DrawString("Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 960));

            e.Graphics.DrawString("C+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 980));
            e.Graphics.DrawString("2.4", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 980));
            e.Graphics.DrawString("Above Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 980));

            e.Graphics.DrawString("C", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1000));
            e.Graphics.DrawString("2.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1000));
            e.Graphics.DrawString("Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1000));

            e.Graphics.DrawString("D", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1020));
            e.Graphics.DrawString("1.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1020));
            e.Graphics.DrawString("Below Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1020));

            e.Graphics.DrawString("E", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1040));
            e.Graphics.DrawString("0.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1040));
            e.Graphics.DrawString("Insufficient", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1040));

            e.Graphics.DrawString("N", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1060));
            e.Graphics.DrawString("0.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1060));
            e.Graphics.DrawString("Non Graded", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(605, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 1090), new Point(605, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(260, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(605, 870), new Point(605, 1090));

            e.Graphics.DrawString("Working Days: "+totWorkingDaysTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 880));
            e.Graphics.DrawString("Attendence:  "+AttendanceTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 880));
            e.Graphics.DrawString("Remarks:", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 940));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(400, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1060), new Point(400, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(270, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(400, 1000), new Point(400, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(600, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1060), new Point(600, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(405, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 1000), new Point(600, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(600, 920));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 990), new Point(600, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(360, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 920), new Point(600, 990));

            e.Graphics.DrawString("Class Teacher", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(305, 1020));

            e.Graphics.DrawString("Head Master/Principal", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(410, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1020));
            e.Graphics.DrawString("With Stamp", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1035));


            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(830, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 1090), new Point(830, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(615, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(830, 870), new Point(830, 1090));

            e.Graphics.DrawString("Total Credit:   " + totalCredittxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 880));
            e.Graphics.DrawString("Total Marks:   " + totalMarkssstxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 905));
            e.Graphics.DrawString("Percentage:   " + percentagetxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 930));



            e.Graphics.DrawString("GPA:    " + totalGPAtxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 955));
            e.Graphics.DrawString("Result", new Font("Calibri", 18, FontStyle.Bold), Brushes.Black, new Point(625, 980));
            e.Graphics.DrawString(resultttt.Text.Trim(), new Font("Calibri", 24, FontStyle.Bold), Brushes.Black, new Point(730, 975));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(825, 1015));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1068), new Point(825, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(620, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(825, 1015), new Point(825, 1068));

            e.Graphics.DrawString("Parents' Signature", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(660, 1070));

            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        private void avoidSpaceDatagridView()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == "" || dataGridView1.Rows[i].Cells[j].Value == null || dataGridView1.Rows[i].Cells[2].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[j].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "-".ToString();
                    }
                }
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            avoidSpaceDatagridView();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int rInG = 315;
            int cou = dataGridView1.Rows.Count;
            switch (cou)
            {
                case 1:
                    rInG += 40 * cou;
                    break;
                case 2:
                    rInG += 40 * cou;
                    break;
                case 3:
                    rInG += 40 * cou;
                    break;
                case 4:
                    rInG += 40 * cou;
                    break;
                case 5:
                    rInG += 40 * cou;
                    break;
                case 6:
                    rInG += 40 * cou;
                    break;
                case 7:
                    rInG += 40 * cou;
                    break;
                case 8:
                    rInG += 40 * cou;
                    break;
                case 9:
                    rInG += 40 * cou;
                    break;
                case 10:
                    rInG += 40 * cou;
                    break;
                case 11:
                    rInG += 40 * cou;
                    break;
                case 12:
                    rInG += 40 * cou;
                    break;
                case 13:
                    rInG += 40 * cou;
                    break;
                case 14:
                    rInG += 40 * cou;
                    break;
                default:
                    rInG = 860;
                    break;
            }

            Image image = Resources.head;
            e.Graphics.DrawImage(image, 0, 0, 900, 1300);
            e.Graphics.DrawString("PROGRESS REPORT", new Font("Cambria", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(310, 115));

            e.Graphics.DrawString(comboExams.Text.Trim(), new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(300, 150));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 190), new Point(833, 190));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 190), new Point(10, 287));

            e.Graphics.DrawString("Name : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 210));
            e.Graphics.DrawString(txtNameNew.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 210));

            e.Graphics.DrawString("................................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 215));


            e.Graphics.DrawString("Stream : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 210));
            e.Graphics.DrawString(comboStream.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 210));
            e.Graphics.DrawString("......................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(530, 215));


            e.Graphics.DrawString("Class : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 240));
            e.Graphics.DrawString(comboClass.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 240));

            e.Graphics.DrawString("...................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 245));

            e.Graphics.DrawString("Sec : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(300, 240));
            e.Graphics.DrawString(comboSec.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(370, 240));
            e.Graphics.DrawString("..........................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 245));

            e.Graphics.DrawString("Roll No : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(520, 240));
            e.Graphics.DrawString(comboroll.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(610, 240));
            e.Graphics.DrawString("........................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 245));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 285), new Point(833, 285));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(833, 190), new Point(833, 287));

            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(833, 295));

            e.Graphics.DrawString("S.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 310));
            e.Graphics.DrawString("No.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 330));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(50, 295), new Point(50, rInG));

            e.Graphics.DrawString("Subject", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(80, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 295), new Point(205, rInG));

            e.Graphics.DrawString("Full Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(235, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(345, 295), new Point(345, rInG));

            //for merge like for three columns
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 335), new Point(595, 335));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(225, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(275, 335), new Point(275, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(295, 340));

            e.Graphics.DrawString("Pass Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(465, 295), new Point(465, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(355, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 335), new Point(405, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(415, 340));

            e.Graphics.DrawString("Obt Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(490, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(595, 295), new Point(595, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(480, 340));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(530, 335), new Point(530, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 340));

            e.Graphics.DrawString("Total", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(660, 295), new Point(660, rInG));

            e.Graphics.DrawString("GPA", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(665, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(715, 295), new Point(715, rInG));

            e.Graphics.DrawString("Grade", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(720, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(775, 295), new Point(775, rInG));

            //draw horizontal line (datgridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 370), new Point(833, 370));
            //draw vertical line (left border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(10, rInG));
            //draw vertical line (right border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(833, 295), new Point(833, rInG));
            //draw horizontal line(bottom border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, rInG), new Point(833, rInG));

            int yPos = 380;
            int xPos = 20;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                yPos = 380;
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {
                    switch (i)
                    {
                        case 1:
                            xPos = 55;
                            break;
                        case 2:
                            xPos = 210;
                            break;
                        case 3:
                            xPos = 285;
                            break;
                        case 4:
                            xPos = 355;
                            break;
                        case 5:
                            xPos = 415;
                            break;
                        case 6:
                            xPos = 475;
                            break;
                        case 7:
                            xPos = 545;
                            break;
                        case 8:
                            xPos = 605;
                            break;
                        case 9:
                            xPos = 670;
                            break;
                        case 10:
                            xPos = 725;
                            break;
                        case 11:
                            xPos = 785;
                            break;
                    }
                    e.Graphics.DrawString(dataGridView1.Rows[j].Cells[i].Value.ToString().Trim(), new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(xPos, yPos));

                    yPos += 35;


                }
            }
            //after datagridview horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 860), new Point(833, 860));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(250, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 1090), new Point(250, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(10, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(250, 870), new Point(250, 1090));

            e.Graphics.DrawString("Grade", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(20, 880));
            e.Graphics.DrawString("G.Point", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(75, 880));
            e.Graphics.DrawString("Description", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(140, 880));
            e.Graphics.DrawString("A+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 900));
            e.Graphics.DrawString("4.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 900));
            e.Graphics.DrawString("Outstanding", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 900));

            e.Graphics.DrawString("A", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 920));
            e.Graphics.DrawString("3.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 920));
            e.Graphics.DrawString("Excellent", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 920));

            e.Graphics.DrawString("B+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("3.2", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 940));
            e.Graphics.DrawString("Very Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 940));

            e.Graphics.DrawString("B", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 960));
            e.Graphics.DrawString("2.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 960));
            e.Graphics.DrawString("Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 960));

            e.Graphics.DrawString("C+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 980));
            e.Graphics.DrawString("2.4", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 980));
            e.Graphics.DrawString("Above Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 980));

            e.Graphics.DrawString("C", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1000));
            e.Graphics.DrawString("2.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1000));
            e.Graphics.DrawString("Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1000));

            e.Graphics.DrawString("D", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1020));
            e.Graphics.DrawString("1.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1020));
            e.Graphics.DrawString("Below Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1020));

            e.Graphics.DrawString("E", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1040));
            e.Graphics.DrawString("0.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1040));
            e.Graphics.DrawString("Insufficient", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1040));

            e.Graphics.DrawString("N", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1060));
            e.Graphics.DrawString("0.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1060));
            e.Graphics.DrawString("Non Graded", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(605, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 1090), new Point(605, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(260, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(605, 870), new Point(605, 1090));

            e.Graphics.DrawString("Working Days: " + totWorkingDaysTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 880));
            e.Graphics.DrawString("Attendence:  " + AttendanceTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 880));
            e.Graphics.DrawString("Remarks:", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 940));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(400, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1060), new Point(400, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(270, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(400, 1000), new Point(400, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(600, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1060), new Point(600, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(405, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 1000), new Point(600, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(600, 920));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 990), new Point(600, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(360, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 920), new Point(600, 990));

            e.Graphics.DrawString("Class Teacher", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(305, 1020));

            e.Graphics.DrawString("Head Master/Principal", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(410, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1020));
            e.Graphics.DrawString("With Stamp", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1035));


            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(830, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 1090), new Point(830, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(615, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(830, 870), new Point(830, 1090));

            e.Graphics.DrawString("Total Credit:   " + totalCredittxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 880));
            e.Graphics.DrawString("Total Marks:   " + totalMarkssstxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 905));
            e.Graphics.DrawString("Percentage:   " + percentagetxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 930));


            e.Graphics.DrawString("GPA:    " + totalGPAtxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 955));
            e.Graphics.DrawString("Result", new Font("Calibri", 18, FontStyle.Bold), Brushes.Black, new Point(625, 980));
            e.Graphics.DrawString(resultttt.Text.Trim(), new Font("Calibri", 24, FontStyle.Bold), Brushes.Black, new Point(730, 975));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(825, 1015));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1068), new Point(825, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(620, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(825, 1015), new Point(825, 1068));

            e.Graphics.DrawString("Parents' Signature", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(660, 1070));
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int rInG = 315;
            int cou = dataGridView1.Rows.Count;
            switch (cou)
            {
                case 1:
                    rInG += 40 * cou;
                    break;
                case 2:
                    rInG += 40 * cou;
                    break;
                case 3:
                    rInG += 40 * cou;
                    break;
                case 4:
                    rInG += 40 * cou;
                    break;
                case 5:
                    rInG += 40 * cou;
                    break;
                case 6:
                    rInG += 40 * cou;
                    break;
                case 7:
                    rInG += 40 * cou;
                    break;
                case 8:
                    rInG += 40 * cou;
                    break;
                case 9:
                    rInG += 40 * cou;
                    break;
                case 10:
                    rInG += 40 * cou;
                    break;
                case 11:
                    rInG += 40 * cou;
                    break;
                case 12:
                    rInG += 40 * cou;
                    break;
                case 13:
                    rInG += 40 * cou;
                    break;
                case 14:
                    rInG += 40 * cou;
                    break;
                default:
                    rInG = 860;
                    break;
            }

            Image image = Resources.head;
            e.Graphics.DrawImage(image, 0, 0, 900, 1300);
            e.Graphics.DrawString("PROGRESS REPORT", new Font("Cambria", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(310, 115));

            e.Graphics.DrawString(comboExams.Text.Trim(), new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(300, 150));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 190), new Point(833, 190));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 190), new Point(10, 287));

            e.Graphics.DrawString("Name : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 210));
            e.Graphics.DrawString(comRegName.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 210));

            e.Graphics.DrawString("................................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 215));


            e.Graphics.DrawString("Stream : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 210));
            e.Graphics.DrawString(comRegStream.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 210));
            e.Graphics.DrawString("......................................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(530, 215));


            e.Graphics.DrawString("Class : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(20, 240));
            e.Graphics.DrawString(comRegClass.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(110, 240));

            e.Graphics.DrawString("...................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(100, 245));

            e.Graphics.DrawString("Sec : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(300, 240));
            e.Graphics.DrawString(comRegsec.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(370, 240));
            e.Graphics.DrawString("..........................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 245));

            e.Graphics.DrawString("Roll No : ", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(520, 240));
            e.Graphics.DrawString(comRegRoll.Text.Trim(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(610, 240));
            e.Graphics.DrawString("........................................", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 245));
            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 285), new Point(833, 285));
            //draw vertical line
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(833, 190), new Point(833, 287));

            //draw horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(833, 295));

            e.Graphics.DrawString("S.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 310));
            e.Graphics.DrawString("No.", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(18, 330));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(50, 295), new Point(50, rInG));

            e.Graphics.DrawString("Subject", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(80, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 295), new Point(205, rInG));

            e.Graphics.DrawString("Full Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(235, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(345, 295), new Point(345, rInG));

            //for merge like for three columns
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(205, 335), new Point(595, 335));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(225, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(275, 335), new Point(275, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(295, 340));

            e.Graphics.DrawString("Pass Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(360, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(465, 295), new Point(465, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(355, 340));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 335), new Point(405, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(415, 340));

            e.Graphics.DrawString("Obt Marks", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(490, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(595, 295), new Point(595, rInG));

            e.Graphics.DrawString("TH", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(480, 340));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(530, 335), new Point(530, rInG));

            e.Graphics.DrawString("PR", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(540, 340));

            e.Graphics.DrawString("Total", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(600, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(660, 295), new Point(660, rInG));

            e.Graphics.DrawString("GPA", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(665, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(715, 295), new Point(715, rInG));

            e.Graphics.DrawString("Grade", new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new Point(720, 310));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(775, 295), new Point(775, rInG));

            //draw horizontal line (datgridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, 370), new Point(833, 370));
            //draw vertical line (left border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 295), new Point(10, rInG));
            //draw vertical line (right border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(833, 295), new Point(833, rInG));
            //draw horizontal line(bottom border datagridview)
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, rInG), new Point(833, rInG));

            int yPos = 380;
            int xPos = 20;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                yPos = 380;
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {
                    switch (i)
                    {
                        case 1:
                            xPos = 55;
                            break;
                        case 2:
                            xPos = 210;
                            break;
                        case 3:
                            xPos = 285;
                            break;
                        case 4:
                            xPos = 355;
                            break;
                        case 5:
                            xPos = 415;
                            break;
                        case 6:
                            xPos = 475;
                            break;
                        case 7:
                            xPos = 545;
                            break;
                        case 8:
                            xPos = 605;
                            break;
                        case 9:
                            xPos = 670;
                            break;
                        case 10:
                            xPos = 725;
                            break;
                        case 11:
                            xPos = 785;
                            break;
                    }
                    e.Graphics.DrawString(dataGridView1.Rows[j].Cells[i].Value.ToString().Trim(), new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(xPos, yPos));

                    yPos += 35;


                }
            }
            //after datagridview horizontal line
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new Point(10, 860), new Point(833, 860));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(250, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 1090), new Point(250, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(10, 870), new Point(10, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(250, 870), new Point(250, 1090));

            e.Graphics.DrawString("Grade", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(20, 880));
            e.Graphics.DrawString("G.Point", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(75, 880));
            e.Graphics.DrawString("Description", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(140, 880));
            e.Graphics.DrawString("A+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 900));
            e.Graphics.DrawString("4.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 900));
            e.Graphics.DrawString("Outstanding", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 900));

            e.Graphics.DrawString("A", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 920));
            e.Graphics.DrawString("3.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 920));
            e.Graphics.DrawString("Excellent", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 920));

            e.Graphics.DrawString("B+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("3.2", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 940));
            e.Graphics.DrawString("Very Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 940));

            e.Graphics.DrawString("B", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 960));
            e.Graphics.DrawString("2.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 960));
            e.Graphics.DrawString("Good", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 960));

            e.Graphics.DrawString("C+", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 980));
            e.Graphics.DrawString("2.4", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 980));
            e.Graphics.DrawString("Above Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 980));

            e.Graphics.DrawString("C", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1000));
            e.Graphics.DrawString("2.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1000));
            e.Graphics.DrawString("Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1000));

            e.Graphics.DrawString("D", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1020));
            e.Graphics.DrawString("1.6", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1020));
            e.Graphics.DrawString("Below Average", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1020));

            e.Graphics.DrawString("E", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1040));
            e.Graphics.DrawString("0.8", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1040));
            e.Graphics.DrawString("Insufficient", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1040));

            e.Graphics.DrawString("N", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(30, 1060));
            e.Graphics.DrawString("0.0", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(90, 1060));
            e.Graphics.DrawString("Non Graded", new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new Point(140, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(605, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 1090), new Point(605, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(260, 870), new Point(260, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(605, 870), new Point(605, 1090));

            e.Graphics.DrawString("Working Days: " + totWorkingDaysTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 880));
            e.Graphics.DrawString("Attendence:  " + AttendanceTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(450, 880));
            e.Graphics.DrawString("Remarks:", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 940));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(400, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1060), new Point(400, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(270, 1000), new Point(270, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(400, 1000), new Point(400, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(600, 1000));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1060), new Point(600, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(405, 1000), new Point(405, 1060));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 1000), new Point(600, 1060));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(600, 920));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 990), new Point(600, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(360, 920), new Point(360, 990));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(600, 920), new Point(600, 990));

            e.Graphics.DrawString("Class Teacher", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(270, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(305, 1020));

            e.Graphics.DrawString("Head Master/Principal", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(410, 1060));
            e.Graphics.DrawString("Signature", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1020));
            e.Graphics.DrawString("With Stamp", new Font("Calibri", 10, FontStyle.Bold), Brushes.Gray, new Point(480, 1035));


            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(830, 870));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 1090), new Point(830, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(615, 870), new Point(615, 1090));
            e.Graphics.DrawLine(new Pen(Color.Gray, 3), new Point(830, 870), new Point(830, 1090));

            e.Graphics.DrawString("Total Credit:   " + totalCredittxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 880));
            e.Graphics.DrawString("Total Marks:   " + totalMarkssstxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 905));
            e.Graphics.DrawString("Percentage:   " + percentagetxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 930));


            e.Graphics.DrawString("GPA:    " + totalGPAtxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(625, 955));
            e.Graphics.DrawString("Result", new Font("Calibri", 18, FontStyle.Bold), Brushes.Black, new Point(625, 980));
            e.Graphics.DrawString(resultttt.Text.Trim(), new Font("Calibri", 24, FontStyle.Bold), Brushes.Black, new Point(730, 975));

            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(825, 1015));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1068), new Point(825, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(620, 1015), new Point(620, 1068));
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(825, 1015), new Point(825, 1068));

            e.Graphics.DrawString("Parents' Signature", new Font("Calibri", 12, FontStyle.Bold), Brushes.Black, new Point(660, 1070));
        }

        private void buttByRoll_Click(object sender, EventArgs e)
        {
            avoidSpaceDatagridView();
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void buttByReg_Click(object sender, EventArgs e)
        {
            avoidSpaceDatagridView();
            printPreviewDialog3.Document = printDocument3;
            printPreviewDialog3.ShowDialog();
        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }
    }
}


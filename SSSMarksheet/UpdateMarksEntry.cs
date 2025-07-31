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
    public partial class UpdateMarksEntry : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public UpdateMarksEntry()
        {
            InitializeComponent();
        }

        protected void ObtainedMarks()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {
                    
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select theory, practical from markEntry where terminal='" + comboTerminal.Text + "' and classes='" + comboClass.Text + "' and subject='" + combosubject.Text + "' and stream = '" + comboStream.Text + "' and sec = '" + comboSec.Text + "' and name='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "' and rollno='" + dataGridView1.Rows[k].Cells[2].Value.ToString() + "' ", conn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                            dataGridView1.Rows[k].Cells[3].Value = dt.Rows[0][0].ToString();
                            dataGridView1.Rows[k].Cells[4].Value = dt.Rows[0][1].ToString();

                        conn.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void FillCombobox()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject  from AddSubject where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                combosubject.DisplayMember = "Subject";
                combosubject.ValueMember = "ID";
                combosubject.DataSource = ds.Tables[0];
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
        protected void FillTextPassFull()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct passmark, fullmark, pPassmark, pFullmark  from AddSubjectMarks where terminal='" + comboTerminal.Text + "' and subject='" + combosubject.Text + "' and stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "'", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    textpass.Text = reader["passmark"].ToString();
                    textfull.Text = reader["fullmark"].ToString();
                    textPassPr.Text = reader["pPassmark"].ToString();
                    textFullPr.Text = reader["pFullmark"].ToString();

                    reader.Close();
                    con.Close();
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
        private void combofill()
        {
            string constring = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select name,rollno from addStudents where sec='" + comboSec.Text + "' and stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' ORDER BY rollno ASC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Set AutoGenerateColumns False
                            dataGridView1.AutoGenerateColumns = false;

                            //Set Columns Count
                            //dataGridView1.ColumnCount = 6;

                            //Add Columns
                            dataGridView1.Columns[0].Name = "SNo";
                            dataGridView1.Columns[0].HeaderText = "SNo";

                            dataGridView1.Columns[1].HeaderText = "Name";
                            dataGridView1.Columns[1].Name = "Name";
                            dataGridView1.Columns[1].DataPropertyName = "Name";

                            dataGridView1.Columns[2].Name = "RollNo";
                            dataGridView1.Columns[2].HeaderText = "RollNo";
                            dataGridView1.Columns[2].DataPropertyName = "RollNo";

                            dataGridView1.Columns[3].Name = "Theory";
                            dataGridView1.Columns[3].HeaderText = "Theory";

                            dataGridView1.Columns[4].Name = "Practical";
                            dataGridView1.Columns[4].HeaderText = "Practical";

                            dataGridView1.Columns[5].Name = "Total";
                            dataGridView1.Columns[5].HeaderText = "Total";
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
                //DatagridviewTotalcalculate();
            }
            catch (Exception)
            {

            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    combosubject.Focus();
                    combosubject.SelectAll();
                }
            }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    buttGo.PerformClick();
                }
            }
        }
        private void ResetFields()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    if (tb != null)
                    {
                        tb.Text = string.Empty;
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox dd = (ComboBox)ctrl;
                    if (dd != null)
                    {
                        dd.Text = string.Empty;
                        dd.SelectedIndex = -1;
                    }
                }
                else if (ctrl is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)ctrl;
                    if (dtp != null)
                    {
                        dtp.Text = DateTime.Today.ToShortDateString();
                    }
                }
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboTerminal.Text == "")
            {
                MessageBox.Show("Terminal cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTerminal.Focus();
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
            if (combosubject.Text == "")
            {
                MessageBox.Show("Subject cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                combosubject.Focus();
                return;
            }
            if (textpass.Text == "")
            {
                MessageBox.Show("Pass Marks cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textpass.Focus();
                return;
            }
            if (textfull.Text == "")
            {
                MessageBox.Show("Full Marks cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textfull.Focus();
                return;
            }
            combofill();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Theory"].Value = 0.ToString();
                dataGridView1.Rows[i].Cells["Practical"].Value = 0.ToString();
            }
            ObtainedMarks();
            DatagridviewTotalcalculate();
        }

        private void combosubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            textpass.Text = "";
            textfull.Text = "";
            FillTextPassFull();

        }

        private void combosubject_MouseClick(object sender, MouseEventArgs e)
        {
            //FillCombobox();
        }

        private void comboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCombobox();
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCombobox();
        }
        public void DatagridviewTotalcalculate()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    decimal theory = 0;
                    decimal practical = 0;
                    decimal total = 0;
                    if (dataGridView1.Rows[i].Cells["Theory"].Value.ToString() != "")
                    {
                        theory = Convert.ToDecimal(dataGridView1.Rows[i].Cells["Theory"].Value);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Theory"].Value = 0.ToString();
                    }
                    if (dataGridView1.Rows[i].Cells["Practical"].Value.ToString() != "")
                    {
                        practical = Convert.ToDecimal(dataGridView1.Rows[i].Cells["Practical"].Value);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Practical"].Value = 0.ToString();
                    }

                    total = Math.Ceiling(theory + practical);
                    dataGridView1.Rows[i].Cells["Total"].Value = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            DatagridviewTotalcalculate();
        }
        public void InsertMarksEntry()
        {
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Sorry!! Enter Marks First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ob.cn.Close();
                ob.cn.Open();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.fetch("Select * from markEntry where terminal='" + comboTerminal.Text + "' and stream='" + comboStream.Text + "'and classes='" + comboClass.Text + "' and sec='" + comboSec.Text + "' and subject='" + combosubject.Text + "' and passmark='" + textpass.Text + "' and fullmark='" + textfull.Text + "' and name='" + this.dataGridView1.Rows[i].Cells["Name"].Value.ToString() + "' and rollno='" + this.dataGridView1.Rows[i].Cells["RollNo"].Value.ToString() + "'");
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        ob.dmlstmt("Update markEntry SET terminal='" + comboTerminal.Text + "' , stream='" + comboStream.Text + "', classes='" + comboClass.Text + "' , sec='" + comboSec.Text + "' , subject='" + combosubject.Text + "' , passmark='" + textpass.Text + "' , fullmark='" + textfull.Text + "' , sno='" + this.dataGridView1.Rows[i].Cells["SNo"].Value.ToString() + "' , name='" + this.dataGridView1.Rows[i].Cells["Name"].Value.ToString() + "' , rollno='" + this.dataGridView1.Rows[i].Cells["RollNo"].Value.ToString() + "' , theory='" + this.dataGridView1.Rows[i].Cells["Theory"].Value.ToString() + "' , practical='" + this.dataGridView1.Rows[i].Cells["Practical"].Value.ToString() + "' , total='" + this.dataGridView1.Rows[i].Cells["Total"].Value.ToString() + "' where terminal='" + comboTerminal.Text + "' and stream='" + comboStream.Text + "'and classes='" + comboClass.Text + "' and sec='" + comboSec.Text + "' and subject='" + combosubject.Text + "' and passmark='" + textpass.Text + "' and fullmark='" + textfull.Text + "' and name='" + this.dataGridView1.Rows[i].Cells["Name"].Value.ToString() + "' and rollno='" + this.dataGridView1.Rows[i].Cells["RollNo"].Value.ToString() + "'");
                        //MessageBox.Show("Marks Updated Successfully");
                    }
                    else
                    {
                        ob.dmlstmt("Insert into markEntry(terminal,stream,classes,sec,subject,passmark,fullmark,sno,name,rollno,theory,practical,total) Values ('" + comboTerminal.Text + "','" + comboStream.Text + "','" + comboClass.Text + "','" + comboSec.Text + "','" + combosubject.Text + "','" + textpass.Text + "','" + textfull.Text + "','" + this.dataGridView1.Rows[i].Cells["SNo"].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells["Name"].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells["RollNo"].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells["Theory"].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells["Practical"].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells["Total"].Value.ToString() + "')");
                    }

                }

                MessageBox.Show("Marks Updated Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Entry Error!!! Refresh the page and try again!!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertMarksEntry();
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddMarks_Load(object sender, EventArgs e)
        {
            comboTerminal.Focus();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // allow 1 dot:


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                if ((sender as TextBox).Text != ".")
                {
                    e.Handled = true;
                }
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {


        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                if (Convert.ToDouble(dataGridView1.CurrentCell.Value) > Convert.ToDouble(textfull.Text))
                {
                    MessageBox.Show("Marks cannot be greater than Theory full marks");
                    dataGridView1.CurrentCell.Value = 0.ToString();
                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                if (Convert.ToDouble(dataGridView1.CurrentCell.Value) > Convert.ToDouble(textFullPr.Text))
                {
                    MessageBox.Show("Marks cannot be greater than Practical full marks");
                    dataGridView1.CurrentCell.Value = 0.ToString();
                }
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboSec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMarksEntry_Load(object sender, EventArgs e)
        {
            comboTerminal.Focus();
        }

        private void comboTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

       

        private void button16_Click(object sender, EventArgs e)
        {
            UpdateMarksEntry ads = new UpdateMarksEntry();
            ads.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddSubjects ads = new AddSubjects();
            ads.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudentNew ads = new AddStudentNew();
            ads.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            subjectMarks ads = new subjectMarks();
            ads.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddStudentNew ads = new AddStudentNew();
            ads.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddSubjects ads = new AddSubjects();
            ads.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            subjectMarks ads = new subjectMarks();
            ads.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            marksLedger ads = new marksLedger();
            ads.ShowDialog();
        }
    }
}

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
    public partial class Attendance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public Attendance()
        {
            InitializeComponent();
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
                    ob.fetch("Select * from Attendance where terminal='" + comboTerminal.Text + "' and stream='" + comboStream.Text + "'and classes='" + comboClass.Text + "' and sec='" + comboSec.Text + "' and name='" + this.dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and rollno='" + this.dataGridView1.Rows[i].Cells[2].Value.ToString() + "' ");
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        ob.dmlstmt("Update Attendance SET terminal='" + comboTerminal.Text + "' , stream='" + comboStream.Text + "', classes='" + comboClass.Text + "' , sec='" + comboSec.Text + "' , sno='" + this.dataGridView1.Rows[i].Cells[0].Value.ToString() + "' , name='" + this.dataGridView1.Rows[i].Cells[1].Value.ToString() + "' , rollno='" + this.dataGridView1.Rows[i].Cells[2].Value.ToString() + "' , present='" + this.dataGridView1.Rows[i].Cells[3].Value.ToString() + "' , absent='" + this.dataGridView1.Rows[i].Cells[4].Value.ToString() + "' , workingDays='" + txtWorkingDays.Text + "' where terminal='" + comboTerminal.Text + "' and stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' and sec='" + comboSec.Text + "' and name='" + this.dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and rollno='" + this.dataGridView1.Rows[i].Cells[2].Value.ToString() + "' ");

                    }
                    else
                    {
                        ob.dmlstmt("Insert into Attendance(terminal,stream,classes,sec,workingDays,sno,name,rollno,present,absent) Values ('" + comboTerminal.Text + "','" + comboStream.Text + "','" + comboClass.Text + "','" + comboSec.Text + "','" + txtWorkingDays.Text + "','" + this.dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + this.dataGridView1.Rows[i].Cells[4].Value.ToString() + "')");
                    }

                }
                MessageBox.Show("Attendance Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Entry Error!!! Refresh the page and try again!!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            InsertMarksEntry();
            ResetFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboTerminal.Text == "")
            {
                MessageBox.Show("Exam Terminal cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtWorkingDays.Text == "")
            {
                MessageBox.Show("Total Working Days cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWorkingDays.Focus();
                return;
            }
            combofill();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = 0.ToString();
                dataGridView1.Rows[i].Cells[4].Value = 0.ToString();
            }
            
        }
        private void combofill()
        {
            try
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

                                dataGridView1.Columns[3].Name = "Present";
                                dataGridView1.Columns[3].HeaderText = "Present";

                                dataGridView1.Columns[4].Name = "Absent";
                                dataGridView1.Columns[4].HeaderText = "Absent";

                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {

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
                    comboTerminal.Focus();
                }
            }
        }

        private void comboTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    txtWorkingDays.Focus();
                    txtWorkingDays.SelectAll();
                }
            }
        }

        private void txtWorkingDays_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
                //DatagridviewTotalcalculate();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                
            }
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double workingDays = Convert.ToDouble(txtWorkingDays.Text);
            
            if (Convert.ToDouble(dataGridView1.CurrentCell.Value) > workingDays)
            {
                MessageBox.Show("Present days should not exceed total working days");
                dataGridView1.CurrentCell.Value = 0.ToString();
                return;
            }
            absentCalculate();
            
        }
        private void absentCalculate()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double absent = 0;
                double workingDays = Convert.ToDouble(txtWorkingDays.Text);
                absent = workingDays - Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                dataGridView1.Rows[i].Cells[4].Value = absent.ToString();
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ResetFields()
        {
            comboStream.SelectedIndex = -1;
            comboSec.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboTerminal.SelectedIndex = -1;
            txtWorkingDays.Text = "";
            combofill();
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (comboStream.Text != "")
                {
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        if (Convert.ToDouble(dataGridView1.CurrentCell.Value) > Convert.ToDouble(txtWorkingDays.Text))
                        {
                            MessageBox.Show("Attendance cannot be greater than Total Working Days");
                            dataGridView1.CurrentCell.Value = 0.ToString();
                        }
                    }
                }
            }catch(Exception)
            {
            }
        }

        private void txtWorkingDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                txtWorkingDays.BackColor = System.Drawing.Color.Red;
                txtWorkingDays.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                txtWorkingDays.BackColor = System.Drawing.Color.White;
                txtWorkingDays.ForeColor = System.Drawing.Color.Black;
            }
        }

    }
}

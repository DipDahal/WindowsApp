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
    public partial class subjectMarks : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public subjectMarks()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboSubject.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                textPPM.Focus();
                textPPM.SelectAll();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    textPM.Focus();
                    textPM.SelectAll();

                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    textFM.Focus();
                    textFM.SelectAll();

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
        private void button2_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        protected void FillMarksDetails()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                ob.cn.Open();
                ob.fetch("Select * from AddSubjectMarks where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and terminal='" + comboTerminal.Text + "' and subject='" + comboSubject.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select distinct passmark, fullmark, pPassmark, pFullmark from AddSubjectMarks where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and terminal='" + comboTerminal.Text + "' and subject='" + comboSubject.Text + "'", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textPM.Text = reader["passmark"].ToString();
                        textFM.Text = reader["fullmark"].ToString();
                        textPPM.Text = reader["pPassmark"].ToString();
                        textPFM.Text = reader["pFullmark"].ToString();
                        reader.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some Error");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
            if (comboTerminal.Text == "")
            {
                MessageBox.Show("Terminal cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTerminal.Focus();
                return;
            }
            if (comboSubject.Text == "")
            {
                MessageBox.Show("Subject cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSubject.Focus();
                return;
            }
            if (textPM.Text == "")
            {
                MessageBox.Show("Pass Mark cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPM.Focus();
                return;
            }
            if (textFM.Text == "")
            {
                MessageBox.Show("Full Mark cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textFM.Focus();
                return;
            }
            if (textPPM.Text == "")
            {
                MessageBox.Show("Practical Pass Mark cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPPM.Focus();
                return;
            }
            if (textPFM.Text == "")
            {
                MessageBox.Show("Practical Full Mark cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPFM.Focus();
                return;
            }

            try
            {

                ob.fetch("Select * from AddSubjectMarks where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and terminal='" + comboTerminal.Text + "' and subject='" + comboSubject.Text + "'");
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("Update AddSubjectMarks SET stream = '" + comboStream.Text + "' , classes='" + comboClass.Text + "' , terminal='" + comboTerminal.Text + "' , subject='" + comboSubject.Text + "' , passmark='" + textPM.Text + "' , fullmark='" + textFM.Text + "' ,pPassmark='" + textPPM.Text + "' , pFullmark='" + textPFM.Text + "'  where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and terminal='" + comboTerminal.Text + "' and subject='" + comboSubject.Text + "' ");
                    ob.cn.Close();
                    MessageBox.Show("Subject Marks Updated successfully");
                    //update data code
                }
                else
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    //insert data code
                    ob.dmlstmt("Insert into AddSubjectMarks(stream,classes,terminal,subject,passmark,fullmark,pPassmark,pFullmark) values ('" + comboStream.Text + "','" + comboClass.Text + "' ,'" + comboTerminal.Text + "','" + comboSubject.Text + "','" + textPM.Text + "','" + textFM.Text + "','" + textPPM.Text + "','" + textPFM.Text + "')");
                    MessageBox.Show("Subject Marks added successfully");
                    ob.cn.Close();
                }
                comboSubject.SelectedIndex = -1;
                comboSubject.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void fetchSubjectName()
        {

            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject  from AddSubject where stream='" + comboStream.Text + "' and classes='" + comboClass.Text + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                comboSubject.DisplayMember = "Subject";
                comboSubject.ValueMember = "ID";
                comboSubject.DataSource = ds.Tables[0];
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    textPFM.Focus();
                    textPFM.SelectAll();

                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    button1.PerformClick();

                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                textPM.BackColor = System.Drawing.Color.Red;
                textPM.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textPM.BackColor = System.Drawing.Color.White;
                textPM.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                textFM.BackColor = System.Drawing.Color.Red;
                textFM.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textFM.BackColor = System.Drawing.Color.White;
                textFM.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                textPPM.BackColor = System.Drawing.Color.Red;
                textPPM.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textPPM.BackColor = System.Drawing.Color.White;
                textPPM.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                textPFM.BackColor = System.Drawing.Color.Red;
                textPFM.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textPFM.BackColor = System.Drawing.Color.White;
                textPFM.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void comboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStream.Text != "" && comboClass.Text != "" && comboTerminal.Text != "")
            {
                fetchSubjectName();
            }
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStream.Text != "" && comboClass.Text != "" && comboTerminal.Text != "")
            {
                fetchSubjectName();
            }
        }

        private void comboTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStream.Text != "" && comboClass.Text != "" && comboTerminal.Text != "")
            {
                fetchSubjectName();
            }
        }

        private void comboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMarksDetails();
        }

        private void subjectMarks_Load(object sender, EventArgs e)
        {

        }

    }
}

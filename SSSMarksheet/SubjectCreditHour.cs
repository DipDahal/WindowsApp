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
using System.Text.RegularExpressions;

namespace SSSMarksheet
{
    public partial class SubjectCreditHour : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public SubjectCreditHour()
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

        private void comboClass_KeyDown(object sender, KeyEventArgs e)
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

        private void comboSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    textCredit.Focus();
                    textCredit.SelectAll();
                }
            }
        }

        private void SubjectCreditHour_Load(object sender, EventArgs e)
        {
            comboStream.Focus();
        }

        private void textCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    textCreditPr.Focus();
                    textCreditPr.SelectAll();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            if (comboSubject.Text == "")
            {
                MessageBox.Show("Subject cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSubject.Focus();
                return;
            }
            if (textCredit.Text == "")
            {
                MessageBox.Show("Theory Credit Hours cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCredit.Focus();
                return;
            }
            if (textCreditPr.Text == "")
            {
                MessageBox.Show("Practical Credit Hours cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCredit.Focus();
                return;
            }
            if (Convert.ToDouble(textCredit.Text) > 5 || Convert.ToDouble(textCredit.Text) < 1)
            {
                MessageBox.Show("Check Credit Hour of the subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCredit.Focus();
                return;
            }
            if (Convert.ToDouble(textCredit.Text) > 5)
            {
               DialogResult result = MessageBox.Show("Are you sure Credit hour exceed 5?", "Confirmation",
  MessageBoxButtons.YesNoCancel);
               if (result == DialogResult.No)
               {
                   textCredit.Focus();
                   return;
               }
               if (result == DialogResult.Cancel)
               {
                   textCredit.Focus();
                   return;
               }
               
            }
            
            try
            {

                ob.fetch("Select * from creditHour where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and subject='" + comboSubject.Text + "'");
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("Update creditHour SET stream = '" + comboStream.Text + "' , classes='" + comboClass.Text + "' , subject='" + comboSubject.Text + "' , credit='" + textCredit.Text + "', creditPr='" + textCreditPr.Text + "' where stream = '" + comboStream.Text + "' and classes='" + comboClass.Text + "' and subject='" + comboSubject.Text + "' ");
                    ob.cn.Close();
                    MessageBox.Show("Subject Credit Updated successfully");
                    //update data code
                }
                else
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    //insert data code
                    ob.dmlstmt("Insert into creditHour(stream,classes,subject,credit) values ('" + comboStream.Text + "','" + comboClass.Text + "' ,'" + comboSubject.Text + "','" + textCredit.Text + "')");
                    MessageBox.Show("Subject Credit added successfully");
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
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStream.Text != "" || comboClass.Text != "")
            {
                fetchSubjectName();
            }
        }

        private void comboStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStream.Text != "" || comboClass.Text != "")
            {
                fetchSubjectName();
            }
        }

        private void textCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^+.]");
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.Handled = regex.IsMatch(e.KeyChar.ToString())))
            {
                textCredit.BackColor = System.Drawing.Color.Red;
                textCredit.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textCredit.BackColor = System.Drawing.Color.White;
                textCredit.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textCreditPr_KeyDown(object sender, KeyEventArgs e)
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

        private void textCreditPr_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^+.]");
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.Handled = regex.IsMatch(e.KeyChar.ToString())))
            {
                textCreditPr.BackColor = System.Drawing.Color.Red;
                textCreditPr.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textCreditPr.BackColor = System.Drawing.Color.White;
                textCreditPr.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}

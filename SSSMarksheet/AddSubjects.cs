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
using System.Globalization;

namespace SSSMarksheet
{
    public partial class AddSubjects : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public AddSubjects()
        {
            InitializeComponent();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    comboBox5.Focus();
                    comboBox5.SelectAll();
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
                    combosubject.Focus();
                    textBox4.Focus();
                    textBox4.SelectAll();
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
        protected void FillCombobox()
        {

            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct subject  from AddSubject where stream='" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'", conn);
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
        private void button2_Click(object sender, EventArgs e)
        {
            combosubject.Visible = true;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            if (comboBox5.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox5.Focus();
                return;
            }
            if (combosubject.Text == "")
            {
                MessageBox.Show("Subject cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }
            try
            {
                ob.cn.Open();
                ob.fetch("Select * from AddSubject where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + combosubject.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("delete from AddSubject where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + combosubject.Text + "'");
                    MessageBox.Show("Subject Deleted successfully");
                    /* AddStudent ads = new AddStudent();
                     this.Hide();
                     ads.ShowDialog();
                     * */
                    ob.cn.Close();
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("delete from AddSubjectMarks where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + combosubject.Text + "'");
                    ob.cn.Close();

                    ob.cn.Open();
                    ob.dmlstmt("delete from markEntry where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + combosubject.Text + "'");
                    ob.cn.Close();
                }
                else
                {
                    MessageBox.Show("Subject Name Does not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            combosubject.Visible = false;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox5.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Subject cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }
            
            try
            {

                ob.fetch("Select * from AddSubject where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + textBox4.Text + "'");
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("Update AddSubject SET stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + textBox4.Text + "' where stream = '" + comboBox1.Text + "' and classes='" + comboBox5.Text + "'and subject='" + textBox4.Text + "'");
                    ob.cn.Close();
                    MessageBox.Show("Subject name Updated successfully");
                    //update data code
                }
                else
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    //insert data code
                    ob.dmlstmt("Insert into AddSubject(stream,classes,subject) values ('" + comboBox1.Text + "','" + comboBox5.Text + "','" + textBox4.Text + "')");
                    MessageBox.Show("Subject name added successfully");
                    ob.cn.Close();
                }
                textBox4.Text="";
                textBox4.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^+-.&]");
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.Handled = regex.IsMatch(e.KeyChar.ToString())))
            {
                textBox4.BackColor = System.Drawing.Color.Red;
                textBox4.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "" || comboBox1.Text != "")
            {
                FillCombobox();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "" || comboBox1.Text != "")
            {
                FillCombobox();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "" || comboBox1.Text != "")
            {
                FillCombobox();
            }
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "" || comboBox1.Text != "")
            {
                FillCombobox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            combosubject.Visible = true;
            textBox4.Visible = false; 
            button2.Visible = true;
            if (comboBox5.Text != "" || comboBox1.Text != "")
            {
                FillCombobox();
            }
        }

        private void combosubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combosubject_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            textBox4.Text = textInfo.ToTitleCase(textBox4.Text);
            this.textBox4.SelectionStart = textBox4.Text.Length;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace SSSMarksheet
{
    public partial class AddStudentNew : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public AddStudentNew()
        {
            InitializeComponent();
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
                
            }
        }

        private void namess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void namess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                namess.BackColor = System.Drawing.Color.Red;
                namess.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                namess.BackColor = System.Drawing.Color.White;
                namess.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void namess_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            namess.Text = textInfo.ToTitleCase(namess.Text);
            this.namess.SelectionStart = namess.Text.Length;
        }

        private void classss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    sec.Focus();
                    sec.SelectAll();

                }
            }
        }

        private void sec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    stream.Focus();
                    stream.SelectAll();
                }
            }
        }

        private void stream_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    rollno.Focus();
                    rollno.SelectAll();
                }
            }
        }

        private void rollno_KeyDown(object sender, KeyEventArgs e)
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

        private void rollno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                rollno.BackColor = System.Drawing.Color.Red;
                rollno.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                rollno.BackColor = System.Drawing.Color.White;
                rollno.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namess.Text == "")
            {
                MessageBox.Show("Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classss.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classss.Focus();
                return;
            }
            if (sec.Text == "")
            {
                MessageBox.Show("Sec cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sec.Focus();
                return;
            }
            if (rollno.Text == "")
            {
                MessageBox.Show("Rollno cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rollno.Focus();
                return;
            }
            if (stream.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stream.Focus();
                return;
            }

            try
            {
                ob.cn.Open();
                ob.fetch("Select * from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
  MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ob.cn.Open();
                        ob.dmlstmt("Update addStudents SET name='" + namess.Text + "' , classes='" + classss.Text + "' , sec='" + sec.Text + "' , stream='" + stream.Text + "' , rollno='" + rollno.Text + "'  where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "' ");
                        ob.cn.Close();
                        ob.cn.Open();
                        ob.dmlstmt("Update markEntry SET name='" + namess.Text + "' , classes='" + classss.Text + "' , sec='" + sec.Text + "' , stream='" + stream.Text + "' , rollno='" + rollno.Text + "'  where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "' ");
                        ob.cn.Close();
                        MessageBox.Show("Student data Updated Successfully");
                    }
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    ob.cn.Close();
                }
                else
                {
                    try
                    {
                        ob.cn.Close();
                        ob.cn.Open();

                        ob.dmlstmt("Insert into addStudents(name, classes , sec, stream, rollno) values ('" + namess.Text + "' , '" + classss.Text + "' , '" + sec.Text + "' ,'" + stream.Text + "' , '" + rollno.Text + "')");
                        MessageBox.Show("Student data added successfully");
                        /* AddStudent ads = new AddStudent();
                         this.Hide();
                         ads.ShowDialog();
                         * */
                        ob.cn.Close();

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }
                }
                ResetFields();
                namess.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {
                if (classss.Text == "")
                {
                    MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    classss.Focus();
                    return;
                }
                if (sec.Text == "")
                {
                    MessageBox.Show("Sec cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sec.Focus();
                    return;
                }
                if (rollno.Text == "")
                {
                    MessageBox.Show("Rollno cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rollno.Focus();
                    return;
                }
                if (stream.Text == "")
                {
                    MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stream.Focus();
                    return;
                }
            try
            {
                ob.cn.Open();
                ob.fetch("Select * from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("delete from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "'");
                    MessageBox.Show("Student data Deleted successfully");
                    /* AddStudent ads = new AddStudent();
                     this.Hide();
                     ads.ShowDialog();
                     * */
                    ob.cn.Close();
                }
                else
                {
                    MessageBox.Show("Student Data Does not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
    }
}

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

namespace SSSMarksheet
{
    public partial class register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ob.fetch("Select * from login");
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("You have already register, Please Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    login lg = new login();
                    this.Hide();
                    lg.ShowDialog();
                    con.Close();
                    con.Open();
                }
                else
                {
                    try
                    {
                        ob.cn.Close();
                        ob.cn.Open();
                        ob.dmlstmt("Insert into login(username,password) values ('" + textBox1.Text + "','" + textBox2.Text + "')");
                        MessageBox.Show("Your account registered successfully");
                        login lg = new login();
                        this.Hide();
                        lg.ShowDialog();
                        ob.cn.Close();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login lg = new login();
            this.Hide();
            lg.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void register_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                login lg = new login();
                this.Hide();
                lg.Show();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                textBox1.BackColor = System.Drawing.Color.Red;
                textBox1.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}

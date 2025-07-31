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
using System.Globalization;

namespace SSSMarksheet
{
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        public AddStudent()
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
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    dobTxtBS.Focus();
                    dobTxtBS.SelectAll();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    dobTxtBS.Focus();
                    dobTxtBS.SelectAll();
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
                    whoose.Focus();
                    whoose.SelectAll();
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
                    specify.Focus();
                    specify.SelectAll();
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("MotherName cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipality cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                municipalityTxt.Focus();
                return;
            }
            if (wardTxt.Text == "")
            {
                MessageBox.Show("Ward Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wardTxt.Focus();
                return;
            }
            if (distTxt.Text == "")
            {
                MessageBox.Show("District cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                distTxt.Focus();
                return;
            }
            if (proviTxt.Text == "")
            {
                MessageBox.Show("Province Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }

            try
            {
                ob.cn.Open();
                //var result = (int)ob.cm.ExecuteScalar();
                ob.fetch("Select * from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
  MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ob.cn.Open();
                        ob.dmlstmt("Update addStudents SET regid='" + regid.Text + "' , symbolno='" + symbol.Text + "', name='" + namess.Text + "' , classes='" + classss.Text + "' , sec='" + sec.Text + "' , stream='" + stream.Text + "' , rollno='" + rollno.Text + "' , municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "', district='" + distTxt.Text + "' , province='" + proviTxt.Text + "' , contact='" + contact.Text + "' , contactInfo='" + whoose.Text + "' , contactInfoOthers='" + specify.Text + "', admissionDate='" + admissionDate.Text + "', dobAD='" + dobtxtAD.Text + "', dobBS='" + dobTxtBS.Text + "', fatherName='" + fatherTxt.Text + "', motherName='" + motherTxt.Text + "' where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "' or regid='" + regid.Text + "' or symbolno='" + symbol.Text + "' ");
                        ob.cn.Close();
                        MessageBox.Show("Student data Updated Successfully");

                        ob.cn.Close();
                    }
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        ob.cn.Close();
                        ob.cn.Open();

                        ob.dmlstmt("Insert into addStudents(regid, symbolno, name, classes , sec, stream, rollno, municipal, wardNo, district, province, contact, contactInfo, contactInfoOthers, admissionDate, dobAD, dobBS, fatherName, motherName) values ('" + regid.Text + "' ,'" + symbol.Text + "', '" + namess.Text + "' , '" + classss.Text + "' , '" + sec.Text + "' ,'" + stream.Text + "' , '" + rollno.Text + "' ,'" + municipalityTxt.Text + "' , '" + wardTxt.Text + "', '" + distTxt.Text + "' ,'" + proviTxt.Text + "' , '" + contact.Text + "' , '" + whoose.Text + "' , '" + specify.Text + "', '" + admissionDate.Text + "','" + dobtxtAD.Text + "', '" + dobTxtBS.Text + "', '" + fatherTxt.Text + "', '" + motherTxt.Text + "')");
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
                regid.Focus();
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

        private void AddStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (regid.Text == "")
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
            }
            try
            {
                ob.cn.Open();
                ob.fetch("Select * from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "' or regid='" + regid.Text + "' or symbolno='" + symbol.Text + "'");
                ob.cn.Close();
                if (ob.ds.Tables[0].Rows.Count > 0)
                {
                    ob.cn.Close();
                    ob.cn.Open();
                    ob.dmlstmt("delete from addStudents where classes='" + classss.Text + "' and sec='" + sec.Text + "'and stream='" + stream.Text + "' and rollno='" + rollno.Text + "' or regid='" + regid.Text + "' or symbolno='" + symbol.Text + "' ");
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

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    namess.Focus();
                    namess.SelectAll();
                }
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    symbol.Focus();
                    symbol.SelectAll();

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

        private void regid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                regid.BackColor = System.Drawing.Color.Red;
                regid.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                regid.BackColor = System.Drawing.Color.White;
                regid.ForeColor = System.Drawing.Color.Black;
            }
            
        }

        private void symbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                symbol.BackColor = System.Drawing.Color.Red;
                symbol.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                symbol.BackColor = System.Drawing.Color.White;
                symbol.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                contact.BackColor = System.Drawing.Color.Red;
                contact.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                contact.BackColor = System.Drawing.Color.White;
                contact.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void specify_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                specify.BackColor = System.Drawing.Color.Red;
                specify.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                specify.BackColor = System.Drawing.Color.White;
                specify.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void stream_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dobTxtBS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    dobtxtAD.Focus();
                    dobtxtAD.Select();
                }
            }
        }

        private void dobTxtBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!dobTxtBS.Text.Contains("."))
                    {
                        int iLength = dobTxtBS.Text.Replace("/", "").Length;
                        if (iLength == 4 || iLength == 6)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                dobTxtBS.AppendText("/");
                            }
                        }
                    }
                }
            }
            else
            {
                if (dobTxtBS.Text.LastIndexOf("-") == dobTxtBS.Text.Length - 2 & dobTxtBS.Text.LastIndexOf("-") != -1)
                {
                    dobTxtBS.Text = dobTxtBS.Text.Remove(dobTxtBS.Text.LastIndexOf("-"), 1);
                    dobTxtBS.SelectionStart = dobTxtBS.Text.Length;
                }
            }
        }

        private void dobTxtBS_Leave(object sender, EventArgs e)
        {
            try
            {
                dobtxtAD.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(dobTxtBS.Text).ToShortDateString();
            }
            catch (Exception ex)
            {
                //dobtxtAD.Text = ex.Message;
            }
        }

        private void dobtxtAD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dobTxtBS.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToBS(dobtxtAD.Value);
                //DipeshNepaliDateConversion.DipeshNepaliDateConverter.addEditNepaliMonths();
            }
            catch (Exception ex)
            {
                dobTxtBS.Text = ex.Message;
            }
        }

        private void dobtxtAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    fatherTxt.Focus();
                    fatherTxt.SelectAll();

                }
            }
        }

        private void fatherTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    motherTxt.Focus();
                    motherTxt.SelectAll();

                }
            }
        }

        private void fatherTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                fatherTxt.BackColor = System.Drawing.Color.Red;
                fatherTxt.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                fatherTxt.BackColor = System.Drawing.Color.White;
                fatherTxt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void fatherTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            fatherTxt.Text = textInfo.ToTitleCase(fatherTxt.Text);
            this.fatherTxt.SelectionStart = fatherTxt.Text.Length;
        }

        private void motherTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                motherTxt.BackColor = System.Drawing.Color.Red;
                motherTxt.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                motherTxt.BackColor = System.Drawing.Color.White;
                motherTxt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void motherTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    municipalityTxt.Focus();
                    municipalityTxt.SelectAll();

                }
            }
        }

        private void motherTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            motherTxt.Text = textInfo.ToTitleCase(motherTxt.Text);
            this.motherTxt.SelectionStart = motherTxt.Text.Length;
        }

        private void municipalityTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    wardTxt.Focus();
                    wardTxt.SelectAll();

                }
            }
        }

        private void wardTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    distTxt.Focus();
                    distTxt.SelectAll();

                }
            }
        }

        private void distTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    proviTxt.Focus();
                    proviTxt.SelectAll();

                }
            }
        }

        private void proviTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    admissionDate.Focus();
                    admissionDate.SelectAll();

                }
            }
        }

        private void municipalityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                municipalityTxt.BackColor = System.Drawing.Color.Red;
                municipalityTxt.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                municipalityTxt.BackColor = System.Drawing.Color.White;
                municipalityTxt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void wardTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                wardTxt.BackColor = System.Drawing.Color.Red;
                wardTxt.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                wardTxt.BackColor = System.Drawing.Color.White;
                wardTxt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void municipalityTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            municipalityTxt.Text = textInfo.ToTitleCase(municipalityTxt.Text);
            this.municipalityTxt.SelectionStart = municipalityTxt.Text.Length;
        }

        private void admissionDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                contact.Focus();
                contact.SelectAll();
            }
        }

        private void admissionDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!admissionDate.Text.Contains("."))
                    {
                        int iLength = admissionDate.Text.Replace("-", "").Length;
                        if (iLength == 4 || iLength == 6)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                admissionDate.AppendText("-");
                            }
                        }
                    }
                }
            }
            else
            {
                if (admissionDate.Text.LastIndexOf("-") == admissionDate.Text.Length - 2 & admissionDate.Text.LastIndexOf("-") != -1)
                {
                    admissionDate.Text = admissionDate.Text.Remove(admissionDate.Text.LastIndexOf("-"), 1);
                    admissionDate.SelectionStart = admissionDate.Text.Length;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(admissionDate.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

            string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
            if (nepalidate == string.Empty || nepalidate == null) return;
            admissionDate.Text = nepalidate;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(dobTxtBS.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

            string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
            if (nepalidate == string.Empty || nepalidate == null) return;
            dobTxtBS.Text = nepalidate;
        }

        private void namess_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            namess.Text = textInfo.ToTitleCase(namess.Text);
            this.namess.SelectionStart = namess.Text.Length;
        }

        private void regid_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            regid.Text = textInfo.ToUpper(regid.Text);
            this.regid.SelectionStart = regid.Text.Length;
        }

        private void symbol_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            symbol.Text = textInfo.ToUpper(symbol.Text);
            this.symbol.SelectionStart = symbol.Text.Length;
        }

        private void dobTxtBS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dobtxtAD.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(dobTxtBS.Text).ToShortDateString();
            }
            catch (Exception ex)
            {
                //dobtxtAD.Text = ex.Message;
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

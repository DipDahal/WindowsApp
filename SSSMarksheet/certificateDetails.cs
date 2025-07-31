using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSSMarksheet.Properties;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace SSSMarksheet
{
    public partial class certificateDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

        DataSet ds = new DataSet();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsource = new BindingSource();
        sqlHelper ob = new sqlHelper();
        int counter = 0; // end-to-end row number in an array of strings that are output
        int curPage;
        public certificateDetails()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Regular), Brushes.Black, new Point(650, 128));

            }
            Image image = Resources.CertificateXIXII;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 350));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(540, 345));
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(420, 380));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(500, 380));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(540, 408));
            
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 525));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 525));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(200, 555));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 555));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 585));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += "Province:".Trim().Length * 8 + 5;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += proviTxt.Text.Trim().Length * 8 + 4;
            Padd += 20;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));

           


            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(275, 887));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(380, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 5;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += proviTxt.Text.Trim().Length * 8 + 4;
            /*
            add += 11;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";
            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }
            if (gpaTxt.Text == "")
            {
                MessageBox.Show("GPA cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpaTxt.Focus();
                return;
            }
            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "', iemis='" + iemis.Text + "' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','" + iemis.Text + "')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namess.Text == "")
            {
                MessageBox.Show("Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            
        }

        private void regid_KeyDown(object sender, KeyEventArgs e)
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

        private void symbol_KeyDown(object sender, KeyEventArgs e)
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

        private void namess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    classCombo.Focus();
                    classCombo.SelectAll();

                }
            }
        }

        private void classCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    streamCombo.Focus();
                    streamCombo.SelectAll();

                }
            }
        }

        private void streamCombo_KeyDown(object sender, KeyEventArgs e)
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

        private void dobTxtBS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    dobtxtAD.Focus();
                    //dobtxtAD.SelectAll();

                }
            }
        }

        private void dobtxtAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    sessionFrom.Focus();
                    sessionFrom.SelectAll();

                }
            }
        }

        private void sessionFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    sessionTo.Focus();
                    sessionTo.SelectAll();

                }
            }
        }

        private void sessionTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    gpaTxt.Focus();
                    gpaTxt.SelectAll();

                }
            }
        }

        private void gpaTxt_KeyDown(object sender, KeyEventArgs e)
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
                    issuedate.Focus();
                    issuedate.SelectAll();

                }
            }
        }

        private void issuedate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                //button1.PerformClick();
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

        private void namess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')')
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

        private void gpaTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                gpaTxt.BackColor = System.Drawing.Color.Red;
                gpaTxt.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                gpaTxt.BackColor = System.Drawing.Color.White;
                gpaTxt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void fatherTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')')
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

        private void motherTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')')
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

        private void municipalityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '.')
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

        private void streamCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void certificateDetails_Load(object sender, EventArgs e)
        {
            classCombo.SelectedIndex = classCombo.Items.IndexOf("SEE");
            streamCombo.SelectedIndex = streamCombo.Items.IndexOf("General");
            distTxt.SelectedIndex = distTxt.Items.IndexOf("Jhapa");
            proviTxt.Text = "1";
            sessionFrom.Text = "2077";
            sessionTo.Text = "2078";
            btn_SLC.Visible = false;
            try
            {
                issuedate.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToBS(dobtxtAD.Value);
                //DipeshNepaliDateConversion.DipeshNepaliDateConverter.addEditNepaliMonths();
                division();
            }
            catch (Exception ex)
            {
                issuedate.Text = ex.Message;
            }
            autoInctrementSerialNumber();
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
                        if (iLength== 4 || iLength == 6 )
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

        private void changeWard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                changeWard.BackColor = System.Drawing.Color.Red;
                changeWard.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                changeWard.BackColor = System.Drawing.Color.White;
                changeWard.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void dobtxtAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void issuedate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!issuedate.Text.Contains("."))
                    {
                        int iLength = issuedate.Text.Replace("-", "").Length;
                        if (iLength == 4 || iLength == 6)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                issuedate.AppendText("-");
                            }
                        }
                    }
                }
            }
            else
            {
                if (issuedate.Text.LastIndexOf("-") == issuedate.Text.Length - 2 & issuedate.Text.LastIndexOf("-") != -1)
                {
                    issuedate.Text = issuedate.Text.Remove(issuedate.Text.LastIndexOf("-"), 1);
                    issuedate.SelectionStart = issuedate.Text.Length;
                }
            }
        }

        private void classCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            YearConversion();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.Certificate1To8;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));


            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 305));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 335));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 335));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 365));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 365));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(565, 365));

            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 395));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(280, 395));


            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(520, 395));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(600, 395));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(395, 423));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(575, 423));

            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 513));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 542));
            e.Graphics.DrawString(textBox1.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(330, 542));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 585));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 585));

            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));
            Padd += wardTxt.Text.Trim().Length * 8 + 2;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));
            Padd += distTxt.Text.Trim().Length * 8 + 2;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));
            Padd += "Province:".Trim().Length * 8 + 5;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));
            Padd += proviTxt.Text.Trim().Length * 8 + 2;
            Padd += 20;
            e.Graphics.DrawString("  Nepal".ToString(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 570));




            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 851));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(620, 851));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(140, 889));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(295, 889));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(400, 889));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(595, 889));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(715, 889));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(170, 924));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(520, 924));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 964));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += wardTxt.Text.Trim().Length * 8;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += distTxt.Text.Trim().Length * 8 + 2;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += "Province:".Trim().Length * 8 + 3;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += proviTxt.Text.Trim().Length * 8;
            /*
            add += 9;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 964));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(700, 964));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 1000));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 661));
            
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.CertificateSEE;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(460, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(445, 350));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(550, 350));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(630, 380));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(170, 408));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 525));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 525));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(200, 555));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 555));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 585));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += "Province:".Trim().Length * 8 + 4;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += proviTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));




            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(270, 887));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(380, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8 + 2;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 3;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += proviTxt.Text.Trim().Length * 8;
            /*
            add += 9;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

        }

        private void button4OneToEight_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }
            
            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='/*/' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "',iemis='"+iemis.Text+"' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('/*/' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','" + iemis.Text + "')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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

        }

        private void button4SEE_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = ""; 
            
            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }
            if (gpaTxt.Text == "")
            {
                MessageBox.Show("GPA cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpaTxt.Focus();
                return;
            }
            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            printPreviewDialog3.Document = printDocument3;
            printPreviewDialog3.ShowDialog();
            if (printDialog3.ShowDialog() == DialogResult.OK)
            {
                printDocument3.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "',iemis='" + iemis.Text + "' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','" + iemis.Text + "')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            counter = 0;
            curPage = 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void dobTxtBS_TextChanged(object sender, EventArgs e)
        {

        }

        private void dobtxtAD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dobtxtAD_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    sessionFrom.Focus();
                    sessionFrom.SelectAll();

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(issuedate.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

            string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
            if (nepalidate == string.Empty || nepalidate == null) return;
            issuedate.Text = nepalidate;
        }

        private void regid_TextChanged(object sender, EventArgs e)
        {
            if (regid.Text.Length <= 0) return;
            string s = regid.Text.Substring(0, 1);
            if (s != s.ToUpper())
            {
                int curSelStart = regid.SelectionStart;
                int curSelLength = regid.SelectionLength;
                regid.SelectionStart = 0;
                regid.SelectionLength = 1;
                regid.SelectedText = s.ToUpper();
                regid.SelectionStart = curSelStart;
                regid.SelectionLength = curSelLength;
            }
        }
        protected void FillCertificateUpdateEntry()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                    ob.cn.Open();
                    ob.fetch("select distinct regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis from certificateDetails where regid='" + regid.Text + "' or symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        ob.cn.Close();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select distinct regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis from certificateDetails where regid='" + regid.Text + "' or symbol='" + symbol.Text + "' ", conn);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            regid.Text = reader["regid"].ToString();
                            symbol.Text = reader["symbol"].ToString();
                            namess.Text = reader["studName"].ToString();
                            classCombo.Text = reader["className"].ToString();
                            streamCombo.Text = reader["streamName"].ToString();
                            dobTxtBS.Text = reader["dobBS"].ToString();
                            dobtxtAD.Text = reader["dobAD"].ToString();
                            sessionFrom.Text = reader["sessionFrom"].ToString();
                            sessionTo.Text = reader["sessionTo"].ToString();
                            fatherTxt.Text = reader["fatherName"].ToString();
                            motherTxt.Text = reader["motherName"].ToString();
                            municipalityTxt.Text = reader["municipal"].ToString();
                            wardTxt.Text = reader["wardNo"].ToString();
                            distTxt.Text = reader["district"].ToString();
                            proviTxt.Text = reader["province"].ToString();
                            gpaTxt.Text = reader["gpa"].ToString();
                            issuedate.Text = reader["issuedate"].ToString();
                            serialNo.Text = reader["snoUpdate"].ToString();
                            iemis.Text = reader["iemis"].ToString();
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

        protected void autoInctrementSerialNumber()
        {
            string conString = @"Data Source=DESKTOP-LO28UO1\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select max(snoUpdate) from certificateDetails ", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int a = Convert.ToInt32(reader[0].ToString());
                    string b = a.ToString();
                    int len = b.Length;
                    if (len == 1)
                    {
                        int c = a + 1;
                        serialNo.Text = "000"+c.ToString();
                        reader.Close();
                        conn.Close();
                    }
                    else if (len == 2)
                    {
                        int c = a + 1;
                        serialNo.Text = "00" + c.ToString();
                        reader.Close();
                        conn.Close();
                    }
                    else if (len == 3)
                    {
                        int c = a + 1;
                        serialNo.Text = "0" + c.ToString();
                        reader.Close();
                        conn.Close();
                    }
                    else
                    {
                        int c = a + 1;
                        serialNo.Text = c.ToString();
                        reader.Close();
                        conn.Close();
                    }
                    
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void regid_Leave(object sender, EventArgs e)
        {
        }
        protected void ValidationForBlank()
        {
            

        }

        private void regid_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            regid.Text = textInfo.ToTitleCase(regid.Text);
            this.regid.SelectionStart = regid.Text.Length;
        }

        private void symbol_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            symbol.Text = textInfo.ToTitleCase(symbol.Text);
            this.symbol.SelectionStart = symbol.Text.Length;
        }

        private void namess_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            namess.Text = textInfo.ToTitleCase(namess.Text);
            this.namess.SelectionStart = namess.Text.Length;
        }

        private void fatherTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            fatherTxt.Text = textInfo.ToTitleCase(fatherTxt.Text);
            this.fatherTxt.SelectionStart = fatherTxt.Text.Length;
        }

        private void motherTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            motherTxt.Text = textInfo.ToTitleCase(motherTxt.Text);
            this.motherTxt.SelectionStart = motherTxt.Text.Length;
        }

        private void municipalityTxt_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            municipalityTxt.Text = textInfo.ToTitleCase(municipalityTxt.Text);
            this.municipalityTxt.SelectionStart = municipalityTxt.Text.Length;
        }

        private void classCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (classCombo.Text.ToString() == "SEE")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = true;
                button4OneToEight.Visible = false;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = false;
            }
            else if (classCombo.Text.ToString() == "11" || classCombo.Text.ToString() == "12")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = true;
            }
            else if (classCombo.Text.ToString() == "SLC")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = true;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = false;
            }
            else if (classCombo.Text.ToString() == "SLC(Old)")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = true;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = false;
            }
            else if (classCombo.Text.ToString() == "12(New)")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = true;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = false;
            }
            else if (classCombo.Text.ToString() == "12(Old)")
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                button4XIXII.Visible = false;
                btnXIIOld.Visible = true;
            }
            else if (classCombo.Text.ToString() == "Current")
            {
                txtClass.Visible = true;
                btnCurrent.Visible = true;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                button4XIXII.Visible = false;
                btnXIIOld.Visible = false;
            }
            else
            {
                txtClass.Visible = false;
                btnCurrent.Visible = false;
                btn12New.Visible = false;
                SLCOLD.Visible = false;
                btn_SLC.Visible = false;
                button4SEE.Visible = false;
                button4OneToEight.Visible = true;
                btnXIIOld.Visible = false;
                button4XIXII.Visible = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
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
        private void YearConversion()
        {
            try
            {
                String str = "01/01/" + sessionTo.Text.ToString();
                DateTime oDate = DateTime.Parse(str);
                int adDate = Convert.ToInt16(oDate.Year.ToString()) - 57;
                yearAd.Text = adDate.ToString();
            }catch(Exception e)
            {
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            FillCertificateUpdateEntry();
        }

        private void btn_SLC_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";
           

            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }
           
            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            
            printPreviewDialog4.Document = printDocument4;
            printPreviewDialog4.ShowDialog();
            if (printDialog4.ShowDialog() == DialogResult.OK)
            {
                printDocument4.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "', iemis='"+iemis.Text+"' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','"+iemis.Text+"')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.CertificateSLC;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            
            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(460, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(445, 350));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(550, 350));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(630, 380));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(170, 408));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 525));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 525));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(200, 555));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 555));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 585));
            e.Graphics.DrawString(textBox1.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(380, 585));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 585));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 585));

            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += "Province:".Trim().Length * 8 ;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += proviTxt.Text.Trim().Length * 8 + 4;
            Padd += 20;
            e.Graphics.DrawString(" Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));




            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(270, 887));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(380, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 3;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            /*
            add += proviTxt.Text.Trim().Length * 8 + 2;
            add += 9;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */

            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

        }

        private void printPreviewDialog3_Load(object sender, EventArgs e)
        {

        }

        private void SLCOLD_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";


            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }

            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Percentage cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            printPreviewDialog5.Document = printDocument5;
            printPreviewDialog5.ShowDialog();
            if (printDialog5.ShowDialog() == DialogResult.OK)
            {
                printDocument5.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void printDocument5_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.CertificateSLCOld;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(440, 351));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(550, 350));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(560, 379));
            e.Graphics.DrawString(yearAd.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(655, 380));

            e.Graphics.DrawString(divisionText.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(350, 408));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 495));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 495));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(220, 525));
            e.Graphics.DrawString(divisionText.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(145, 555));
            e.Graphics.DrawString((textBox1.Text + "  %").Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(380, 555));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 525));

            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 585));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 586));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 10;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 585));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 585));
            Padd += "Province:".Trim().Length * 8;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 586));
            Padd += proviTxt.Text.Trim().Length * 8 + 4;
            Padd += 20;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 585));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString("SLC".ToString().Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(305, 887));//
            e.Graphics.DrawString(divisionText.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(420, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
            e.Graphics.DrawString(textBox1.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
           

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8;
            add += 10;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 1;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            /*
             add += proviTxt.Text.Trim().Length * 8;
            add += 10;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

        }
        private void division()
        {
            try
            {
                double percentage = Convert.ToDouble(textBox1.Text.ToString());

                if (percentage >= 60)
                {
                    divisionText.Text = "1st".ToString();
                    textPassFail.Text = "%".ToString();
                }
                else if (percentage >= 45 && percentage < 60)
                {
                    divisionText.Text = "2nd".ToString();
                    textPassFail.Text = "%".ToString();
                }
                else if (percentage >= 32 && percentage < 45)
                {
                    divisionText.Text = "3rd".ToString();
                    textPassFail.Text = "%".ToString();
                }
                else
                {
                    divisionText.Text = "fail".ToString();
                    textPassFail.Text = "%".ToString();
                }
            }catch(Exception e)
            {
            }
            

        }
        private void sessionTo_TextChanged(object sender, EventArgs e)
        {
            YearConversion();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            division();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";


            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }

            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }

            printPreviewDialog6.Document = printDocument6;
            printPreviewDialog6.ShowDialog();
            if (printDialog6.ShowDialog() == DialogResult.OK)
            {
                printDocument6.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "',iemis='"+iemis.Text+"' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','"+iemis.Text+"')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void printDocument6_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.CertificateXII;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(175, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(465, 350));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(575, 350));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(250, 408));
            e.Graphics.DrawString(yearAd.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(370, 408));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(540, 408));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 525));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 525));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(200, 555));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 555));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 585));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += "Province:".Trim().Length * 8 + 2;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));
            Padd += proviTxt.Text.Trim().Length * 8 + 4;
            Padd += 20;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 613));




            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString("12".ToString().Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(275, 887));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(380, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 3;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            /*
             add += proviTxt.Text.Trim().Length * 8 + 2;
            add += 9;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";


            if (regid.Text == "")
            {
                MessageBox.Show("Registration Id cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regid.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }

            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                
            }

            printPreviewDialog7.Document = printDocument7;
            printPreviewDialog7.ShowDialog();
            if (printDialog7.ShowDialog() == DialogResult.OK)
            {
                printDocument7.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='" + regid.Text + "' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + classCombo.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "',iemis='"+iemis.Text+"' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('" + regid.Text + "' , '" + symbol.Text + "', '" + namess.Text + "' , '" + classCombo.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','"+iemis.Text+"')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void printDocument7_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.CertificateXIIOLD;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 290));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 320));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 320));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(165, 350));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(440, 351));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(550, 350));
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(350, 410));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 410));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(588, 410));

            e.Graphics.DrawString(divisionText.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(625, 438));

            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(195, 525));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(405, 525));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(220, 555));
            //e.Graphics.DrawString(divisionText.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 585));
            e.Graphics.DrawString((textBox1.Text + textPassFail.Text.Trim()).Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 585));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 555));

            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));
            Padd += wardTxt.Text.Trim().Length * 8;
            Padd += 10;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));
            Padd += distTxt.Text.Trim().Length * 8;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));
            Padd += "Province:".Trim().Length * 8;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));
            Padd += proviTxt.Text.Trim().Length * 8 + 4;
            Padd += 20;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 612));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 849));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(610, 849));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(135, 887));
            e.Graphics.DrawString("XI/XII".ToString().Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(265, 887));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(400, 887));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(585, 887));
          //  e.Graphics.DrawString(textBox1.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));
            e.Graphics.DrawString((textBox1.Text + textPassFail.Text.Trim()).Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(710, 887));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(165, 922));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(525, 922));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 960));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += wardTxt.Text.Trim().Length * 8;
            add += 10;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += distTxt.Text.Trim().Length * 8;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            add += "Province:".Trim().Length * 8 + 1;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            /*
             add += proviTxt.Text.Trim().Length * 8;
            add += 10;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 960));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 960));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(685, 960));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 997));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 681));

        }

        private void printPreviewDialog6_Load(object sender, EventArgs e)
        {

        }

        private void printDocument8_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                e.Graphics.DrawString("Copy of Original".ToString(), new Font("Gabriola", 16, FontStyle.Italic), Brushes.Black, new Point(600, 128));

            }
            Image image = Resources.Certificate1To8Current;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(txtCopyOfOriginal.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(650, 80));


            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(320, 305));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(100, 335));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(455, 335));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(195, 365));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(470, 369));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(595, 365));

            e.Graphics.DrawString(txtClass.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(680, 397));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(140, 425));

            
            e.Graphics.DrawString(textBox2.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(305, 397));
            e.Graphics.DrawString(textBox4.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(400, 457));
            
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(620, 425));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(80, 454));

            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(450, 542));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(125, 572));
            e.Graphics.DrawString(textBox1.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(330, 572));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));

            int Padd = 230;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));
            Padd += municipalityTxt.Text.Trim().Length * 8;
            Padd += 20;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));
            Padd += wardTxt.Text.Trim().Length * 8 + 2;
            Padd += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));
            Padd += distTxt.Text.Trim().Length * 8 + 2;
            Padd += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));
            Padd += "Province:".Trim().Length * 8 + 5;
            e.Graphics.DrawString(proviTxt.Text.Trim() + ", ", new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));
            Padd += proviTxt.Text.Trim().Length * 8 + 2;
            Padd += 20;
            e.Graphics.DrawString("  Nepal".ToString(), new Font("Gabriola", 16, FontStyle.Bold), Brushes.Black, new Point(Padd, 600));




            e.Graphics.DrawString(namess.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(180, 851));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(620, 851));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(140, 889));
            e.Graphics.DrawString(txtClass.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(285, 889));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(400, 889));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Cambria", 10, FontStyle.Italic), Brushes.Black, new Point(595, 889));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(715, 889));
            e.Graphics.DrawString("IEMIS CODE: ", new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(475, 586));
            e.Graphics.DrawString(iemis.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(570, 586));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(170, 924));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(520, 924));

            int add = 120;
            e.Graphics.DrawString(municipalityTxt.Text.Trim() + " - ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(120, 964));
            add += municipalityTxt.Text.Trim().Length * 8;
            add += 19;
            e.Graphics.DrawString(wardTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += wardTxt.Text.Trim().Length * 8;
            add += 9;
            e.Graphics.DrawString(distTxt.Text.Trim() + ", ", new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += distTxt.Text.Trim().Length * 8 + 2;
            add += 18;
            e.Graphics.DrawString("Province:".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += "Province:".Trim().Length * 8 + 3;
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            add += proviTxt.Text.Trim().Length * 8;
            /*
            add += 9;
            e.Graphics.DrawString("Nepal".Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(add, 964));
            */
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(605, 964));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(700, 964));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Cambria", 11, FontStyle.Italic), Brushes.Black, new Point(150, 1000));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(175, 691));

            e.Graphics.DrawString("Admitted Date: "+textBox2.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(325, 1000));
            e.Graphics.DrawString("Left Date: " + textBox4.Text.Trim(), new Font("Lucida Handwriting", 9, FontStyle.Bold), Brushes.Black, new Point(555, 1000));

        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            if (chkCopy.Checked == true)
            {
                txtCopyOfOriginal.Text = "Copy of Original";

            }
            else
                txtCopyOfOriginal.Text = "";
            if (textBox2.Text == "")
            {
                MessageBox.Show("Admission Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Left Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (symbol.Text == "")
            {
                MessageBox.Show("Symbol Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                symbol.Focus();
                return;
            }
            if (txtClass.Text == "")
            {
                MessageBox.Show("Class Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClass.Focus();
                return;
            }
            if (namess.Text == "")
            {
                MessageBox.Show("Student Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                namess.Focus();
                return;
            }
            if (classCombo.Text == "")
            {
                MessageBox.Show("Class cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                classCombo.Focus();
                return;
            }
            if (streamCombo.Text == "")
            {
                MessageBox.Show("Stream cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamCombo.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (dobTxtBS.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobTxtBS.Focus();
                return;
            }
            if (dobtxtAD.Text == "")
            {
                MessageBox.Show("Date Of Birth cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dobtxtAD.Focus();
                return;
            }
            if (sessionFrom.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionFrom.Focus();
                return;
            }
            if (sessionTo.Text == "")
            {
                MessageBox.Show("Session cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionTo.Focus();
                return;
            }

            if (fatherTxt.Text == "")
            {
                MessageBox.Show("Father's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fatherTxt.Focus();
                return;
            }
            if (motherTxt.Text == "")
            {
                MessageBox.Show("Mother's Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                motherTxt.Focus();
                return;
            }
            if (municipalityTxt.Text == "")
            {
                MessageBox.Show("Municipility cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (issuedate.Text == "")
            {
                MessageBox.Show("Issue Date cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            if (serialNo.Text == "")
            {
                MessageBox.Show("Serial Number cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proviTxt.Focus();
                return;
            }
            printPreviewDialog8.Document = printDocument8;
            printPreviewDialog8.ShowDialog();
            if (printDialog8.ShowDialog() == DialogResult.OK)
            {
                printDocument8.Print();
                try
                {
                    ob.cn.Open();
                    ob.fetch("Select * from certificateDetails where symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("Student data already exists!! Do You want to Update?", "Confirmation",
      MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ob.cn.Open();
                            ob.dmlstmt("Update certificateDetails SET regid='/*/' , symbol='" + symbol.Text + "', studName='" + namess.Text + "' , className='" + txtClass.Text + "' , streamName='" + streamCombo.Text + "' , dobBS='" + dobTxtBS.Text + "' , dobAD='" + dobtxtAD.Text + "' , sessionFrom='" + sessionFrom.Text + "' , sessionTo='" + sessionTo.Text + "' , gpa='" + gpaTxt.Text + "' , fatherName='" + fatherTxt.Text + "' , motherName='" + motherTxt.Text + "', municipal='" + municipalityTxt.Text + "' , wardNo='" + wardTxt.Text + "' , district='" + distTxt.Text + "',province='" + proviTxt.Text + "' , issuedate='" + issuedate.Text + "' , snoUpdate='" + serialNo.Text + "',iemis='"+iemis.Text+"' where regid='" + regid.Text + "' and symbol='" + symbol.Text + "' ");
                            ob.cn.Close();
                            MessageBox.Show("Certificate Details Updated Successfully");
                        }
                        if (result == DialogResult.No)
                        {
                            DialogResult anoth = MessageBox.Show("Do You want to print anyway?", "Confirmation",
      MessageBoxButtons.YesNo);
                            if (anoth == DialogResult.Yes)
                            {
                                return;
                            }

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
                            ob.dmlstmt("Insert into certificateDetails(regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate,iemis) values ('/*/' , '" + symbol.Text + "', '" + namess.Text + "' , '" + txtClass.Text + "' , '" + streamCombo.Text + "' , '" + dobTxtBS.Text + "' , '" + dobtxtAD.Text + "' , '" + sessionFrom.Text + "' ,'" + sessionTo.Text + "' ,'" + gpaTxt.Text + "' ,'" + fatherTxt.Text + "' , '" + motherTxt.Text + "','" + municipalityTxt.Text + "' , '" + wardTxt.Text + "' , '" + distTxt.Text + "','" + proviTxt.Text + "' , '" + issuedate.Text + "' ,'" + serialNo.Text + "','"+iemis.Text+"')");
                            MessageBox.Show("Certificate Details Inserted Successfully");

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
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(textBox2.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

            string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
            if (nepalidate == string.Empty || nepalidate == null) return;
            textBox2.Text = nepalidate;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(textBox4.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

            string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
            if (nepalidate == string.Empty || nepalidate == null) return;
            textBox4.Text = nepalidate;
        }

        private void issuedate_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!textBox2.Text.Contains("."))
                    {
                        int iLength = textBox2.Text.Replace("-", "").Length;
                        if (iLength == 4 || iLength == 6)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                textBox2.AppendText("-");
                            }
                        }
                    }
                }
            }
            else
            {
                if (textBox2.Text.LastIndexOf("-") == textBox2.Text.Length - 2 & textBox2.Text.LastIndexOf("-") != -1)
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.LastIndexOf("-"), 1);
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                //button1.PerformClick();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!textBox4.Text.Contains("."))
                    {
                        int iLength = textBox4.Text.Replace("-", "").Length;
                        if (iLength == 4 || iLength == 6)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                textBox4.AppendText("-");
                            }
                        }
                    }
                }
            }
            else
            {
                if (textBox4.Text.LastIndexOf("-") == textBox4.Text.Length - 2 & textBox4.Text.LastIndexOf("-") != -1)
                {
                    textBox4.Text = textBox4.Text.Remove(textBox4.Text.LastIndexOf("-"), 1);
                    textBox4.SelectionStart = textBox4.Text.Length;
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                //button1.PerformClick();
            }
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

    }
}

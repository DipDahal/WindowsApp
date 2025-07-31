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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FEPJH95\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True");

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
            Image image = Resources.CertificateXIXII;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(358, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 240));
           
            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 285));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(115, 315));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(440, 315));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(105, 345));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(400, 345));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(550, 345));
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(400, 375));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(530, 375));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(550, 405));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(195, 520));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(405, 520));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(200, 550));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(450, 550));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(125, 580));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(230, 610));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 610));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(330, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(355, 610));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(365, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(500, 610));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(510, 610));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(600, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(620, 610));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(630, 610));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(190, 679));



            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(190, 845));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(630, 845));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(140, 885));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(300, 885));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(410, 885));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(595, 885));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(725, 885));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(180, 920));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(550, 920));

            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(120, 955));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(210, 955));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(220, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(245, 955));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(255, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(370, 955));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(380, 955));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(470, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(490, 955));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(500, 955));

            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(635, 955));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(730, 955));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(150, 995));

             
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                gpaTxt.Focus();
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
            pageSetupDialog1.ShowDialog();
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
            try
            {
                issuedate.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToBS(dobtxtAD.Value);
                //DipeshNepaliDateConversion.DipeshNepaliDateConverter.addEditNepaliMonths();
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
            if (classCombo.Text.ToString() == "SEE")
            {
                button4SEE.Visible = true;
                button4OneToEight.Visible = false;
                button4XIXII.Visible = false;
            }
            else if (classCombo.Text.ToString() == "XI" || classCombo.Text.ToString() == "XII")
            {
                button4SEE.Visible = false;
                button4OneToEight.Visible = false;
                button4XIXII.Visible = true;
            }
            else
            {
                button4SEE.Visible = false;
                button4OneToEight.Visible = true;
                button4XIXII.Visible = false;
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = Resources.Certificate1To8;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(358, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 302));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(115, 330));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(440, 330));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(105, 360));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(450, 360));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(600, 360));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(200, 390));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 390));
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(580, 390));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(690, 390));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(470, 420));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(625, 420));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(195, 507));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(445, 507));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(130, 537));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(225, 567));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 567));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(330, 567));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(355, 567));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(365, 567));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(500, 610));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(510, 567));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(600, 567));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(620, 567));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(630, 567));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(180, 655));



            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(190, 845));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(630, 845));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(140, 885));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(300, 885));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(410, 885));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(595, 885));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(725, 885));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(180, 920));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(550, 920));

            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(120, 955));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(210, 955));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(220, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(245, 955));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(255, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(370, 955));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(380, 955));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(470, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(490, 955));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(500, 955));

            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(635, 955));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(730, 955));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(150, 995));

        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = Resources.CertificateSEE;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            e.Graphics.DrawString(changeWard.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(358, 128));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 1032));
            e.Graphics.DrawString(serialNo.Text.Trim(), new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(112, 240));

            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 285));
            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(115, 315));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(440, 315));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(105, 345));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(400, 345));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(550, 345));
            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(400, 375));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(530, 375));
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(450, 405));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(195, 520));
            e.Graphics.DrawString(dobtxtAD.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(405, 520));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(200, 550));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(450, 550));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(125, 580));
            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(230, 610));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(320, 610));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(330, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(355, 610));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(365, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(500, 610));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(510, 610));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(600, 610));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(620, 610));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(630, 610));
            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(190, 679));



            e.Graphics.DrawString(namess.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(190, 845));
            e.Graphics.DrawString(regid.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(630, 845));
            e.Graphics.DrawString(symbol.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(140, 885));
            e.Graphics.DrawString(classCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(300, 885));//
            e.Graphics.DrawString(streamCombo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(410, 885));
            e.Graphics.DrawString(dobTxtBS.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(595, 885));
            e.Graphics.DrawString(gpaTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(725, 885));

            e.Graphics.DrawString(fatherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(180, 920));
            e.Graphics.DrawString(motherTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(550, 920));

            e.Graphics.DrawString(municipalityTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(120, 955));
            e.Graphics.DrawString("-".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(210, 955));
            e.Graphics.DrawString(wardTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(220, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 14, FontStyle.Italic), Brushes.Black, new Point(245, 955));
            e.Graphics.DrawString(distTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(255, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(370, 955));//
            e.Graphics.DrawString("Province: ".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(380, 955));
            e.Graphics.DrawString(proviTxt.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(470, 955));
            e.Graphics.DrawString(",".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(490, 955));
            e.Graphics.DrawString("Nepal".Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(500, 955));

            e.Graphics.DrawString(sessionFrom.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(635, 955));
            e.Graphics.DrawString(sessionTo.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(730, 955));


            e.Graphics.DrawString(issuedate.Text.Trim(), new Font("Calibri", 12, FontStyle.Italic), Brushes.Black, new Point(150, 995));

        }

        private void button4OneToEight_Click(object sender, EventArgs e)
        {
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
                gpaTxt.Focus();
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
            pageSetupDialog1.ShowDialog();
            printPreviewDialog2.ShowDialog();
            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
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

        private void button4SEE_Click(object sender, EventArgs e)
        {
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
                gpaTxt.Focus();
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
            pageSetupDialog1.ShowDialog();
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
            this.Close();
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
            string conString = @"Data Source=DESKTOP-FEPJH95\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                    ob.cn.Open();
                    ob.fetch("select distinct regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate from certificateDetails where regid='" + regid.Text + "' or symbol='" + symbol.Text + "' ");
                    ob.cn.Close();
                    if (ob.ds.Tables[0].Rows.Count > 0)
                    {
                        ob.cn.Close();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select distinct regid, symbol, studName, className, streamName, dobBS, dobAD , sessionFrom, sessionTo, gpa, fatherName, motherName, municipal, wardNo , district,province, issuedate, snoUpdate from certificateDetails where regid='" + regid.Text + "' or symbol='" + symbol.Text + "' ", conn);

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

                            reader.Close();
                            conn.Close();
                        }
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
        protected void autoInctrementSerialNumber()
        {
            string conString = @"Data Source=DESKTOP-FEPJH95\SQLEXPRESS;Initial Catalog=SSSMarksheets;Integrated Security=True";
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
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void regid_Leave(object sender, EventArgs e)
        {
            FillCertificateUpdateEntry();
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

    }
}

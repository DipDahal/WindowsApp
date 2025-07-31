using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DipeshNepaliDateConverter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToBS(dateTimePicker1.Value);
                //DipeshNepaliDateConversion.DipeshNepaliDateConverter.addEditNepaliMonths();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lblenglish.Text = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(txtnepalidate.Text).ToShortDateString();
            }
            catch (Exception ex)
            {
                lblenglish.Text = ex.Message;
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btndatesettings_Click(object sender, EventArgs e)
        {
            DipeshNepaliDateConversion.DipeshNepaliDateConverter.addEditNepaliMonths();
        }

        private void btndatepick_Click(object sender, EventArgs e)
        {
            DateTime focusdate;
            try
            {
                focusdate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.convertToAD(txtnepalidate.Text);
            }
            catch (Exception)
            {
                focusdate = DateTime.Today;
            }

           string nepalidate = DipeshNepaliDateConversion.DipeshNepaliDateConverter.pickNepaliDate(focusdate);
           if (nepalidate == string.Empty || nepalidate == null) return;
           txtnepalidate.Text = nepalidate;
        }
    }
}

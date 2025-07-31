using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSSMarksheet
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentNew ads = new AddStudentNew();
            ads.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation",
  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (result == DialogResult.No)
            {
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddSubjects ad = new AddSubjects();
            ad.ShowDialog();
        }

        private void buttonCreateAcc_Click(object sender, EventArgs e)
        {
            subjectMarks ad = new subjectMarks();
            ad.ShowDialog();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            AddMarks ad = new AddMarks();
            ad.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            AddMarks ad = new AddMarks();
            ad.ShowDialog();
        }

        private void buttonCashIn_Click(object sender, EventArgs e)
        {
            SubjectCreditHour ad = new SubjectCreditHour();
            ad.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Marksheet ad = new Marksheet();
            ad.ShowDialog();
        }

        private void buttonLedger_Click(object sender, EventArgs e)
        {
            marksLedger ad = new marksLedger();
            ad.ShowDialog();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            Attendance ad = new Attendance();
            ad.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentNew ads = new AddStudentNew();
            ads.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSubjects ad = new AddSubjects();
            ad.ShowDialog();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            subjectMarks ad = new subjectMarks();
            ad.ShowDialog();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SubjectCreditHour ad = new SubjectCreditHour();
            ad.ShowDialog();
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Attendance ad = new Attendance();
            ad.ShowDialog();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            marksLedger ad = new marksLedger();
            ad.ShowDialog();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Marksheet ad = new Marksheet();
            ad.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void subjectCreditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SubjectCreditHour cr = new SubjectCreditHour();
            cr.ShowDialog();
        }

        private void studentsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsReport sr = new StudentsReport();
            sr.ShowDialog();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subjectReport sr = new subjectReport();
            sr.ShowDialog();
        }

        private void subjectMarksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            subjectMarksReport sr = new subjectMarksReport();
            sr.ShowDialog();
        }

        private void attendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AttendanceReport sr = new AttendanceReport();
            sr.ShowDialog();
        }

        private void marksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            certificateDetails sr = new certificateDetails();
            sr.ShowDialog();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation",
 MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (result == DialogResult.No)
            {
                return;
            }
        }

        private void transferCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            certificateDetails sr = new certificateDetails();
            sr.ShowDialog();
        }

        private void certiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsCertificateReport cr = new StudentsCertificateReport();
            cr.ShowDialog();
        }

        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            AddMarks cr = new AddMarks();
            cr.ShowDialog();
        }

      

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateMarksEntry cr = new UpdateMarksEntry();
            cr.ShowDialog();
        }

        private void buttonLedger_Click_1(object sender, EventArgs e)
        {
            letter cr = new letter();
            cr.ShowDialog();
        }

        private void letterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            letter cr = new letter();
            cr.ShowDialog();
        }

        private void addStudentsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ad = new AddStudent();
            ad.ShowDialog();
        }
    }
}

namespace SSSMarksheet
{
    partial class AttendanceReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Absent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button16 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboTerminal = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWorkingDays = new System.Windows.Forms.TextBox();
            this.comboStream = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.comboSec = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.names,
            this.subject,
            this.Present,
            this.Absent});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(547, 573);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // SNo
            // 
            this.SNo.HeaderText = "SNo";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            this.SNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SNo.Width = 50;
            // 
            // names
            // 
            this.names.HeaderText = "Name";
            this.names.Name = "names";
            this.names.ReadOnly = true;
            this.names.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.names.Width = 250;
            // 
            // subject
            // 
            this.subject.HeaderText = "Roll No";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            this.subject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subject.Width = 80;
            // 
            // Present
            // 
            this.Present.HeaderText = "Present";
            this.Present.Name = "Present";
            this.Present.ReadOnly = true;
            this.Present.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Present.Width = 80;
            // 
            // Absent
            // 
            this.Absent.HeaderText = "Absent";
            this.Absent.Name = "Absent";
            this.Absent.ReadOnly = true;
            this.Absent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Absent.Width = 80;
            // 
            // button16
            // 
            this.button16.AutoSize = true;
            this.button16.BackColor = System.Drawing.Color.Red;
            this.button16.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.Transparent;
            this.button16.Location = new System.Drawing.Point(510, 0);
            this.button16.Margin = new System.Windows.Forms.Padding(2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(35, 36);
            this.button16.TabIndex = 9;
            this.button16.Text = "X";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 680);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1341, 31);
            this.panel1.TabIndex = 73;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calisto MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(128, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(274, 28);
            this.label15.TabIndex = 12;
            this.label15.Text = "Student Attendance Report";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(4, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(547, 573);
            this.panel4.TabIndex = 71;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.comboTerminal);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.txtWorkingDays);
            this.panel5.Controls.Add(this.comboStream);
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.comboClass);
            this.panel5.Controls.Add(this.comboSec);
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button18);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(548, 66);
            this.panel5.TabIndex = 74;
            // 
            // comboTerminal
            // 
            this.comboTerminal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTerminal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTerminal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTerminal.FormattingEnabled = true;
            this.comboTerminal.Items.AddRange(new object[] {
            "First Terminal Exam",
            "Second Terminal Exam",
            "Half Yearly Exam",
            "Third Terminal Exam",
            "Final Exam"});
            this.comboTerminal.Location = new System.Drawing.Point(171, 34);
            this.comboTerminal.Name = "comboTerminal";
            this.comboTerminal.Size = new System.Drawing.Size(111, 27);
            this.comboTerminal.TabIndex = 110;
            this.comboTerminal.SelectedIndexChanged += new System.EventHandler(this.comboClass_SelectedIndexChanged);
            this.comboTerminal.TextChanged += new System.EventHandler(this.comboStream_TextChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(91, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 28);
            this.button1.TabIndex = 112;
            this.button1.Text = "Terminal";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingDays.Location = new System.Drawing.Point(445, 35);
            this.txtWorkingDays.MaxLength = 3;
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.ReadOnly = true;
            this.txtWorkingDays.Size = new System.Drawing.Size(90, 28);
            this.txtWorkingDays.TabIndex = 111;
            // 
            // comboStream
            // 
            this.comboStream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboStream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboStream.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboStream.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStream.FormattingEnabled = true;
            this.comboStream.Items.AddRange(new object[] {
            "General",
            "Technical",
            "Arts",
            "Management",
            "Education"});
            this.comboStream.Location = new System.Drawing.Point(171, 3);
            this.comboStream.Name = "comboStream";
            this.comboStream.Size = new System.Drawing.Size(111, 27);
            this.comboStream.TabIndex = 103;
            this.comboStream.SelectedIndexChanged += new System.EventHandler(this.comboClass_SelectedIndexChanged);
            this.comboStream.TextChanged += new System.EventHandler(this.comboStream_TextChanged);
            this.comboStream.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboStream_KeyDown);
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(91, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(76, 28);
            this.button9.TabIndex = 108;
            this.button9.Text = "Stream";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(288, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 28);
            this.button3.TabIndex = 106;
            this.button3.Text = "Total Working Days";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // comboClass
            // 
            this.comboClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboClass.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboClass.FormattingEnabled = true;
            this.comboClass.Items.AddRange(new object[] {
            "Nursery",
            "KG",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboClass.Location = new System.Drawing.Point(338, 5);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(64, 27);
            this.comboClass.TabIndex = 104;
            this.comboClass.SelectedIndexChanged += new System.EventHandler(this.comboClass_SelectedIndexChanged);
            this.comboClass.TextChanged += new System.EventHandler(this.comboStream_TextChanged);
            this.comboClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboClass_KeyDown);
            // 
            // comboSec
            // 
            this.comboSec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboSec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSec.FormattingEnabled = true;
            this.comboSec.Items.AddRange(new object[] {
            "-",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.comboSec.Location = new System.Drawing.Point(464, 4);
            this.comboSec.Name = "comboSec";
            this.comboSec.Size = new System.Drawing.Size(71, 27);
            this.comboSec.TabIndex = 105;
            this.comboSec.SelectedIndexChanged += new System.EventHandler(this.comboClass_SelectedIndexChanged);
            this.comboSec.TextChanged += new System.EventHandler(this.comboStream_TextChanged);
            this.comboSec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSec_KeyDown);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(405, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 28);
            this.button7.TabIndex = 107;
            this.button7.Text = "Sec";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.ForeColor = System.Drawing.Color.Black;
            this.button18.Location = new System.Drawing.Point(286, 4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(50, 28);
            this.button18.TabIndex = 109;
            this.button18.Text = "Class";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(5, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 70);
            this.button2.TabIndex = 100;
            this.button2.Text = "Search Through / Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Controls.Add(this.button16);
            this.panel7.Controls.Add(this.label15);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(548, 34);
            this.panel7.TabIndex = 72;
            // 
            // AttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(557, 713);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttendanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AttendanceReport";
            this.Load += new System.EventHandler(this.AttendanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox comboTerminal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWorkingDays;
        private System.Windows.Forms.ComboBox comboStream;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.ComboBox comboSec;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn names;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Present;
        private System.Windows.Forms.DataGridViewTextBoxColumn Absent;
    }
}
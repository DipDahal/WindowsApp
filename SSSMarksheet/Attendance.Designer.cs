namespace SSSMarksheet
{
    partial class Attendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Absent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboTerminal = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWorkingDays = new System.Windows.Forms.TextBox();
            this.comboStream = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.comboSec = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.Names,
            this.RollNo,
            this.present,
            this.Absent});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(738, 484);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // SNo
            // 
            this.SNo.HeaderText = "SNo";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            this.SNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SNo.Width = 60;
            // 
            // Names
            // 
            this.Names.HeaderText = "Name";
            this.Names.Name = "Names";
            this.Names.ReadOnly = true;
            this.Names.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Names.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Names.Width = 330;
            // 
            // RollNo
            // 
            this.RollNo.HeaderText = "RollNo";
            this.RollNo.Name = "RollNo";
            this.RollNo.ReadOnly = true;
            this.RollNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RollNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RollNo.Width = 90;
            // 
            // present
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.present.DefaultCellStyle = dataGridViewCellStyle2;
            this.present.HeaderText = "Total Present";
            this.present.MaxInputLength = 3;
            this.present.Name = "present";
            this.present.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.present.Width = 130;
            // 
            // Absent
            // 
            this.Absent.HeaderText = "Total Absent";
            this.Absent.Name = "Absent";
            this.Absent.ReadOnly = true;
            this.Absent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Absent.Width = 125;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(5, 106);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(738, 484);
            this.panel4.TabIndex = 54;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.comboTerminal);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.txtWorkingDays);
            this.panel5.Controls.Add(this.comboStream);
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.comboClass);
            this.panel5.Controls.Add(this.comboSec);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button18);
            this.panel5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(4, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(739, 66);
            this.panel5.TabIndex = 58;
            // 
            // comboTerminal
            // 
            this.comboTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTerminal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTerminal.FormattingEnabled = true;
            this.comboTerminal.Items.AddRange(new object[] {
            "First Terminal Exam",
            "Second Terminal Exam",
            "Half Yearly Exam",
            "Third Terminal Exam",
            "Final Exam"});
            this.comboTerminal.Location = new System.Drawing.Point(79, 35);
            this.comboTerminal.Name = "comboTerminal";
            this.comboTerminal.Size = new System.Drawing.Size(289, 27);
            this.comboTerminal.TabIndex = 101;
            this.comboTerminal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboTerminal_KeyDown);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(7, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 28);
            this.button1.TabIndex = 102;
            this.button1.Text = "Exam   ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingDays.Location = new System.Drawing.Point(529, 37);
            this.txtWorkingDays.MaxLength = 3;
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Size = new System.Drawing.Size(100, 28);
            this.txtWorkingDays.TabIndex = 101;
            this.txtWorkingDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkingDays_KeyDown);
            this.txtWorkingDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkingDays_KeyPress);
            // 
            // comboStream
            // 
            this.comboStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStream.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboStream.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStream.FormattingEnabled = true;
            this.comboStream.Items.AddRange(new object[] {
            "General",
            "Technical",
            "Arts",
            "Management",
            "Education"});
            this.comboStream.Location = new System.Drawing.Point(79, 4);
            this.comboStream.Name = "comboStream";
            this.comboStream.Size = new System.Drawing.Size(217, 27);
            this.comboStream.TabIndex = 2;
            this.comboStream.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboStream_KeyDown);
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(6, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(67, 28);
            this.button9.TabIndex = 100;
            this.button9.Text = "Stream";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(372, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 28);
            this.button2.TabIndex = 100;
            this.button2.Text = "Total Working Days";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboClass
            // 
            this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboClass.Location = new System.Drawing.Point(373, 5);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(102, 27);
            this.comboClass.TabIndex = 3;
            this.comboClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboClass_KeyDown);
            // 
            // comboSec
            // 
            this.comboSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboSec.Location = new System.Drawing.Point(544, 5);
            this.comboSec.Name = "comboSec";
            this.comboSec.Size = new System.Drawing.Size(83, 27);
            this.comboSec.TabIndex = 4;
            this.comboSec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSec_KeyDown);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(633, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 59);
            this.button3.TabIndex = 100;
            this.button3.Text = "Go";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(481, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 28);
            this.button7.TabIndex = 100;
            this.button7.Text = "Sec";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.ForeColor = System.Drawing.Color.Black;
            this.button18.Location = new System.Drawing.Point(302, 4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(65, 28);
            this.button18.TabIndex = 100;
            this.button18.Text = "Class";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Controls.Add(this.button16);
            this.panel7.Controls.Add(this.label15);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(4, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(739, 34);
            this.panel7.TabIndex = 57;
            // 
            // button16
            // 
            this.button16.AutoSize = true;
            this.button16.BackColor = System.Drawing.Color.Red;
            this.button16.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.Transparent;
            this.button16.Location = new System.Drawing.Point(702, -1);
            this.button16.Margin = new System.Windows.Forms.Padding(2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(35, 36);
            this.button16.TabIndex = 9;
            this.button16.Text = "X";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calisto MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(204, 2);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(263, 28);
            this.label15.TabIndex = 12;
            this.label15.Text = "Add Student\'s Attendance";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.button10);
            this.panel1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 48);
            this.panel1.TabIndex = 59;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(653, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(79, 41);
            this.button10.TabIndex = 100;
            this.button10.Text = "Save";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(748, 642);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboStream;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.ComboBox comboSec;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtWorkingDays;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox comboTerminal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn present;
        private System.Windows.Forms.DataGridViewTextBoxColumn Absent;
    }
}
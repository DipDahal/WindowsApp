namespace DipeshNepaliDateConverter
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblenglish = new System.Windows.Forms.Label();
            this.txtnepalidate = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btndatesettings = new System.Windows.Forms.Button();
            this.btndatepick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "ToAD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblenglish
            // 
            this.lblenglish.AutoSize = true;
            this.lblenglish.Location = new System.Drawing.Point(353, 100);
            this.lblenglish.Name = "lblenglish";
            this.lblenglish.Size = new System.Drawing.Size(0, 13);
            this.lblenglish.TabIndex = 10;
            // 
            // txtnepalidate
            // 
            this.txtnepalidate.Location = new System.Drawing.Point(46, 90);
            this.txtnepalidate.Name = "txtnepalidate";
            this.txtnepalidate.Size = new System.Drawing.Size(177, 20);
            this.txtnepalidate.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "ToBS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // btndatesettings
            // 
            this.btndatesettings.Location = new System.Drawing.Point(229, 135);
            this.btndatesettings.Name = "btndatesettings";
            this.btndatesettings.Size = new System.Drawing.Size(115, 23);
            this.btndatesettings.TabIndex = 12;
            this.btndatesettings.Text = "Date Settings";
            this.btndatesettings.UseVisualStyleBackColor = true;
            this.btndatesettings.Click += new System.EventHandler(this.btndatesettings_Click);
            // 
            // btndatepick
            // 
            this.btndatepick.Location = new System.Drawing.Point(23, 88);
            this.btndatepick.Name = "btndatepick";
            this.btndatepick.Size = new System.Drawing.Size(26, 23);
            this.btndatepick.TabIndex = 13;
            this.btndatepick.Text = "▼";
            this.btndatepick.UseVisualStyleBackColor = true;
            this.btndatepick.Click += new System.EventHandler(this.btndatepick_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 170);
            this.Controls.Add(this.btndatepick);
            this.Controls.Add(this.btndatesettings);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblenglish);
            this.Controls.Add(this.txtnepalidate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Nepali Date Converter © Dipesh ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblenglish;
        private System.Windows.Forms.TextBox txtnepalidate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndatesettings;
        private System.Windows.Forms.Button btndatepick;
    }
}
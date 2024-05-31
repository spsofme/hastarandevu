namespace HastaRandevuKayit.Presentation.Forms
{
    partial class PatientOldAnalysis
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
            txtDoctorName = new TextBox();
            txtDepartmentName = new TextBox();
            txtPatientName = new TextBox();
            txtPatientComplaints = new RichTextBox();
            txtRequiredTests = new RichTextBox();
            txtResultTests = new RichTextBox();
            txtRecipe = new RichTextBox();
            txtTreatment = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtDate = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // txtDoctorName
            // 
            txtDoctorName.Location = new Point(140, 12);
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.Size = new Size(219, 27);
            txtDoctorName.TabIndex = 0;
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(140, 45);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(219, 27);
            txtDepartmentName.TabIndex = 7;
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(140, 78);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(219, 27);
            txtPatientName.TabIndex = 8;
            // 
            // txtPatientComplaints
            // 
            txtPatientComplaints.Location = new Point(140, 111);
            txtPatientComplaints.Name = "txtPatientComplaints";
            txtPatientComplaints.Size = new Size(219, 93);
            txtPatientComplaints.TabIndex = 9;
            txtPatientComplaints.Text = "";
            // 
            // txtRequiredTests
            // 
            txtRequiredTests.Location = new Point(140, 210);
            txtRequiredTests.Name = "txtRequiredTests";
            txtRequiredTests.Size = new Size(219, 93);
            txtRequiredTests.TabIndex = 10;
            txtRequiredTests.Text = "";
            // 
            // txtResultTests
            // 
            txtResultTests.Location = new Point(140, 309);
            txtResultTests.Name = "txtResultTests";
            txtResultTests.Size = new Size(219, 93);
            txtResultTests.TabIndex = 11;
            txtResultTests.Text = "";
            // 
            // txtRecipe
            // 
            txtRecipe.Location = new Point(453, 12);
            txtRecipe.Name = "txtRecipe";
            txtRecipe.Size = new Size(219, 93);
            txtRecipe.TabIndex = 12;
            txtRecipe.Text = "";
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(453, 111);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(219, 93);
            txtTreatment.TabIndex = 13;
            txtTreatment.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 15);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 14;
            label1.Text = "Doktor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 48);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 15;
            label2.Text = "Departman";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 81);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 16;
            label3.Text = "Hasta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 347);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 17;
            label4.Text = "Tahlil Sonuçları";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 251);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 18;
            label5.Text = "Gerekli Tahliller";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 147);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 19;
            label6.Text = "Hasta Şikayetleri";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(393, 45);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 20;
            label7.Text = "Reçete";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(395, 147);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 21;
            label8.Text = "Tedavi";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(453, 210);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(219, 27);
            txtDate.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(407, 213);
            label9.Name = "label9";
            label9.Size = new Size(40, 20);
            label9.TabIndex = 23;
            label9.Text = "Tarih";
            // 
            // PatientOldAnalysis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 411);
            Controls.Add(label9);
            Controls.Add(txtDate);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTreatment);
            Controls.Add(txtRecipe);
            Controls.Add(txtResultTests);
            Controls.Add(txtRequiredTests);
            Controls.Add(txtPatientComplaints);
            Controls.Add(txtPatientName);
            Controls.Add(txtDepartmentName);
            Controls.Add(txtDoctorName);
            Name = "PatientOldAnalysis";
            Text = "PatientOldAnalysis";
            Load += PatientOldAnalysis_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDoctorName;
        private TextBox txtDepartmentName;
        private TextBox txtPatientName;
        private RichTextBox txtPatientComplaints;
        private RichTextBox txtRequiredTests;
        private RichTextBox txtResultTests;
        private RichTextBox txtRecipe;
        private RichTextBox txtTreatment;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtDate;
        private Label label9;
    }
}
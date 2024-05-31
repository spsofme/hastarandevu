namespace HastaRandevuKayit.Presentation.Forms
{
    partial class DoctorForm
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
            groupBox1 = new GroupBox();
            lvPatientHistory = new ListView();
            chDepartment = new ColumnHeader();
            chDate = new ColumnHeader();
            btnGoHistoryDetails = new Button();
            label9 = new Label();
            txtTreatment = new RichTextBox();
            label10 = new Label();
            txtTestResult = new RichTextBox();
            txtRecipe = new RichTextBox();
            label8 = new Label();
            label7 = new Label();
            txtRequestedTest = new RichTextBox();
            btnSaveResult = new Button();
            label5 = new Label();
            label4 = new Label();
            txtPatientComplaint = new RichTextBox();
            txtGender = new TextBox();
            txtTC = new TextBox();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSurname = new TextBox();
            txtName = new TextBox();
            btnRefresh = new Button();
            btnLogout = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lvPatientHistory);
            groupBox1.Controls.Add(btnGoHistoryDetails);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtTreatment);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtTestResult);
            groupBox1.Controls.Add(txtRecipe);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtRequestedTest);
            groupBox1.Controls.Add(btnSaveResult);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPatientComplaint);
            groupBox1.Controls.Add(txtGender);
            groupBox1.Controls.Add(txtTC);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSurname);
            groupBox1.Controls.Add(txtName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(792, 492);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hasta Bilgileri";
            // 
            // lvPatientHistory
            // 
            lvPatientHistory.Columns.AddRange(new ColumnHeader[] { chDepartment, chDate });
            lvPatientHistory.Location = new Point(262, 52);
            lvPatientHistory.Name = "lvPatientHistory";
            lvPatientHistory.Size = new Size(233, 168);
            lvPatientHistory.TabIndex = 33;
            lvPatientHistory.UseCompatibleStateImageBehavior = false;
            // 
            // chDepartment
            // 
            chDepartment.Text = "Departman";
            // 
            // chDate
            // 
            chDate.Text = "Tarih";
            // 
            // btnGoHistoryDetails
            // 
            btnGoHistoryDetails.Location = new Point(262, 227);
            btnGoHistoryDetails.Margin = new Padding(3, 4, 3, 4);
            btnGoHistoryDetails.Name = "btnGoHistoryDetails";
            btnGoHistoryDetails.Size = new Size(233, 31);
            btnGoHistoryDetails.TabIndex = 32;
            btnGoHistoryDetails.Text = "Geçmiş Detayına Git";
            btnGoHistoryDetails.UseVisualStyleBackColor = true;
            btnGoHistoryDetails.Click += btnGoHistoryDetails_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(262, 28);
            label9.Name = "label9";
            label9.Size = new Size(103, 20);
            label9.TabIndex = 31;
            label9.Text = "Hasta Geçmişi";
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(513, 304);
            txtTreatment.Margin = new Padding(3, 4, 3, 4);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(143, 177);
            txtTreatment.TabIndex = 29;
            txtTreatment.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(352, 280);
            label10.Name = "label10";
            label10.Size = new Size(60, 20);
            label10.TabIndex = 26;
            label10.Text = "Reçete*";
            // 
            // txtTestResult
            // 
            txtTestResult.Location = new Point(187, 304);
            txtTestResult.Margin = new Padding(3, 4, 3, 4);
            txtTestResult.Name = "txtTestResult";
            txtTestResult.Size = new Size(143, 177);
            txtTestResult.TabIndex = 28;
            txtTestResult.Text = "";
            // 
            // txtRecipe
            // 
            txtRecipe.Location = new Point(352, 304);
            txtRecipe.Margin = new Padding(3, 4, 3, 4);
            txtRecipe.Name = "txtRecipe";
            txtRecipe.Size = new Size(143, 177);
            txtRecipe.TabIndex = 27;
            txtRecipe.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(187, 280);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 22;
            label8.Text = "Tahlil Sonuçları";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 280);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 20;
            label7.Text = "İstenen Tahliller";
            // 
            // txtRequestedTest
            // 
            txtRequestedTest.Location = new Point(25, 304);
            txtRequestedTest.Margin = new Padding(3, 4, 3, 4);
            txtRequestedTest.Name = "txtRequestedTest";
            txtRequestedTest.Size = new Size(143, 177);
            txtRequestedTest.TabIndex = 19;
            txtRequestedTest.Text = "";
            // 
            // btnSaveResult
            // 
            btnSaveResult.Location = new Point(677, 304);
            btnSaveResult.Margin = new Padding(3, 4, 3, 4);
            btnSaveResult.Name = "btnSaveResult";
            btnSaveResult.Size = new Size(86, 179);
            btnSaveResult.TabIndex = 17;
            btnSaveResult.Text = "Kaydet";
            btnSaveResult.UseVisualStyleBackColor = true;
            btnSaveResult.Click += btnSaveResult_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(517, 280);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 17;
            label5.Text = "Tedavi*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(517, 28);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 15;
            label4.Text = "Hasta Şikayeti*";
            // 
            // txtPatientComplaint
            // 
            txtPatientComplaint.Location = new Point(517, 52);
            txtPatientComplaint.Margin = new Padding(3, 4, 3, 4);
            txtPatientComplaint.Name = "txtPatientComplaint";
            txtPatientComplaint.Size = new Size(245, 168);
            txtPatientComplaint.TabIndex = 14;
            txtPatientComplaint.Text = "";
            // 
            // txtGender
            // 
            txtGender.Enabled = false;
            txtGender.Location = new Point(93, 200);
            txtGender.MaxLength = 30;
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(140, 27);
            txtGender.TabIndex = 13;
            // 
            // txtTC
            // 
            txtTC.Enabled = false;
            txtTC.Location = new Point(93, 38);
            txtTC.MaxLength = 30;
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(140, 27);
            txtTC.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 200);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 11;
            label6.Text = "Cinsiyet";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 152);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 96);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 7;
            label2.Text = "Ad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 41);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 6;
            label1.Text = "T.C. Kimlik";
            // 
            // txtSurname
            // 
            txtSurname.Enabled = false;
            txtSurname.Location = new Point(93, 148);
            txtSurname.MaxLength = 30;
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(140, 27);
            txtSurname.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Enabled = false;
            txtName.Location = new Point(93, 92);
            txtName.MaxLength = 30;
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 27);
            txtName.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(810, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 258);
            btnRefresh.TabIndex = 17;
            btnRefresh.Text = "Yenile";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(810, 276);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 228);
            btnLogout.TabIndex = 18;
            btnLogout.Text = "Çıkış Yap";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 509);
            Controls.Add(btnLogout);
            Controls.Add(btnRefresh);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DoctorForm";
            Text = "DoctorForm";
            Load += DoctorForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button btnAdd;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSurname;
        private TextBox txtName;
        private TextBox txtGender;
        private TextBox txtTC;
        private Label label4;
        private RichTextBox txtPatientComplaint;
        private Button btnSaveResult;
        private Label label5;
        private Label label8;
        private Label label7;
        private RichTextBox txtRequestedTest;
        private RichTextBox txtTreatment;
        private Label label10;
        private RichTextBox txtTestResult;
        private RichTextBox txtRecipe;
        private Button btnGoHistoryDetails;
        private Label label9;
        private ListView lvPatientHistory;
        private ColumnHeader chDepartment;
        private ColumnHeader chDate;
        private Button btnRefresh;
        private Button btnLogout;
    }
}
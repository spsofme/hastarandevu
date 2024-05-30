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
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAddSurname = new TextBox();
            txtAddName = new TextBox();
            txtAddTC = new TextBox();
            txtAddCinsiyet = new TextBox();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            richTextBox3 = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            richTextBox4 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox6 = new RichTextBox();
            button2 = new Button();
            label9 = new Label();
            richTextBox5 = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(richTextBox5);
            groupBox1.Controls.Add(richTextBox6);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(richTextBox2);
            groupBox1.Controls.Add(richTextBox4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(richTextBox3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(txtAddCinsiyet);
            groupBox1.Controls.Add(txtAddTC);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtAddSurname);
            groupBox1.Controls.Add(txtAddName);
            groupBox1.Location = new Point(61, 54);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(693, 369);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hasta Bilgileri";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 150);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 11;
            label6.Text = "Cinsiyet";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 114);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 8;
            label3.Text = "Soyad";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 72);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 7;
            label2.Text = "Ad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 6;
            label1.Text = "T.C. Kimlik";
            label1.Click += label1_Click;
            // 
            // txtAddSurname
            // 
            txtAddSurname.Location = new Point(81, 111);
            txtAddSurname.Margin = new Padding(3, 2, 3, 2);
            txtAddSurname.MaxLength = 30;
            txtAddSurname.Name = "txtAddSurname";
            txtAddSurname.Size = new Size(123, 23);
            txtAddSurname.TabIndex = 2;
            txtAddSurname.TextChanged += txtAddSurname_TextChanged;
            // 
            // txtAddName
            // 
            txtAddName.Location = new Point(81, 69);
            txtAddName.Margin = new Padding(3, 2, 3, 2);
            txtAddName.MaxLength = 30;
            txtAddName.Name = "txtAddName";
            txtAddName.Size = new Size(123, 23);
            txtAddName.TabIndex = 1;
            txtAddName.TextChanged += txtAddName_TextChanged;
            // 
            // txtAddTC
            // 
            txtAddTC.Location = new Point(81, 23);
            txtAddTC.Margin = new Padding(3, 2, 3, 2);
            txtAddTC.MaxLength = 30;
            txtAddTC.Name = "txtAddTC";
            txtAddTC.Size = new Size(123, 23);
            txtAddTC.TabIndex = 12;
            // 
            // txtAddCinsiyet
            // 
            txtAddCinsiyet.Location = new Point(81, 150);
            txtAddCinsiyet.Margin = new Padding(3, 2, 3, 2);
            txtAddCinsiyet.MaxLength = 30;
            txtAddCinsiyet.Name = "txtAddCinsiyet";
            txtAddCinsiyet.Size = new Size(123, 23);
            txtAddCinsiyet.TabIndex = 13;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(452, 39);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(215, 134);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(452, 21);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 15;
            label4.Text = "Hasta Şikayeti";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(488, 210);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 17;
            label5.Text = "Tedavi";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(592, 228);
            button1.Name = "button1";
            button1.Size = new Size(75, 134);
            button1.TabIndex = 17;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(22, 228);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(126, 134);
            richTextBox3.TabIndex = 19;
            richTextBox3.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 210);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 20;
            label7.Text = "İstenen Tahliller";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(154, 210);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 22;
            label8.Text = "Tahlil Sonuçları";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(308, 210);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 26;
            label10.Text = "Reçete";
            label10.Click += label10_Click;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(308, 228);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(126, 134);
            richTextBox4.TabIndex = 27;
            richTextBox4.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(164, 228);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(126, 134);
            richTextBox2.TabIndex = 28;
            richTextBox2.Text = "";
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(449, 228);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(126, 134);
            richTextBox6.TabIndex = 29;
            richTextBox6.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(229, 170);
            button2.Name = "button2";
            button2.Size = new Size(176, 23);
            button2.TabIndex = 32;
            button2.Text = "Geçmiş Detayına Git";
            button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(220, 21);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 31;
            label9.Text = "Hasta Geçmişi";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(220, 39);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(200, 134);
            richTextBox5.TabIndex = 30;
            richTextBox5.Text = "";
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 514);
            Controls.Add(groupBox1);
            Name = "DoctorForm";
            Text = "DoctorForm";
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
        private TextBox txtAddSurname;
        private TextBox txtAddName;
        private TextBox txtAddCinsiyet;
        private TextBox txtAddTC;
        private Label label4;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label5;
        private Label label8;
        private Label label7;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox6;
        private Label label10;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox4;
        private Button button2;
        private Label label9;
        private RichTextBox richTextBox5;
    }
}
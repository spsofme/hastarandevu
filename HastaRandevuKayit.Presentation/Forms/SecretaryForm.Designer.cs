namespace HastaRandevuKayit.Presentation.Forms
{
    partial class SecretaryForm
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
            tabControl1 = new TabControl();
            tpGeneral = new TabPage();
            tpAppointment = new TabPage();
            tpSecretary = new TabPage();
            groupBox3 = new GroupBox();
            lvSecretaries = new ListView();
            colTC = new ColumnHeader();
            colName = new ColumnHeader();
            colSurname = new ColumnHeader();
            colPhone = new ColumnHeader();
            colEmail = new ColumnHeader();
            colGender = new ColumnHeader();
            groupBox2 = new GroupBox();
            btnRemove = new Button();
            btnUpdate = new Button();
            txtUpdGender = new TextBox();
            txtUpdTc = new TextBox();
            txtUpdMail = new TextBox();
            label12 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtUpdName = new TextBox();
            label9 = new Label();
            txtUpdSurname = new TextBox();
            label10 = new Label();
            txtUpdPhone = new MaskedTextBox();
            label11 = new Label();
            groupBox1 = new GroupBox();
            btnAdd = new Button();
            txtAddMail = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbAddGender = new ComboBox();
            txtAddPhone = new MaskedTextBox();
            txtAddSurname = new TextBox();
            txtAddName = new TextBox();
            txtAddTC = new MaskedTextBox();
            tpDoctor = new TabPage();
            tpProfile = new TabPage();
            tabControl1.SuspendLayout();
            tpSecretary.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpGeneral);
            tabControl1.Controls.Add(tpAppointment);
            tabControl1.Controls.Add(tpSecretary);
            tabControl1.Controls.Add(tpDoctor);
            tabControl1.Controls.Add(tpProfile);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 451);
            tabControl1.TabIndex = 0;
            // 
            // tpGeneral
            // 
            tpGeneral.Location = new Point(4, 29);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Size = new Size(792, 418);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "Genel Görünüm";
            tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpAppointment
            // 
            tpAppointment.Location = new Point(4, 29);
            tpAppointment.Name = "tpAppointment";
            tpAppointment.Size = new Size(792, 418);
            tpAppointment.TabIndex = 4;
            tpAppointment.Text = "Randevu Ekranı";
            tpAppointment.UseVisualStyleBackColor = true;
            // 
            // tpSecretary
            // 
            tpSecretary.Controls.Add(groupBox3);
            tpSecretary.Controls.Add(groupBox2);
            tpSecretary.Controls.Add(groupBox1);
            tpSecretary.Location = new Point(4, 29);
            tpSecretary.Name = "tpSecretary";
            tpSecretary.Size = new Size(792, 418);
            tpSecretary.TabIndex = 1;
            tpSecretary.Text = "Sekreter Paneli";
            tpSecretary.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lvSecretaries);
            groupBox3.Location = new Point(8, 237);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 172);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sekreter Listesi";
            // 
            // lvSecretaries
            // 
            lvSecretaries.Columns.AddRange(new ColumnHeader[] { colTC, colName, colSurname, colPhone, colEmail, colGender });
            lvSecretaries.Location = new Point(6, 26);
            lvSecretaries.Name = "lvSecretaries";
            lvSecretaries.Size = new Size(764, 140);
            lvSecretaries.TabIndex = 2;
            lvSecretaries.UseCompatibleStateImageBehavior = false;
            lvSecretaries.View = View.Details;
            lvSecretaries.SelectedIndexChanged += lvSecretaries_SelectedIndexChanged;
            // 
            // colTC
            // 
            colTC.Text = "TC";
            // 
            // colName
            // 
            colName.Text = "Ad";
            // 
            // colSurname
            // 
            colSurname.Text = "Soyad";
            // 
            // colPhone
            // 
            colPhone.Text = "Telefon";
            // 
            // colEmail
            // 
            colEmail.Text = "E-Posta";
            // 
            // colGender
            // 
            colGender.Text = "Cinsiyet";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemove);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(txtUpdGender);
            groupBox2.Controls.Add(txtUpdTc);
            groupBox2.Controls.Add(txtUpdMail);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtUpdName);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtUpdSurname);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtUpdPhone);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(389, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(395, 228);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Seçili Sekreter Bilgileri";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(235, 125);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(154, 97);
            btnRemove.TabIndex = 17;
            btnRemove.Text = "Sil";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(235, 26);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(154, 93);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtUpdGender
            // 
            txtUpdGender.Location = new Point(89, 191);
            txtUpdGender.Name = "txtUpdGender";
            txtUpdGender.ReadOnly = true;
            txtUpdGender.Size = new Size(140, 27);
            txtUpdGender.TabIndex = 15;
            // 
            // txtUpdTc
            // 
            txtUpdTc.Location = new Point(89, 26);
            txtUpdTc.Name = "txtUpdTc";
            txtUpdTc.ReadOnly = true;
            txtUpdTc.Size = new Size(140, 27);
            txtUpdTc.TabIndex = 10;
            // 
            // txtUpdMail
            // 
            txtUpdMail.Location = new Point(89, 158);
            txtUpdMail.MaxLength = 30;
            txtUpdMail.Name = "txtUpdMail";
            txtUpdMail.Size = new Size(140, 27);
            txtUpdMail.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 29);
            label12.Name = "label12";
            label12.Size = new Size(77, 20);
            label12.TabIndex = 18;
            label12.Text = "T.C. Kimlik";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 194);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 23;
            label7.Text = "Cinsiyet";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 161);
            label8.Name = "label8";
            label8.Size = new Size(58, 20);
            label8.TabIndex = 22;
            label8.Text = "E-Posta";
            // 
            // txtUpdName
            // 
            txtUpdName.Location = new Point(89, 59);
            txtUpdName.MaxLength = 30;
            txtUpdName.Name = "txtUpdName";
            txtUpdName.Size = new Size(140, 27);
            txtUpdName.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 128);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 21;
            label9.Text = "Telefon";
            // 
            // txtUpdSurname
            // 
            txtUpdSurname.Location = new Point(89, 92);
            txtUpdSurname.MaxLength = 30;
            txtUpdSurname.Name = "txtUpdSurname";
            txtUpdSurname.Size = new Size(140, 27);
            txtUpdSurname.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(33, 95);
            label10.Name = "label10";
            label10.Size = new Size(50, 20);
            label10.TabIndex = 20;
            label10.Text = "Soyad";
            // 
            // txtUpdPhone
            // 
            txtUpdPhone.Location = new Point(89, 125);
            txtUpdPhone.Mask = "(999) 000-0000";
            txtUpdPhone.Name = "txtUpdPhone";
            txtUpdPhone.Size = new Size(140, 27);
            txtUpdPhone.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(55, 62);
            label11.Name = "label11";
            label11.Size = new Size(28, 20);
            label11.TabIndex = 19;
            label11.Text = "Ad";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(txtAddMail);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbAddGender);
            groupBox1.Controls.Add(txtAddPhone);
            groupBox1.Controls.Add(txtAddSurname);
            groupBox1.Controls.Add(txtAddName);
            groupBox1.Controls.Add(txtAddTC);
            groupBox1.Location = new Point(8, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 228);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sekreter Ekle";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(235, 26);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 196);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtAddMail
            // 
            txtAddMail.Location = new Point(89, 158);
            txtAddMail.MaxLength = 30;
            txtAddMail.Name = "txtAddMail";
            txtAddMail.Size = new Size(140, 27);
            txtAddMail.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 194);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 11;
            label6.Text = "Cinsiyet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 161);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 10;
            label5.Text = "E-Posta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 128);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 9;
            label4.Text = "Telefon";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 95);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 62);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 7;
            label2.Text = "Ad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 6;
            label1.Text = "T.C. Kimlik";
            // 
            // cbAddGender
            // 
            cbAddGender.FormattingEnabled = true;
            cbAddGender.Items.AddRange(new object[] { "Kız", "Erkek" });
            cbAddGender.Location = new Point(89, 191);
            cbAddGender.Name = "cbAddGender";
            cbAddGender.Size = new Size(140, 28);
            cbAddGender.TabIndex = 5;
            // 
            // txtAddPhone
            // 
            txtAddPhone.Location = new Point(89, 125);
            txtAddPhone.Mask = "(999) 000-0000";
            txtAddPhone.Name = "txtAddPhone";
            txtAddPhone.Size = new Size(140, 27);
            txtAddPhone.TabIndex = 3;
            // 
            // txtAddSurname
            // 
            txtAddSurname.Location = new Point(89, 92);
            txtAddSurname.MaxLength = 30;
            txtAddSurname.Name = "txtAddSurname";
            txtAddSurname.Size = new Size(140, 27);
            txtAddSurname.TabIndex = 2;
            // 
            // txtAddName
            // 
            txtAddName.Location = new Point(89, 59);
            txtAddName.MaxLength = 30;
            txtAddName.Name = "txtAddName";
            txtAddName.Size = new Size(140, 27);
            txtAddName.TabIndex = 1;
            // 
            // txtAddTC
            // 
            txtAddTC.Location = new Point(89, 26);
            txtAddTC.Mask = "00000000000";
            txtAddTC.Name = "txtAddTC";
            txtAddTC.Size = new Size(140, 27);
            txtAddTC.TabIndex = 0;
            // 
            // tpDoctor
            // 
            tpDoctor.Location = new Point(4, 29);
            tpDoctor.Name = "tpDoctor";
            tpDoctor.Size = new Size(792, 418);
            tpDoctor.TabIndex = 2;
            tpDoctor.Text = "Doktor Paneli";
            tpDoctor.UseVisualStyleBackColor = true;
            // 
            // tpProfile
            // 
            tpProfile.Location = new Point(4, 29);
            tpProfile.Name = "tpProfile";
            tpProfile.Size = new Size(792, 418);
            tpProfile.TabIndex = 3;
            tpProfile.Text = "Profilim";
            tpProfile.UseVisualStyleBackColor = true;
            // 
            // SecretaryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(tabControl1);
            Name = "SecretaryForm";
            Text = "SecretaryForm";
            Load += SecretaryForm_Load;
            tabControl1.ResumeLayout(false);
            tpSecretary.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpGeneral;
        private TabPage tpAppointment;
        private TabPage tpSecretary;
        private TabPage tpDoctor;
        private TabPage tpProfile;
        private GroupBox groupBox3;
        private ListView lvSecretaries;
        private ColumnHeader colTC;
        private ColumnHeader colName;
        private ColumnHeader colSurname;
        private ColumnHeader colGender;
        private ColumnHeader colPhone;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ColumnHeader colEmail;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbAddGender;
        private MaskedTextBox txtAddPhone;
        private TextBox txtAddSurname;
        private TextBox txtAddName;
        private MaskedTextBox txtAddTC;
        private TextBox txtAddMail;
        private TextBox txtUpdGender;
        private TextBox txtUpdTc;
        private TextBox txtUpdMail;
        private Label label12;
        private Label label7;
        private Label label8;
        private TextBox txtUpdName;
        private Label label9;
        private TextBox txtUpdSurname;
        private Label label10;
        private MaskedTextBox txtUpdPhone;
        private Label label11;
        private Button btnRemove;
        private Button btnUpdate;
        private Button btnAdd;
    }
}
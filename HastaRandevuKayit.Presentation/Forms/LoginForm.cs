using HastaRandevuKayit.BusinessLogic;
using HastaRandevuKayit.BusinessLogic.Services;
using HastaRandevuKayit.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaRandevuKayit.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tc = txtTC.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!InputValidation(tc, password))
                return;

            // Login işlemi
            var user = BusinessLogicManager.UserServices.Login(tc, password);
            if (user != null)
            {
                SessionService.LoginUser = user;
                this.Hide();
                switch (user.Role)
                {
                    case 1:  // Doctor
                        var doctorForm = new DoctorForm();
                        doctorForm.ShowDialog();
                        break;
                    case 2:  // Secretary
                        var secretaryForm = new SecretaryForm();
                        secretaryForm.ShowDialog();
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowError("Giriş başarısız. TC kimlik numarası veya şifre hatalı.");
            }
        }

        private bool InputValidation(string tc, string password)
        {
            if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(password))
            {
                MessageBoxHelper.ShowWarning("TC ve şifre alanları boş bırakılamaz.");
                return false;
            }

            if (tc.Length != 11)
            {
                MessageBoxHelper.ShowWarning("TC kimlik numarası 11 haneli olmalıdır.");
                return false;
            }

            if (password.Length < 6)
            {
                MessageBoxHelper.ShowWarning("Şifre en az 6 karakter olmalıdır.");
                return false;
            }
            return true;
        }
    }
}

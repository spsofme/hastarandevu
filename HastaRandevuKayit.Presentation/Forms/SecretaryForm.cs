using HastaRandevuKayit.BusinessLogic;
using HastaRandevuKayit.BusinessLogic.Services;
using HastaRandevuKayit.DataAccess.Enums;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.Presentation.Helpers;
using System.Text.RegularExpressions;

namespace HastaRandevuKayit.Presentation.Forms
{
    public partial class SecretaryForm : Form
    {
        public SecretaryForm()
        {
            InitializeComponent();
        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {
            LoadSecretaries();
        }

        private void LoadSecretaries()
        {
            lvSecretaries.Items.Clear();
            lvSecretaries.View = View.Details;
            lvSecretaries.FullRowSelect = true;

            foreach (var user in BusinessLogicManager.UserServices.GetUserByRole(UserRoleEnum.Secretary))
            {
                if (SessionService.LoginUser.TC == user.TC) continue;
                lvSecretaries.Items.Add(new ListViewItem(new string[] { user.TC, user.Name, user.Surname, $"{user.Phone.Substring(0, 3)} {user.Phone.Substring(3, 3)} {user.Phone.Substring(6, 3)} {user.Phone.Substring(9)}", user.Email, user.Gender == 0 ? "Kız" : "Erkek" }));
            }

            lvSecretaries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvSecretaries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvSecretaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                // Seçilen satırın değerlerini alıyoruz
                ListViewItem selectedItem = listView.SelectedItems[0];
                string TC = selectedItem.SubItems[0].Text;

                UserModel user = BusinessLogicManager.UserServices.GetUserByTC(TC)!;

                //string phone = $"({user.Phone.Substring(3,3)}) {user.Phone.Substring(6, 3)}-{user.Phone.Substring(9)}";
                string phone = $"{user.Phone.Replace(" ", "").Substring(3)}";

                txtUpdTc.Text = user.TC;
                txtUpdName.Text = user.Name;
                txtUpdSurname.Text = user.Surname;
                txtUpdPhone.Text = phone;
                txtUpdMail.Text = user.Email;
                txtUpdGender.Text = user.Gender == 0 ? "Kız" : "Erkek";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            BusinessLogicManager.UserServices.RemoveUserByTc(txtUpdTc.Text.Trim());

            txtUpdTc.Clear();
            txtUpdName.Clear();
            txtUpdSurname.Clear();
            txtUpdPhone.Clear();
            txtUpdMail.Clear();
            txtUpdGender.Clear();

            LoadSecretaries();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AddInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            string phone = "+90" + txtAddPhone.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (BusinessLogicManager.UserServices.AddSecretary(txtAddTC.Text, txtAddName.Text, txtAddSurname.Text, phone, txtAddMail.Text, (byte)cbAddGender.SelectedIndex))
                MessageBoxHelper.ShowInfo("Kayıt başarılı!");
            else
                MessageBoxHelper.ShowWarning("Kayıt başarısız!");

            txtAddTC.Clear();
            txtAddName.Clear();
            txtAddSurname.Clear();
            txtAddPhone.Clear();
            txtAddPhone.Clear();
            txtAddMail.Clear();
            cbAddGender.SelectedIndex = -1;

            LoadSecretaries();
        }

        private bool AddInputValidation()
        {
            if (
                txtAddTC.Text.Trim() == "" ||
                txtAddTC.Text.Length != 11 ||
                txtAddName.Text.Trim() == "" ||
                txtAddSurname.Text.Trim() == "" ||
                txtAddPhone.Text.Trim() == "" ||
                txtAddPhone.Text.Length != 14 ||
                txtAddMail.Text.Trim() == "" ||
                (!Regex.IsMatch(txtAddMail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) ||
                cbAddGender.SelectedIndex == -1
            ) return false;

            return true;
        }

        private bool UpdInputValidation()
        {
            if (
                txtUpdName.Text.Trim() == "" ||
                txtUpdSurname.Text.Trim() == "" ||
                txtUpdPhone.Text.Trim() == "" ||
                txtUpdPhone.Text.Length != 14 ||
                txtUpdMail.Text.Trim() == "" ||
                (!Regex.IsMatch(txtUpdMail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            ) return false;

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!UpdInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            UserModel user = BusinessLogicManager.UserServices.GetUserByTC(txtUpdTc.Text)!;
            string phone = "+90" + txtUpdPhone.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            
            BusinessLogicManager.UserServices.UpdateUser(new UserModel()
            {
                TC = txtUpdTc.Text,
                Name = txtUpdName.Text,
                Surname = txtUpdSurname.Text,
                Phone = phone,
                Email = txtUpdMail.Text,
                Gender = user.Gender,
                Role = user.Role,
            });

            txtUpdTc.Clear();
            txtUpdName.Clear();
            txtUpdSurname.Clear();
            txtUpdPhone.Clear();
            txtUpdMail.Clear();
            txtUpdGender.Clear();

            LoadSecretaries();
        }
    }
}

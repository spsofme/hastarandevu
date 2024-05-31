using HastaRandevuKayit.BusinessLogic;
using HastaRandevuKayit.BusinessLogic.Services;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.Presentation.Helpers;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Globalization;

namespace HastaRandevuKayit.Presentation.Forms
{
    public partial class DoctorForm : Form
    {
        List<AppointmentModel> appointments = new();
        AppointmentModel? currentAppointment = null;
        List<DepartmentModel> departments = new();

        public DoctorForm()
        {
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            departments = BusinessLogicManager.DepartmentServices.GetAllDepartments();
            FormLoad();
        }

        private void FormLoad()
        {
            ClearScreen();

            appointments = BusinessLogicManager.AppointmentServices.GetAllAppointmentsByDoctor(SessionService.LoginDoctorUser!.TC);
            var oldAppointments = new List<AppointmentModel>();

            foreach (var appointment in appointments)
            {
                if (DateTime.ParseExact(appointment.AppointmentDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture) < DateTime.Now.AddMinutes(-30))
                    oldAppointments.Add(appointment);
            }

            PatientModel? user = null;
            
            foreach (var appointment in appointments)
            {
                var appointmentDate = DateTime.ParseExact(appointment.AppointmentDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                var currentDate = DateTime.Now;
                if (appointmentDate.Day == currentDate.Day && appointmentDate.Month == currentDate.Month && appointmentDate.Year == currentDate.Year && appointmentDate.Hour == currentDate.Hour && appointmentDate.Minute <= currentDate.Minute)
                {
                    currentAppointment = appointment;
                    user = BusinessLogicManager.PatientServices.GetPatientByTC(appointment.PatientTC);
                    txtName.Text = user.Name;
                    txtSurname.Text = user.Surname;
                    txtTC.Text = user.TC;
                    txtGender.Text = user.Gender == 1 ? "Erkek" : "Kadın";
                    break;
                }
            }
            if (user == null)
            {
                MessageBoxHelper.ShowInfo("Randevusu olan hasta bulunmamaktadır.");
                return;
            }

            var oldAnalysis = BusinessLogicManager.AnalysisServices.GetAllAnalysesByPatientTC(user.TC);

            lvPatientHistory.Items.Clear();
            lvPatientHistory.View = View.Details;
            lvPatientHistory.FullRowSelect = true;
            foreach (var appointment in oldAnalysis)
            {
                ListViewItem lvi = new(departments.FirstOrDefault(x => x.Id == appointment.DepartmentId)!.Name);
                lvi.SubItems.Add(appointment.CreatedDateTime);
                lvPatientHistory.Items.Add(lvi);
            }
            lvPatientHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvPatientHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void txtAddName_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtAddSurname_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (currentAppointment == null)
            {
                MessageBoxHelper.ShowError("Randevusu olan hasta bulunmamaktadır.");
                return;
            }
            if (!ValidateForm())
            {
                MessageBoxHelper.ShowError("Lütfen gerekli alanları doldurunuz.");
                return;
            }

            var user = BusinessLogicManager.PatientServices.GetPatientByTC(txtTC.Text);

            if (! BusinessLogicManager.AnalysisServices.AddAnalysis(currentAppointment.DepartmentId!, txtPatientComplaint.Text.Trim(), txtRecipe.Text.Trim(), txtTestResult.Text.Trim(), txtTreatment.Text.Trim(), txtRequestedTest.Text.Trim(), DateTime.Now.ToString("dd.MM.yyyy HH:mm"), txtTC.Text, SessionService.LoginDoctorUser.TC))
            {
                MessageBoxHelper.ShowWarning("Hasta randevu sonucu kaydedilemedi!");
                return;
            }


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Randevu sonucu Hastaya gönderilsin mi?", "Uyarı", buttons);
            if (result == DialogResult.Yes)
            {
                Directory.CreateDirectory(".\\Reports");
                var path = ".\\Reports\\";
                var filename = $"RandevuSonucu_{user!.Name}_{user!.Surname}_{DateTime.Now.ToString("ddMMyyyyHHmm")}.pdf";
                CreatePdf($"{path}{filename}", user!);
                BusinessLogicManager.EmailServices.SendMail(user.Email, "Randevu sonucunuz ekteki dosyada bulunmaktadır.", $"{path}{filename}");
            }

            FormLoad();
        }

        public void CreatePdf(string dest, UserModel user)
        {
            // PDF yazarını oluştur
            PdfWriter writer = new(dest);
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            // PDF'e içerik ekle
            document.Add(new Paragraph("Randevu Gecmisi").SetFontSize(16).SetBold().SetMarginBottom(10));
            document.Add(new Paragraph($"Randevu Tarihi: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}"));
            document.Add(new Paragraph("Hasta Bilgileri").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph($"T.C. Kimlik Numarasi: {user.TC}\n Adi-Soyadi: {user.Name} {user.Surname}"));
            document.Add(new Paragraph("Hasta Sikayeti").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph(txtPatientComplaint.Text.Trim()));
            document.Add(new Paragraph("Istenilen Tahliller").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph(txtRequestedTest.Text.Trim()));
            document.Add(new Paragraph("Tahlil Sonuclari").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph(txtTestResult.Text.Trim()));
            document.Add(new Paragraph("Recete").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph(txtRecipe.Text.Trim()));
            document.Add(new Paragraph("Tedavi").SetFontSize(14).SetBold().SetMarginBottom(5));
            document.Add(new Paragraph(txtTreatment.Text.Trim()));

            // Document'i kapat
            document.Close();
        }

        private void btnGoHistoryDetails_Click(object sender, EventArgs e)
        {
            if (lvPatientHistory.SelectedItems.Count == 0)
            {
                MessageBoxHelper.ShowError("Lütfen bir randevu seçiniz.");
                return;
            }

            var selectedDepartmentName = lvPatientHistory.SelectedItems[0];
            var analysisDate = lvPatientHistory.SelectedItems[0].SubItems[1].Text;


            PatientOldAnalysis patientOldAnalysis = new(currentAppointment!.PatientTC, SessionService.LoginDoctorUser.TC, selectedDepartmentName.Text, analysisDate);
            patientOldAnalysis.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionService.LoginDoctorUser = null;
            this.Hide();
            LoginForm loginForm = new();
            loginForm.ShowDialog();
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtPatientComplaint.Text.Trim()) || string.IsNullOrEmpty(txtTreatment.Text.Trim()) || string.IsNullOrEmpty(txtRecipe.Text.Trim()))
                return false;
            return true;
        }

        private void ClearScreen()
        {
            currentAppointment = null;
            lvPatientHistory.Items.Clear();
            txtName.Text = "";
            txtSurname.Text = "";
            txtTC.Text = "";
            txtGender.Text = "";
            txtPatientComplaint.Text = "";
            txtRecipe.Text = "";
            txtTestResult.Text = "";
            txtTreatment.Text = "";
            txtRequestedTest.Text = "";
        }
    }
}

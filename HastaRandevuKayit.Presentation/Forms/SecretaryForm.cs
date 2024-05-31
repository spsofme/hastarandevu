using HastaRandevuKayit.BusinessLogic;
using HastaRandevuKayit.BusinessLogic.Helpers;
using HastaRandevuKayit.BusinessLogic.Services;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.Presentation.Helpers;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using OxyPlot.Axes;

namespace HastaRandevuKayit.Presentation.Forms
{
    public partial class SecretaryForm : Form
    {
        List<DepartmentModel> departmentList;
        List<DoctorModel> doctorList = new();
        List<PatientModel> patientList = new();
        List<SecretaryModel> secretaryList = new();
        List<AppointmentModel> appointmentList = new();

        private DoctorModel? appointmentSelectedDoctor;
        private string selectedHour = "00:00";

        public SecretaryForm()
        {
            InitializeComponent();
        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {
            doctorList = BusinessLogicManager.DoctorServices.GetAllDoctors().ToList();
            patientList = BusinessLogicManager.PatientServices.GetAllPatients().ToList();
            secretaryList = BusinessLogicManager.SecretaryServices.GetAllSecretaries().ToList();
            var departmentsName = BusinessLogicManager.DepartmentServices.GetAllDepartments().Select(x => x.Name).ToList();
            departmentList = BusinessLogicManager.DepartmentServices.GetAllDepartments().ToList();

            cbAddDoctorDepartment.DataSource = departmentsName.ToArray();
            cbAddDoctorDepartment.SelectedIndex = 0;

            cbUpdDoctorDepartment.DataSource = departmentsName.ToArray();
            cbUpdDoctorDepartment.SelectedIndex = 0;

            cbAppointmentPatients.DataSource = patientList.Select(x => x.Name + " " + x.Surname).ToArray();
            cbAppointmentPatients.SelectedIndex = 0;

            cbAppointmentDepartments.DataSource = departmentsName.ToArray();
            cbAppointmentDepartments.SelectedIndex = 0;

            LoadAppointments();
            LoadPatients();
            LoadSecretaries();
            LoadDoctors();
            LoadGraphics();
            LoadProfile();
        }



        #region GeneralForm
        private string graphType = "DepartmentPatient"; // DepartmanPatient, DoctorPatient
        private void LoadGraphics()
        {
            // Bar Chart oluşturma
            string title = "";
            List<string> headers = [];
            List<BarItem> values = [];
            if (graphType == "DepartmentPatient")
            {
                title = "Departman-Hasta Grafiği";
                headers = departmentList.Select(x => x.Name).ToList();
                values = appointmentList.GroupBy(x => x.DepartmentId).Select(x => new BarItem { Value = x.Count(), Color = OxyColor.FromRgb(91, 155, 213) }).ToList();
            }
            else if (graphType == "DoctorPatient")
            {
                title = "Doktor-Hasta Grafiği";
                headers = doctorList.Select(x => x.Name + " " + x.Surname).ToList();
                values = appointmentList.GroupBy(x => x.DoctorTC).Select(x => new BarItem { Value = x.Count(), Color = OxyColor.FromRgb(91, 155, 213) }).ToList();
            }
            var model = new PlotModel { Title = title, DefaultFontSize = 12 };

            // Kategori eksenini dikey eksene ekleme (Y ekseni)
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CategoryAxis",
                ItemsSource = headers,
                Angle = 0, // Kategori etiketlerini açılandırma
                AxislineStyle = LineStyle.Solid,
                AxislineColor = OxyColors.Black,
                MajorGridlineStyle = LineStyle.Solid,
                MajorGridlineColor = OxyColors.LightGray
            };

            model.Axes.Add(categoryAxis);

            // Değer eksenini yatay eksene ekleme (X ekseni)
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Değerler",
                AxislineStyle = LineStyle.Solid,
                AxislineColor = OxyColors.Black,
                MajorGridlineStyle = LineStyle.Solid,
                MajorGridlineColor = OxyColors.LightGray
            };

            model.Axes.Add(valueAxis);

            // Bar Series oluşturma ve özelleştirme
            var barSeries = new BarSeries
            {
                ItemsSource = values,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            model.Series.Add(barSeries);

            plotView1.Model = model;
        }

        private void btnSwitchGraph_Click(object sender, EventArgs e)
        {
            if (graphType == "DepartmentPatient")
                graphType = "DoctorPatient";
            else
                graphType = "DepartmentPatient";

            LoadGraphics();
        }
        #endregion GeneralForm



        #region AppointmentForm
        private void LoadAppointments()
        {
            lvAppointments.Items.Clear();
            lvAppointments.View = View.Details;
            lvAppointments.FullRowSelect = true;

            appointmentList = BusinessLogicManager.AppointmentServices.GetAllAppointments();

            foreach (var appointment in appointmentList)
            {
                var _patient = patientList.First(x => x.TC == appointment.PatientTC);
                var _doctor = doctorList.First(x => x.TC == appointment.DoctorTC);
                var _department = departmentList.First(x => x.Id == appointment.DepartmentId);
                lvAppointments.Items.Add(
                    new ListViewItem(
                        new string[] {
                            $"{_patient.Name} {_patient.Surname}",
                            $"{_doctor.Title} {_doctor.Name} {_doctor.Surname}",
                            _department.Name,
                            appointment.AppointmentDate
                        }
                    )
                );
            }

            lvAppointments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAppointments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cbAppointmentDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            appointmentSelectedDoctor = null;
            LoadAwailableDoctors(cbAppointmentDepartments.SelectedIndex + 1);
            LoadAwailableHours();
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAwailableHours();
        }

        private void lvAwailableDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAwailableHours();
            var selectedDoctorName = "";
            lvAwailableDoctors.SelectedItem = selectedDoctorName;
            selectedDoctorName += lvAwailableDoctors.SelectedItem.ToString().Split(" ")[^2] + " " + lvAwailableDoctors.SelectedItem.ToString().Split(" ")[^1];
            appointmentSelectedDoctor = doctorList.First(x => (x.Name + " " + x.Surname).Contains(selectedDoctorName));

            LoadAwailableHours();
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            // butona tıklanınca arkaplanı değiştir
            LoadAwailableHours();
            ((Button)sender).BackColor = Color.FromArgb(0, 192, 192);
            Button button = sender as Button;
            selectedHour = button.Text;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            BusinessLogicManager.AppointmentServices.AddAppointment(patientList[cbAppointmentPatients.SelectedIndex].TC, appointmentSelectedDoctor!.TC, SessionService.LoginSecretaryUser.TC, dtpAppointmentDate.Value.ToString("dd.MM.yyyy") + " " + selectedHour, appointmentSelectedDoctor.DepartmentId);
            LoadAppointments();
            LoadAwailableHours();
        }

        private void LoadAwailableDoctors(int departmentId)
        {
            lvAwailableDoctors.Items.Clear();
            var doctors = doctorList.Where(x => x.DepartmentId == departmentId).ToList();
            foreach (var doctor in doctors)
            {
                lvAwailableDoctors.Items.Add($"{doctor.Title} {doctor.Name} {doctor.Surname}");
            }
        }

        private void LoadAwailableHours()
        {
            List<string> hours = new()
            {
                "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30"
            };
            foreach (var control in tpAppointment.Controls)
            {
                if (control is Button button && hours.FirstOrDefault(x => x == button.Text, "") != "")
                {
                    button.Click += buttonGroup_Click;
                    appointmentList.ForEach(appointment =>
                    {
                        if (!(appointment.DoctorTC == appointmentSelectedDoctor?.TC && appointment.AppointmentDate == dtpAppointmentDate.Value.ToString("dd.MM.yyyy") + " " + button.Text))
                            button.Enabled = true;
                        button.BackColor = Color.FromArgb(0, 0, 0, 0);
                    });
                    appointmentList.ForEach(appointment =>
                    {
                        if (appointment.DoctorTC == appointmentSelectedDoctor?.TC && appointment.AppointmentDate == dtpAppointmentDate.Value.ToString("dd.MM.yyyy") + " " + button.Text)
                        {
                            button.Enabled = false;
                            button.BackColor = Color.FromArgb(20, 255, 0, 0);
                        }
                    });
                }
            }
            if (appointmentSelectedDoctor == null) return;
            var appointmentDate = dtpAppointmentDate.Value.ToString("dd.MM.yyyy");
        }
        #endregion AppointmentForm



        #region PatientForm
        private void LoadPatients()
        {
            lvPatients.Items.Clear();
            lvPatients.View = View.Details;
            lvPatients.FullRowSelect = true;

            patientList = BusinessLogicManager.PatientServices.GetAllPatients().ToList();

            foreach (var user in patientList)
            {
                lvPatients.Items.Add(
                    new ListViewItem(
                        new string[]
                        {
                            user.TC,
                            user.Name,
                            user.Surname,
                            $"{user.Phone.Substring(0, 3)} {user.Phone.Substring(3, 3)} {user.Phone.Substring(6, 3)} {user.Phone.Substring(9)}",
                            user.Email,
                            user.Gender == 0 ? "Kız" : "Erkek"
                        }
                    )
                );
            }

            lvPatients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvPatients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (!AddPatientInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            if (BusinessLogicManager.PatientServices.AddPatient(txtAddPatientTC.Text, txtAddPatientName.Text, txtAddPatientSurname.Text, txtAddPatientPhone.Text, txtAddPatientMail.Text, (byte)cbAddPatientGender.SelectedIndex))
                MessageBoxHelper.ShowInfo("Kayıt başarılı!");
            else
                MessageBoxHelper.ShowWarning("Kayıt başarısız!");

            txtAddPatientTC.Clear();
            txtAddPatientName.Clear();
            txtAddPatientSurname.Clear();
            txtAddPatientPhone.Clear();
            txtAddPatientPhone.Clear();
            txtAddPatientMail.Clear();
            cbAddPatientGender.SelectedIndex = -1;

            LoadPatients();
        }

        private void lvPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                // Seçilen satırın değerlerini alıyoruz
                ListViewItem selectedItem = listView.SelectedItems[0];
                string TC = selectedItem.SubItems[0].Text;

                PatientModel user = BusinessLogicManager.PatientServices.GetPatientByTC(TC)!;

                string phone = $"{user.Phone.Replace(" ", "").Substring(3)}";

                txtUpdPatientTC.Text = user.TC;
                txtUpdPatientName.Text = user.Name;
                txtUpdPatientSurname.Text = user.Surname;
                txtUpdPatientPhone.Text = phone;
                txtUpdPatientMail.Text = user.Email;
                txtUpdPatientGender.Text = user.Gender == 0 ? "Kız" : "Erkek";
            }
        }

        private void btnUpdPatient_Click(object sender, EventArgs e)
        {
            if (txtUpdPatientTC.Text.Trim() == "")
            {
                MessageBoxHelper.ShowWarning("Lütfen bir hasta seçiniz!");
                return;
            }
            if (!UpdPatientInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            BusinessLogicManager.PatientServices.UpdatePatient(txtUpdPatientTC.Text, txtUpdPatientName.Text, txtUpdPatientSurname.Text, txtUpdPatientPhone.Text, txtUpdPatientMail.Text);

            txtUpdPatientTC.Clear();
            txtUpdPatientName.Clear();
            txtUpdPatientSurname.Clear();
            txtUpdPatientPhone.Clear();
            txtUpdPatientMail.Clear();
            txtUpdPatientGender.Clear();

            LoadPatients();
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            if (txtUpdPatientTC.Text.Trim() == "")
            {
                MessageBoxHelper.ShowWarning("Lütfen bir hasta seçiniz!");
                return;
            }
            BusinessLogicManager.PatientServices.RemovePatient(txtUpdPatientTC.Text.Trim());

            txtUpdPatientTC.Clear();
            txtUpdPatientName.Clear();
            txtUpdPatientSurname.Clear();
            txtUpdPatientPhone.Clear();
            txtUpdPatientMail.Clear();
            txtUpdPatientGender.Clear();

            LoadPatients();
        }

        private bool AddPatientInputValidation()
        {
            if (
                txtAddPatientTC.Text.Trim() == "" ||
                txtAddPatientTC.Text.Length != 11 ||
                txtAddPatientName.Text.Trim() == "" ||
                txtAddPatientSurname.Text.Trim() == "" ||
                txtAddPatientPhone.Text.Trim() == "" ||
                txtAddPatientPhone.Text.Length != 14 ||
                txtAddPatientMail.Text.Trim() == "" ||
                (!RegexHelper.EmailControl(txtAddPatientMail.Text)) ||
                cbAddPatientGender.SelectedIndex == -1
            ) return false;

            return true;
        }

        private bool UpdPatientInputValidation()
        {
            if (
                txtUpdPatientName.Text.Trim() == "" ||
                txtUpdPatientSurname.Text.Trim() == "" ||
                txtUpdPatientPhone.Text.Trim() == "" ||
                txtUpdPatientPhone.Text.Length != 14 ||
                txtUpdPatientMail.Text.Trim() == "" ||
                (!RegexHelper.EmailControl(txtUpdPatientMail.Text))
            ) return false;

            return true;
        }
        #endregion PatientForm



        #region SecretaryForm
        private void LoadSecretaries()
        {
            lvSecretaries.Items.Clear();
            lvSecretaries.View = View.Details;
            lvSecretaries.FullRowSelect = true;

            secretaryList = BusinessLogicManager.SecretaryServices.GetAllSecretaries().ToList();

            foreach (var user in secretaryList)
            {
                if (SessionService.LoginSecretaryUser.TC == user.TC) continue;
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

                SecretaryModel user = BusinessLogicManager.SecretaryServices.GetSecretaryByTC(TC)!;

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
            if (txtUpdTc.Text.Trim() == "")
            {
                MessageBoxHelper.ShowWarning("Lütfen bir sekreter seçiniz!");
                return;
            }
            BusinessLogicManager.SecretaryServices.RemoveSecretary(txtUpdTc.Text.Trim());

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

            if (BusinessLogicManager.SecretaryServices.AddSecretary(txtAddTC.Text, txtAddName.Text, txtAddSurname.Text, txtAddPhone.Text, txtAddMail.Text, (byte)cbAddGender.SelectedIndex))
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
                (!RegexHelper.EmailControl(txtAddMail.Text)) ||
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
                (!RegexHelper.EmailControl(txtUpdMail.Text))
            ) return false;

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdTc.Text.Trim() == "")
            {
                MessageBoxHelper.ShowWarning("Lütfen bir sekreter seçiniz!");
                return;
            }
            if (!UpdInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            BusinessLogicManager.SecretaryServices.UpdateSecretary(txtUpdTc.Text, txtUpdName.Text, txtUpdSurname.Text, txtUpdPhone.Text, txtUpdMail.Text);

            txtUpdTc.Clear();
            txtUpdName.Clear();
            txtUpdSurname.Clear();
            txtUpdPhone.Clear();
            txtUpdMail.Clear();
            txtUpdGender.Clear();

            LoadSecretaries();
        }

        #endregion SecretaryForm



        #region DoctorForm
        private void LoadDoctors()
        {
            lvDoctors.Items.Clear();
            lvDoctors.View = View.Details;
            lvDoctors.FullRowSelect = true;

            doctorList = BusinessLogicManager.DoctorServices.GetAllDoctors().ToList();

            foreach (var user in doctorList)
            {
                lvDoctors.Items.Add(new ListViewItem(new string[] { user.TC, user.Title, user.Name, user.Surname, $"{user.Phone.Substring(0, 3)} {user.Phone.Substring(3, 3)} {user.Phone.Substring(6, 3)} {user.Phone.Substring(9)}", user.Email, user.Gender == 0 ? "Kız" : "Erkek", departmentList.First(x => x.Id == user.DepartmentId).Name }));
            }

            lvDoctors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDoctors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            if (!AddDoctorInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            if (BusinessLogicManager.DoctorServices.AddDoctor(txtAddDoctorTC.Text, txtAddDoctorName.Text, txtAddDoctorSurname.Text, txtAddDoctorPhone.Text, txtAddDoctorMail.Text, (byte)cbAddDoctorGender.SelectedIndex, txtAddDoctorTitle.Text, cbAddDoctorDepartment.SelectedIndex + 1))
                MessageBoxHelper.ShowInfo("Kayıt başarılı!");
            else
                MessageBoxHelper.ShowWarning("Kayıt başarısız!");

            txtAddDoctorTC.Clear();
            txtAddDoctorName.Clear();
            txtAddDoctorSurname.Clear();
            txtAddDoctorPhone.Clear();
            txtAddDoctorPhone.Clear();
            txtAddDoctorMail.Clear();
            cbAddDoctorGender.SelectedIndex = -1;
            txtAddDoctorTitle.Clear();
            cbAddDoctorDepartment.SelectedIndex = 0;

            LoadDoctors();
        }

        private void btnUpdDoctor_Click(object sender, EventArgs e)
        {
            if (!UpdDoctorInputValidation())
            {
                MessageBoxHelper.ShowWarning("Lütfen tüm alanları doldurunuz!");
                return;
            }

            if (BusinessLogicManager.DoctorServices.UpdateDoctor(txtUpdDoctorTC.Text, txtUpdDoctorName.Text, txtUpdDoctorSurname.Text, txtUpdDoctorPhone.Text, txtUpdDoctorMail.Text, txtUpdDoctorTitle.Text, cbUpdDoctorDepartment.SelectedIndex + 1))
                MessageBoxHelper.ShowInfo("Kayıt başarılı!");
            else
                MessageBoxHelper.ShowWarning("Kayıt başarısız!");

            txtUpdDoctorTC.Clear();
            txtUpdDoctorName.Clear();
            txtUpdDoctorSurname.Clear();
            txtUpdDoctorPhone.Clear();
            txtUpdDoctorPhone.Clear();
            txtUpdDoctorMail.Clear();
            txtUpdDoctorGender.Clear();
            txtUpdDoctorTitle.Clear();
            cbUpdDoctorDepartment.SelectedIndex = 0;

            LoadDoctors();
        }

        private void btnRemoveDoctor_Click(object sender, EventArgs e)
        {
            if (txtUpdDoctorTC.Text.Trim() == "")
            {
                MessageBoxHelper.ShowWarning("Lütfen bir doktor seçiniz!");
                return;
            }
            BusinessLogicManager.DoctorServices.RemoveDoctor(txtUpdDoctorTC.Text.Trim());

            txtUpdDoctorTC.Clear();
            txtUpdDoctorName.Clear();
            txtUpdDoctorSurname.Clear();
            txtUpdDoctorPhone.Clear();
            txtUpdDoctorMail.Clear();
            txtUpdDoctorGender.Clear();
            txtUpdDoctorTitle.Clear();
            cbUpdDoctorDepartment.SelectedIndex = 0;

            LoadDoctors();
        }

        private void lvDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                // Seçilen satırın değerlerini alıyoruz
                ListViewItem selectedItem = listView.SelectedItems[0];
                string TC = selectedItem.SubItems[0].Text;

                DoctorModel user = BusinessLogicManager.DoctorServices.GetDoctorByTC(TC)!;

                //string phone = $"({user.Phone.Substring(3,3)}) {user.Phone.Substring(6, 3)}-{user.Phone.Substring(9)}";
                string phone = $"{user.Phone.Replace(" ", "").Substring(3)}";

                txtUpdDoctorTC.Text = user.TC;
                txtUpdDoctorName.Text = user.Name;
                txtUpdDoctorSurname.Text = user.Surname;
                txtUpdDoctorPhone.Text = phone;
                txtUpdDoctorMail.Text = user.Email;
                txtUpdDoctorGender.Text = user.Gender == 0 ? "Kız" : "Erkek";
                cbAddDoctorDepartment.SelectedIndex = departmentList.First(x => x.Id == user.DepartmentId).Id - 1;
                txtUpdDoctorTitle.Text = user.Title;
            }
        }

        private bool AddDoctorInputValidation()
        {
            if (
                txtAddDoctorTC.Text.Trim() == "" ||
                txtAddDoctorTC.Text.Length != 11 ||
                txtAddDoctorName.Text.Trim() == "" ||
                txtAddDoctorSurname.Text.Trim() == "" ||
                txtAddDoctorPhone.Text.Trim() == "" ||
                txtAddDoctorPhone.Text.Length != 14 ||
                txtAddDoctorMail.Text.Trim() == "" ||
                (!RegexHelper.EmailControl(txtAddDoctorMail.Text)) ||
                cbAddDoctorGender.SelectedIndex == -1 ||
                txtAddDoctorTitle.Text.Trim() == "" ||
                cbAddDoctorDepartment.SelectedIndex == -1
            ) return false;

            return true;
        }

        private bool UpdDoctorInputValidation()
        {
            if (
                txtUpdDoctorName.Text.Trim() == "" ||
                txtUpdDoctorSurname.Text.Trim() == "" ||
                txtUpdDoctorPhone.Text.Trim() == "" ||
                txtUpdDoctorPhone.Text.Length != 14 ||
                txtUpdDoctorMail.Text.Trim() == "" ||
                (!RegexHelper.EmailControl(txtUpdDoctorMail.Text)) ||
                txtUpdDoctorTitle.Text.Trim() == "" ||
                cbUpdDoctorDepartment.SelectedIndex == -1
            ) return false;

            return true;
        }
        #endregion DoctorForm



        #region ProfileForm
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionService.LoginSecretaryUser = null;
            this.Hide();
            LoginForm loginForm = new();
            loginForm.ShowDialog();
            this.Close();
        }

        private void LoadProfile()
        {
            txtProfileMail.Text = SessionService.LoginSecretaryUser.Email;
            txtProfileName.Text = SessionService.LoginSecretaryUser.Name;
            txtProfileSurname.Text = SessionService.LoginSecretaryUser.Surname;
            txtProfilePhone.Text = SessionService.LoginSecretaryUser.Phone.Replace(" ", "").Substring(3);
        }

        private void btnUpdProfile_Click(object sender, EventArgs e)
        {
            var _name = txtProfileName.Text;
            var _surname = txtProfileSurname.Text;
            var _phone = txtProfilePhone.Text;
            var _mail = txtProfileMail.Text;

            if (BusinessLogicManager.SecretaryServices.UpdateSecretary(SessionService.LoginSecretaryUser.TC, _name, _surname, _phone, _mail))
            {
                SessionService.LoginSecretaryUser = BusinessLogicManager.SecretaryServices.GetSecretaryByTC(SessionService.LoginSecretaryUser.TC);
                MessageBoxHelper.ShowInfo("Güncelleme başarılı!");

                LoadProfile();
            }
            else
                MessageBoxHelper.ShowWarning("Güncelleme başarısız!");
        }
        #endregion ProfileForm
    }
}

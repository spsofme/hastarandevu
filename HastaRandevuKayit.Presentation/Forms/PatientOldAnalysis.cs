using HastaRandevuKayit.BusinessLogic;
using HastaRandevuKayit.DataAccess.Models;
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
    public partial class PatientOldAnalysis : Form
    {
        PatientModel patient;
        DoctorModel doctor;
        DepartmentModel department;
        AnalysisModel analysis;

        public PatientOldAnalysis()
        {
            InitializeComponent();
        }

        public PatientOldAnalysis(string patientTc, string doctorTc, string departmentName, string analysisDate)
        {
            InitializeComponent();

            patient = BusinessLogicManager.PatientServices.GetPatientByTC(patientTc);
            doctor = BusinessLogicManager.DoctorServices.GetDoctorByTC(doctorTc);
            department = BusinessLogicManager.DepartmentServices.GetAllDepartments().First(x => x.Name == departmentName);
            analysis = BusinessLogicManager.AnalysisServices.GetAllAnalysesByPatientTC(patientTc).First(x => x.CreatedDateTime == analysisDate);
        }

        private void PatientOldAnalysis_Load(object sender, EventArgs e)
        {
            txtPatientName.Text = patient.Name + " " + patient.Surname;
            txtDoctorName.Text = $"{doctor.Title} {doctor.Name} {doctor.Surname}";
            txtDepartmentName.Text = department.Name;
            txtDate.Text = analysis.CreatedDateTime;
            txtResultTests.Text = analysis.TestResult;
            txtPatientComplaints.Text = analysis.PatientComplaint;
            txtRequiredTests.Text = analysis.RequestedTest;
            txtTreatment.Text = analysis.Treatment;
            txtRecipe.Text = analysis.Recipe;
        }
    }
}

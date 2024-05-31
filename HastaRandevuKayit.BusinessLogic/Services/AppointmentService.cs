using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class AppointmentService
    {
        private DataAccessManager DataAccess = new();
        public AppointmentModel GetAppointment(int id)
        {
            return DataAccess.AppointmentDataManager.GetAppointmentById(id);
        }

        public List<AppointmentModel> GetAllAppointments()
        {
            return DataAccess.AppointmentDataManager.GetAllAppointments();
        }

        public List<AppointmentModel> GetAllAppointmentsByDoctor(string tc)
        {
            return DataAccess.AppointmentDataManager.GetAllAppointmentsByDoctor(tc);
        }

        public bool AddAppointment(string patientTC, string doctorTC, string secretaryTC, string appointmentDate, int departmentId, string? description = null)
        {
            return DataAccess.AppointmentDataManager.AddAppointment(new AppointmentModel
            {
                PatientTC = patientTC,
                DoctorTC = doctorTC,
                SecretaryTC = secretaryTC,
                AppointmentDate = appointmentDate,
                Description = description ?? "",
                DepartmentId = departmentId
            });
        }

        public bool UpdateAppointment(int id, string patientTC, string doctorTC, string secretaryTC, string appointmentDate, int departmentId, string? description = null, bool isCompleted = false)
        {
            return DataAccess.AppointmentDataManager.AddAppointment(new AppointmentModel
            {
                Id = id,
                PatientTC = patientTC,
                DoctorTC = doctorTC,
                SecretaryTC = secretaryTC,
                AppointmentDate = appointmentDate,
                Description = description ?? "",
                DepartmentId = departmentId,
                IsCompleted = isCompleted
            });
        }

        public bool RemoveAppointment(int id)
        {
            return DataAccess.AppointmentDataManager.RemoveAppointment(id);
        }
    }
}

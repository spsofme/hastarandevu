using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class AppointmentRepository
    {
        public AppointmentModel GetAppointmentById(int id)
        {
            AppointmentModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Randevu WHERE Id = ? AND Gerceklesti = FALSE AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@Id", id);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new AppointmentModel
                    {
                        Id = (int)reader["Id"],
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString(),
                        SecretaryTC = reader["SekreterTC"].ToString(),
                        AppointmentDate = reader["RandevuTarihi"].ToString(),
                        Description = reader["Aciklama"]?.ToString(),
                        IsCompleted = (bool)reader["Gerceklesti"],
                        DepartmentId = (int)reader["DepartmanId"]
                    };
                }
            });
            return result;
        }

        public List<AppointmentModel> GetAllAppointments()
        {
            List<AppointmentModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Randevu WHERE Pasif = FALSE", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AppointmentModel
                    {
                        Id = (int) reader["Id"],
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString(),
                        SecretaryTC = reader["SekreterTC"].ToString(),
                        AppointmentDate = reader["RandevuTarihi"].ToString(),
                        Description = reader["Aciklama"]?.ToString(),
                        IsCompleted = (bool)reader["Gerceklesti"],
                        DepartmentId = (int)reader["DepartmanId"]
                    });
                }
            });
            return result;
        }

        public List<AppointmentModel> GetAllAppointmentsByDoctor(string tc)
        {
            List<AppointmentModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Randevu WHERE Pasif = FALSE AND DoktorTC = ? ORDER BY RandevuTarihi DESC", DBUtil.connection);
                command.Parameters.AddWithValue("@DoctorTC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AppointmentModel
                    {
                        Id = (int)reader["Id"],
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString(),
                        SecretaryTC = reader["SekreterTC"].ToString(),
                        AppointmentDate = reader["RandevuTarihi"].ToString(),
                        Description = reader["Aciklama"]?.ToString(),
                        IsCompleted = (bool)reader["Gerceklesti"],
                        DepartmentId = (int)reader["DepartmanId"]
                    });
                }
            });
            return result;
        }

        public List<AppointmentModel> GetAllAppointmentsByPatient(string tc)
        {
            List<AppointmentModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Randevu WHERE Pasif = FALSE AND HastaTC = ? ORDER BY RandevuTarihi DESC", DBUtil.connection);
                command.Parameters.AddWithValue("@HastaTC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AppointmentModel
                    {
                        Id = (int)reader["Id"],
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString(),
                        SecretaryTC = reader["SekreterTC"].ToString(),
                        AppointmentDate = reader["RandevuTarihi"].ToString(),
                        Description = reader["Aciklama"]?.ToString(),
                        IsCompleted = (bool)reader["Gerceklesti"],
                        DepartmentId = (int)reader["DepartmanId"]
                    });
                }
            });
            return result;
        }

        public bool AddAppointment(AppointmentModel appointment)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Randevu (HastaTC, DoktorTC, SekreterTC, RandevuTarihi, Aciklama, DepartmanId) VALUES (?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@HastaTC", appointment.PatientTC);
                command.Parameters.AddWithValue("@DoktorTC", appointment.DoctorTC);
                command.Parameters.AddWithValue("@SekreterTC", appointment.SecretaryTC);
                command.Parameters.AddWithValue("@RandevuTarihi", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@Aciklama", appointment.Description);
                command.Parameters.AddWithValue("@DepartmanId", appointment.DepartmentId);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool UpdateAppointment(AppointmentModel appointment)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Randevu SET HastaTC = ?, DoktorTC = ?, SekreterTC = ?, RandevuTarihi = ?, Aciklama = ?, DepartmanId = ? WHERE Pasif = FALSE AND Id = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@HastaTC", appointment.PatientTC);
                command.Parameters.AddWithValue("@DoktorTC", appointment.DoctorTC);
                command.Parameters.AddWithValue("@SekreterTC", appointment.SecretaryTC);
                command.Parameters.AddWithValue("@RandevuTarihi", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@Aciklama", appointment.Description);
                command.Parameters.AddWithValue("@DepartmanId", appointment.DepartmentId);
                command.Parameters.AddWithValue("@Id", appointment.Id);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool RemoveAppointment(int id)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Randevu SET Pasif = TRUE WHERE Id = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@Id", id);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }
    }
}

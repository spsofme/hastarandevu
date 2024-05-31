using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class PatientRepository
    {
        public List<PatientModel> GetAllPatients()
        {
            List<PatientModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Hasta WHERE Pasif = FALSE", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new PatientModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Gender = (byte)int.Parse(reader["Cinsiyet"].ToString())
                    });
                }
            });
            return result;
        }

        public PatientModel? GetPatientByTC(string tc)
        {
            PatientModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Hasta WHERE TC = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new PatientModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Gender = (byte)int.Parse(reader["Cinsiyet"].ToString())
                    };
                }
            });
            return result;
        }

        public bool AddPatient(PatientModel patient)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Hasta (TC, Ad, Soyad, Email, Telefon, Cinsiyet) VALUES (?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", patient.TC);
                command.Parameters.AddWithValue("@Ad", patient.Name);
                command.Parameters.AddWithValue("@Soyad", patient.Surname);
                command.Parameters.AddWithValue("@Email", patient.Email);
                command.Parameters.AddWithValue("@Telefon", patient.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", patient.Gender);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool UpdatePatient(PatientModel patient)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Hasta SET Ad = ?, Soyad = ?, Email = ?, Telefon = ?, Cinsiyet = ? WHERE TC = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@Ad", patient.Name);
                command.Parameters.AddWithValue("@Soyad", patient.Surname);
                command.Parameters.AddWithValue("@Email", patient.Email);
                command.Parameters.AddWithValue("@Telefon", patient.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", patient.Gender);
                command.Parameters.AddWithValue("@TC", patient.TC);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool RemovePatient(string tc)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Hasta SET Pasif = TRUE WHERE TC = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }
    }
}

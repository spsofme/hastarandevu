using HastaRandevuKayit.DataAccess.Enums;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class DoctorRepository
    {
        public List<DoctorModel> GetAllDoctors()
        {
            List<DoctorModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Doktor WHERE Pasif = FALSE", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DoctorModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Gender = (byte)(reader["Telefon"].ToString() == "Erkek" ? GenderEnum.Male : GenderEnum.Female),
                        DepartmentId = (int) reader["DepartmanId"],
                        Title = reader["Unvan"].ToString()
                    });
                }
            });
            return result;
        }

        public DoctorModel? GetDoctorByTC(string tc)
        {
            DoctorModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Doktor WHERE TC = ? WHERE Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new DoctorModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Gender = (byte)(reader["Cinsiyet"].ToString() == "Erkek" ? GenderEnum.Male : GenderEnum.Female),
                        DepartmentId = (int) reader["DepartmanId"],
                        Title = reader["Unvan"].ToString()
                    };
                }
            });
            return result;
        }

        public bool AddDoctor(DoctorModel doctor)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Doktor (TC, Ad, Soyad, Email, Telefon, Cinsiyet, Sifre, DepartmanId, Unvan) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", doctor.TC);
                command.Parameters.AddWithValue("@Ad", doctor.Name);
                command.Parameters.AddWithValue("@Soyad", doctor.Surname);
                command.Parameters.AddWithValue("@Email", doctor.Email);
                command.Parameters.AddWithValue("@Telefon", doctor.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", doctor.Gender);
                command.Parameters.AddWithValue("@Sifre", doctor.Password);
                command.Parameters.AddWithValue("@DepartmanId", doctor.DepartmentId);
                command.Parameters.AddWithValue("@Unvan", doctor.Title);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool UpdateDoctor(DoctorModel doctor)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Sekreter SET Ad = ?, Soyad = ?, Email = ?, Telefon = ?, Cinsiyet = ?, Sifre = ?, DepartmanId = ?, Unvan = ? WHERE TC = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@Ad", doctor.Name);
                command.Parameters.AddWithValue("@Soyad", doctor.Surname);
                command.Parameters.AddWithValue("@Email", doctor.Email);
                command.Parameters.AddWithValue("@Telefon", doctor.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", doctor);
                command.Parameters.AddWithValue("@Sifre", doctor.Password);
                command.Parameters.AddWithValue("@DepartmanId", doctor.DepartmentId);
                command.Parameters.AddWithValue("@Unvan", doctor.Title);
                command.Parameters.AddWithValue("@TC", doctor.TC);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool DeleteDoctor(string tc)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Doktor SET Pasif = TRUE WHERE TC = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }
    }
}

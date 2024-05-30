using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class SecretaryRepository
    {
        public List<SecretaryModel> GetAllSecretaries()
        {
            List<SecretaryModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Sekreter WHERE Pasif = FALSE", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new SecretaryModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Password = reader["Sifre"].ToString(),
                        Gender = (byte) int.Parse(reader["Cinsiyet"].ToString())
                    });
                }
            });
            return result;
        }

        public SecretaryModel? GetSecretaryByTC(string tc)
        {
            SecretaryModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Sekreter WHERE TC = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new SecretaryModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Password = reader["Sifre"].ToString(),
                        Gender = (byte) int.Parse(reader["Cinsiyet"].ToString())
                    };
                }
            });
            return result;
        }

        public SecretaryModel? LoginSecretary(string tc, string password)
        {
            SecretaryModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Sekreter WHERE TC = ? AND Sifre = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                command.Parameters.AddWithValue("@Sifre", password);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new SecretaryModel
                    {
                        TC = reader["TC"].ToString(),
                        Name = reader["Ad"].ToString(),
                        Surname = reader["Soyad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Telefon"].ToString(),
                        Password = reader["Sifre"].ToString(),
                        Gender = (byte) int.Parse(reader["Cinsiyet"].ToString())
                    };
                }
            });
            return result;
        }

        public bool AddSecretary(SecretaryModel secretary)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Sekreter (TC, Ad, Soyad, Email, Telefon, Cinsiyet, Sifre) VALUES (?, ?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", secretary.TC);
                command.Parameters.AddWithValue("@Ad", secretary.Name);
                command.Parameters.AddWithValue("@Soyad", secretary.Surname);
                command.Parameters.AddWithValue("@Email", secretary.Email);
                command.Parameters.AddWithValue("@Telefon", secretary.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", secretary.Gender);
                command.Parameters.AddWithValue("@Sifre", secretary.Password);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool UpdateSecretary(SecretaryModel secretary)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Sekreter SET Ad = ?, Soyad = ?, Email = ?, Telefon = ?, Cinsiyet = ?, Sifre = ? WHERE TC = ? AND Pasif = FALSE", DBUtil.connection);
                command.Parameters.AddWithValue("@Ad", secretary.Name);
                command.Parameters.AddWithValue("@Soyad", secretary.Surname);
                command.Parameters.AddWithValue("@Email", secretary.Email);
                command.Parameters.AddWithValue("@Telefon", secretary.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", secretary.Gender);
                command.Parameters.AddWithValue("@Sifre", secretary.Password);
                command.Parameters.AddWithValue("@TC", secretary.TC);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }

        public bool RemoveSecretary(string tc)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("UPDATE Sekreter SET Pasif = TRUE WHERE TC = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", tc);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }
    }
}

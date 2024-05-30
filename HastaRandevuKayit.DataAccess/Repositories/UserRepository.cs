using HastaRandevuKayit.DataAccess.Enums;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class UserRepository
    {
        private static List<UserModel> Users =
        [
            new()
            {
                TC = "10390852288",
                Name = "Kerim",
                Surname = "ER",
                Phone = "+905320638626",
                Email = "kerimer@hotmail.com",
                Gender = (byte)GenderEnum.Male,
            }
        ];

        public bool AddUser(UserModel user)
        {
            return DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Sekreter (TC, Ad, Soyad, Email, Telefon, Cinsiyet, Sifre) VALUES (?, ?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@TC", user.TC);
                command.Parameters.AddWithValue("@Ad", user.Name);
                command.Parameters.AddWithValue("@Soyad", user.Surname);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Telefon", user.Phone);
                command.Parameters.AddWithValue("@Cinsiyet", user.Gender);
                command.Parameters.AddWithValue("@Sifre", user.TC);
                command.ExecuteNonQuery();
            });
        }

        public UserModel? GetUserByTC(string tc)
        {
            return Users.FirstOrDefault(x => x.TC == tc);
        }

        public List<UserModel> GetUsersByDepartmentId(int departmentId)
        {
            return [];
        }

        public bool UpdateUser(UserModel user)
        {
            var index = Users.FindIndex(x => x.TC == user.TC);
            if (index != -1)
                Users[index] = user;
            return index != -1;
        }

        public List<UserModel> GetAllUsers()
        {
            return Users;
        }

        public bool RemoveUserByTc(string tc)
        {
            return Users.RemoveAll(x => x.TC == tc) > 0;
        }
    }
}

using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.BusinessLogic.Helpers;
using HastaRandevuKayit.DataAccess.Enums;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class UserService
    {
        private DataAccessManager DataAccess = new();


        public UserModel? GetUserByTC(string tc)
        {
            return DataAccess.UserDataManager.GetUserByTC(tc);
        }

        public void AddPatient(string tc, string name, string surname, string phone, string email, byte gender)
        {
            if (DataAccess.UserDataManager.GetUserByTC(tc) != null)
                throw new Exception("User already exists!");

            DataAccess.UserDataManager.AddUser(new UserModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = phone,
                Gender = gender,
            });
        }

        public void AddDoctor(string tc, string name, string surname, string phone, string email, byte gender)
        {
            DoctorModel? user = DataAccess.DoctorDataManager.GetDoctorByTC(tc);
            if (user != null && user.Password != null)
                throw new Exception("User already exists!");

            DataAccess.DoctorDataManager.AddDoctor(new DoctorModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = phone,
                Gender = gender,
                Password = PasswordHelper.EncryptPassword(tc),
                Title = "Dr.",
                DepartmentId = 1
            });
        }

        public bool AddSecretary(string tc, string name, string surname, string phone, string email, byte gender)
        {
            DoctorModel? user = DataAccess.DoctorDataManager.GetDoctorByTC(tc);
            if (user != null && user.Password != null)
                return false;

            return DataAccess.UserDataManager.AddUser(new DoctorModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = phone,
                Gender = gender,
                Password = PasswordHelper.EncryptPassword(tc),
                Title = "Dr.",
                DepartmentId = 1
            });
        }

        public bool UpdateUser(UserModel user)
        {
            return DataAccess.UserDataManager.UpdateUser(user);
        }

        public bool RemoveUserByTc(string tc)
        {
            return DataAccess.UserDataManager.RemoveUserByTc(tc);
        }
    }
}

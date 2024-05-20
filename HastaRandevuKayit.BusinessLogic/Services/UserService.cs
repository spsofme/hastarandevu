using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.BusinessLogic.Helpers;
using HastaRandevuKayit.DataAccess.Enums;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class UserService
    {
        private DataAccessManager DataAccess = new();

        public UserModel? Login(string tc, string password)
        {
            return DataAccess.UserDataManager.Login(tc, password);
        }

        public UserModel? GetUserByTC(string tc)
        {
            return DataAccess.UserDataManager.GetUserByTC(tc);
        }

        public List<UserModel> GetUserByRole(UserRoleEnum role)
        {
            return DataAccess.UserDataManager.GetUserByRole((byte)role);
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
            UserModel? user = DataAccess.UserDataManager.GetUserByTC(tc);
            if (user != null && user.Password != null)
                throw new Exception("User already exists!");

            DataAccess.UserDataManager.AddUser(new UserModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = phone,
                Gender = gender,
                Password = PasswordHelper.EncryptPassword(PasswordHelper.CreateRandomPassword()),
                Role = (byte)UserRoleEnum.Doctor
            });
        }

        public bool AddSecretary(string tc, string name, string surname, string phone, string email, byte gender)
        {
            UserModel? user = DataAccess.UserDataManager.GetUserByTC(tc);
            if (user != null && user.Password != null)
                return false;

            DataAccess.UserDataManager.AddUser(new UserModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = phone,
                Gender = gender,
                Password = PasswordHelper.EncryptPassword(PasswordHelper.CreateRandomPassword()),
                Role = (byte)UserRoleEnum.Secretary
            });
            return true;
        }

        public void MakeDoctor(int id)
        {
            UserModel? user = DataAccess.UserDataManager.GetUserById(id);
            if (user == null)
                throw new Exception("User not found!");
            if (user.Password != null)
                throw new Exception("User is already a doctor!");

            user.Password = PasswordHelper.EncryptPassword(PasswordHelper.CreateRandomPassword());
            user.Role = (byte)UserRoleEnum.Doctor;
            DataAccess.UserDataManager.UpdateUser(user);
        }

        public void MakeSecretary(int id)
        {
            UserModel? user = DataAccess.UserDataManager.GetUserById(id);
            if (user == null)
                throw new Exception("User not found!");
            if (user.Password != null)
                throw new Exception("User is already a secretary!");

            user.Password = PasswordHelper.EncryptPassword(PasswordHelper.CreateRandomPassword());
            user.Role = (byte)UserRoleEnum.Secretary;
            DataAccess.UserDataManager.UpdateUser(user);
        }

        public bool UpdateUser(UserModel user)
        {
            return DataAccess.UserDataManager.UpdateUser(user);
        }

        public bool RemoveUserById(int id)
        {
            return DataAccess.UserDataManager.RemoveUserById(id);
        }

        public bool RemoveUserByTc(string tc)
        {
            return DataAccess.UserDataManager.RemoveUserByTc(tc);
        }
    }
}

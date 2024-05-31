using HastaRandevuKayit.BusinessLogic.Helpers;
using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class DoctorService
    {
        private DataAccessManager DataAccess = new();

        public DoctorModel? LoginDoctor(string tc, string password)
        {
            var result = DataAccess.DoctorDataManager.LoginDoctor(tc, PasswordHelper.EncryptPassword(password));
            if (result != null)
                SessionService.LoginDoctorUser = result;
            return result;
        }

        public DoctorModel? GetDoctorByTC(string tc)
        {
            return DataAccess.DoctorDataManager.GetDoctorByTC(tc);
        }

        public List<DoctorModel> GetAllDoctors()
        {
            return DataAccess.DoctorDataManager.GetAllDoctors();
        }

        public List<DoctorModel> GetAllDoctorByDepartmentId(int id)
        {
            return DataAccess.DoctorDataManager.GetDoctorByDepartmentId(id);
        }

        public bool AddDoctor(string tc, string name, string surname, string phone, string email, byte gender, string title, int departmentId)
        {
            if (DataAccess.DoctorDataManager.GetDoctorByTC(tc) != null)
                throw new Exception("Secretary already exists!");

            string password = PasswordHelper.CreateRandomPassword();
            string _phone = ReplaceHelper.PhoneReplace(phone);

            bool result = DataAccess.DoctorDataManager.AddDoctor(new DoctorModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = _phone,
                Password = PasswordHelper.EncryptPassword(password),
                Gender = gender,
                Title = title,
                DepartmentId = departmentId
            });

            if (result)
                BusinessLogicManager.EmailServices.SendMail(email, $"Merhaba {title} {name} {surname},\n\nHasta Randevu Sistemi'ne hoş geldiniz. Giriş bilgileriniz aşağıdaki gibidir.\n\nTC Kimlik Numarası: {tc}\nŞifre: {password}\n\nİyi günler dileriz.");

            return result;
        }

        public bool UpdateDoctor(string tc, string name, string surname, string phone, string email, string title, int departmentId, string? password = null)
        {
            var doctor = GetDoctorByTC(tc);
            string _phone = ReplaceHelper.PhoneReplace(phone);
            return DataAccess.DoctorDataManager.UpdateDoctor(new DoctorModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = _phone,
                Password = password != null ? PasswordHelper.EncryptPassword(password) : doctor!.Password,
                Gender = doctor!.Gender,
                Title = title,
                DepartmentId = departmentId
            });
        }

        public bool RemoveDoctor(string tc)
        {
            return DataAccess.DoctorDataManager.RemoveDoctor(tc);
        }
    }
}

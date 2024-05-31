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
    public class PatientService
    {
        private DataAccessManager DataAccess = new();

        public PatientModel? GetPatientByTC(string tc)
        {
            return DataAccess.PatientDataManager.GetPatientByTC(tc);
        }

        public List<PatientModel> GetAllPatients()
        {
            return DataAccess.PatientDataManager.GetAllPatients();
        }

        public bool AddPatient(string tc, string name, string surname, string phone, string email, byte gender)
        {
            if (DataAccess.PatientDataManager.GetPatientByTC(tc) != null)
                throw new Exception("Patient already exists!");

            string _phone = ReplaceHelper.PhoneReplace(phone);

            bool result = DataAccess.PatientDataManager.AddPatient(new PatientModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = _phone,
                Gender = gender,
            });

            if (result)
                BusinessLogicManager.EmailServices.SendMail(email, $"Merhaba {name} {surname},\n\nHasta Randevu Sistemi'ne hoş geldiniz. Kayıt işlemleriniz tamamlanmıştır.");

            return result;
        }

        public bool UpdatePatient(string tc, string name, string surname, string phone, string email)
        {
            var patient = GetPatientByTC(tc);
            string _phone = ReplaceHelper.PhoneReplace(phone);
            return DataAccess.PatientDataManager.UpdatePatient(new PatientModel()
            {
                TC = tc,
                Email = email,
                Name = name,
                Surname = surname,
                Phone = _phone,
                Gender = patient!.Gender
            });
        }

        public bool RemovePatient(string tc)
        {
            return DataAccess.PatientDataManager.RemovePatient(tc);
        }
    }
}

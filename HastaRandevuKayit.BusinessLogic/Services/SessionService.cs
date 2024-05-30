using HastaRandevuKayit.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public static class SessionService
    {
        public static SecretaryModel LoginSecretaryUser { get; set; }
        public static DoctorModel LoginDoctorUser { get; set; }
    }
}

using HastaRandevuKayit.BusinessLogic.Services;

namespace HastaRandevuKayit.BusinessLogic
{
    public class BusinessLogicManager
    {
        public static PatientService PatientServices = new();
        public static SecretaryService SecretaryServices = new();
        public static DoctorService DoctorServices = new();
        public static DepartmentService DepartmentServices = new();
        public static AppointmentService AppointmentServices = new();
        public static AnalysisService AnalysisServices = new();

        public static EmailService EmailServices = new();
    }
}

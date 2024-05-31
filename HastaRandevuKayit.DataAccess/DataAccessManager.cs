using HastaRandevuKayit.DataAccess.Repositories;

namespace HastaRandevuKayit.DataAccess
{
    public class DataAccessManager
    {
        public DepartmentRepository DepartmentDataManager = new();
        public DoctorRepository DoctorDataManager = new();
        public SecretaryRepository SecretaryDataManager = new();
        public PatientRepository PatientDataManager = new();
        public AppointmentRepository AppointmentDataManager = new();
        public AnalysisRepository AnalysisDataManager = new();
    }
}

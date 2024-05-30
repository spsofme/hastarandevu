using HastaRandevuKayit.DataAccess.Repositories;

namespace HastaRandevuKayit.DataAccess
{
    public class DataAccessManager
    {
        public UserRepository UserDataManager = new();
        public DepartmentRepository DepartmentDataManager = new();
        public DoctorRepository DoctorDataManager = new();
        public SecretaryRepository SecretaryDataManager = new();
    }
}

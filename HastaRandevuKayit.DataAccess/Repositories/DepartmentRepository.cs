using HastaRandevuKayit.DataAccess.Models;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class DepartmentRepository
    {
        private static List<DepartmentModel> Departments = [];

        public void AddDepartment(DepartmentModel department)
        {
            if (Departments.Count == 0)
                department.Id = 1;
            else
                department.Id = Departments[^1].Id + 1;
            Departments.Add(department);
        }

        public DepartmentModel? GetDepartmentById(int id)
        {
            return Departments.FirstOrDefault(x => x.Id == id);
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            return Departments;
        }

        public void AddUser(int departmentId, int id)
        {
            DataAccessManager dataAccessManager = new();

            var user = dataAccessManager.UserDataManager.GetUserById(id);
            if (user == null)
                throw new Exception("User not found!");

            var department = GetDepartmentById(departmentId);
            if (department == null)
                throw new Exception("Department not found!");

            // Ekleme işlemi
        }
    }
}

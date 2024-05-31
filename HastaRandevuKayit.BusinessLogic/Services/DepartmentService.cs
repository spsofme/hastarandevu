using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class DepartmentService
    {
        private DataAccessManager DataAccess = new();

        public List<DepartmentModel> GetAllDepartments()
        {
            return DataAccess.DepartmentDataManager.GetAllDepartments();
        }

        public DepartmentModel? GetDepartmentById(int id)
        {
            return DataAccess.DepartmentDataManager.GetDepartmentById(id);
        }
    }
}

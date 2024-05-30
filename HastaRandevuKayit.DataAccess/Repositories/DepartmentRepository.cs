using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System.Data.OleDb;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class DepartmentRepository
    {
        public DepartmentModel? GetDepartmentById(int id)
        {
            DepartmentModel? result = null;

            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Departman WHERE Id = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@Id", id);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new DepartmentModel
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Ad"].ToString()
                    };
                }
            });

            return result;
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Departman", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DepartmentModel
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Ad"].ToString()
                    });
                }
            });
            return result;
        }
    }
}

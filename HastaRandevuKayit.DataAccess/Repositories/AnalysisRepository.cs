using HastaRandevuKayit.DataAccess.Models;
using HastaRandevuKayit.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class AnalysisRepository
    {
        public List<AnalysisModel> GetAllAnalyses()
        {
            List<AnalysisModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Tahlil", DBUtil.connection);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AnalysisModel
                    {
                        Id = (int)reader["Id"],
                        DepartmentId = (int) reader["DepartmanId"],
                        PatientComplaint = reader["HastaSikayeti"].ToString(),
                        Recipe = reader["Recete"].ToString(),
                        TestResult = reader["TahlilSonuclari"].ToString(),
                        Treatment = reader["Tedavi"].ToString(),
                        RequestedTest = reader["GerekliTahliller"].ToString(),
                        CreatedDateTime = reader["OlusmaTarihi"].ToString(),
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString()
                    });
                }
            });
            return result;
        }

        public AnalysisModel? GetAnalysisById(int id)
        {
            AnalysisModel? result = null;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Tahlil WHERE Id = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@Id", id);
                using OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new AnalysisModel()
                    {
                        Id = (int)reader["Id"],
                        DepartmentId = (int)reader["DepartmanId"],
                        PatientComplaint = reader["HastaSikayeti"].ToString(),
                        Recipe = reader["Recete"].ToString(),
                        TestResult = reader["TahlilSonuclari"].ToString(),
                        Treatment = reader["Tedavi"].ToString(),
                        RequestedTest = reader["GerekliTestler"].ToString(),
                        CreatedDateTime = reader["OlusturmaTarihi"].ToString(),
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString()
                    };
                }
            });
            return result;
        }

        public List<AnalysisModel> GetAnalysesByPatinetTC(string tc)
        {
            List<AnalysisModel> result = [];
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("SELECT * FROM Tahlil WHERE HastaTC = ?", DBUtil.connection);
                command.Parameters.AddWithValue("@HastaTC", tc);
                using OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new AnalysisModel
                    {
                        Id = (int)reader["Id"],
                        DepartmentId = (int)reader["DepartmanId"],
                        PatientComplaint = reader["HastaSikayeti"].ToString(),
                        Recipe = reader["Recete"].ToString(),
                        TestResult = reader["TahlilSonuclari"].ToString(),
                        Treatment = reader["Tedavi"].ToString(),
                        RequestedTest = reader["GerekliTahliller"].ToString(),
                        CreatedDateTime = reader["OlusmaTarihi"].ToString(),
                        PatientTC = reader["HastaTC"].ToString(),
                        DoctorTC = reader["DoktorTC"].ToString()
                    });
                }
            });
            return result;
        }

        public bool AddAnalysis(AnalysisModel analysis)
        {
            int result = 0;
            DBUtil.DatabaseQuery(() =>
            {
                using OleDbCommand command = new("INSERT INTO Tahlil (DepartmanId, TahlilSonuclari, Recete, GerekliTahliller, Tedavi, HastaSikayeti, OlusmaTarihi, HastaTC, DoktorTC) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)", DBUtil.connection);
                command.Parameters.AddWithValue("@DepartmanId", analysis.DepartmentId);
                command.Parameters.AddWithValue("@TahlilSonuclari", analysis.TestResult);
                command.Parameters.AddWithValue("@Recete", analysis.Recipe);
                command.Parameters.AddWithValue("@GerekliTahliller", analysis.RequestedTest);
                command.Parameters.AddWithValue("@Tedavi", analysis.Treatment);
                command.Parameters.AddWithValue("@HastaSikayeti", analysis.PatientComplaint);
                command.Parameters.AddWithValue("@OlusmaTarihi", analysis.CreatedDateTime);
                command.Parameters.AddWithValue("@HastaTC", analysis.PatientTC);
                command.Parameters.AddWithValue("@DoktorTC", analysis.DoctorTC);
                result = command.ExecuteNonQuery();
            });
            return result > 0;
        }
    }
}

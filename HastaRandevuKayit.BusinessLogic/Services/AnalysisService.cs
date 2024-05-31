using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class AnalysisService
    {
        private DataAccessManager DataAccess = new();

        public List<AnalysisModel> GetAllAnalyses()
        {
            return DataAccess.AnalysisDataManager.GetAllAnalyses();
        }

        public AnalysisModel? GetAnalysisById(int id)
        {
            return DataAccess.AnalysisDataManager.GetAnalysisById(id);
        }

        public List<AnalysisModel> GetAllAnalysesByPatientTC(string patientTC)
        {
            return DataAccess.AnalysisDataManager.GetAnalysesByPatinetTC(patientTC);
        }

        public bool AddAnalysis(int departmentId, string patientComplaint, string recipe, string testResult, string treatment, string requestedTest, string createdDateTime, string patientTC, string doctorTC)
        {
            return DataAccess.AnalysisDataManager.AddAnalysis(new AnalysisModel()
            {
                DepartmentId = departmentId,
                PatientComplaint = patientComplaint,
                Recipe = recipe,
                TestResult = testResult,
                Treatment = treatment,
                RequestedTest = requestedTest,
                CreatedDateTime = createdDateTime,
                PatientTC = patientTC,
                DoctorTC = doctorTC
            });
        }
    }
}

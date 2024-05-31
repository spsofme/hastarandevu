namespace HastaRandevuKayit.DataAccess.Models
{
    public class AnalysisModel
    {
        public int? Id { get; set; }
        public int DepartmentId { get; set; }
        public string PatientComplaint { get; set; }
        public string Recipe { get; set; }
        public string TestResult { get; set; }
        public string Treatment { get; set; }
        public string RequestedTest { get; set; }
        public string CreatedDateTime { get; set; }
        public string PatientTC { get; set; }
        public string DoctorTC { get; set; }
    }
}

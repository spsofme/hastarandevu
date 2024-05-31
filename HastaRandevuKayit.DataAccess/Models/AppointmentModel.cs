namespace HastaRandevuKayit.DataAccess.Models
{
    public class AppointmentModel
    {
        public int? Id { get; set; }
        public required string PatientTC { get; set; }
        public required string DoctorTC { get; set; }
        public required string SecretaryTC { get; set; }
        public required string AppointmentDate { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int DepartmentId { get; set; }
    }
}

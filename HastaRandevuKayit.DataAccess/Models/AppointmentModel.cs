using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.DataAccess.Models
{
    public class AppointmentModel
    {
        public int? Id { get; set; }
        public required int DoctorId { get; set; }
        public required int PatientId { get; set; }
        public required DateTime AppointmentDate { get; set; }
        public string? Description { get; set; }
    }
}

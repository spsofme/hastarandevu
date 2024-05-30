using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.DataAccess.Models
{
    public class DoctorModel : UserModel
    {
        public string? Password { get; set; }
        public required int DepartmentId { get; set; }
        public required string Title { get; set; }
    }
}

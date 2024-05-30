using HastaRandevuKayit.DataAccess.Enums;

namespace HastaRandevuKayit.DataAccess.Models
{
    public class UserModel
    {
        public required string TC { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

        /// <summary>
        /// 0 -> Female <br/> 1 -> Male
        /// </summary>
        public required byte Gender { get; set; }
    }
}

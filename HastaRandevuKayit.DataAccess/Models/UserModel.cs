using HastaRandevuKayit.DataAccess.Enums;

namespace HastaRandevuKayit.DataAccess.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public required string TC { get; set; }
        public string? Password { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

        /// <summary>
        /// 0 -> Female <br/> 1 -> Male
        /// </summary>
        public required byte Gender { get; set; }

        /// <summary>
        /// 0 -> Patient <br/> 1 -> Doctor <br/> 2 -> Secretary
        /// </summary>
        public byte Role { get; set; } = ((byte)UserRoleEnum.Patient);
    }
}

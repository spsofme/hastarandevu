using System.Text;

namespace HastaRandevuKayit.BusinessLogic.Helpers
{
    public class PasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            // Encrypt the password to Base64
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }

        public static string CreateRandomPassword()
        {
            // Create a random password
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}

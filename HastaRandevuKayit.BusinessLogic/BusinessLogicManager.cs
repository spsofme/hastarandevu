using HastaRandevuKayit.BusinessLogic.Services;

namespace HastaRandevuKayit.BusinessLogic
{
    public class BusinessLogicManager
    {
        public static UserService UserServices = new();
        public static SecretaryService SecretaryServices = new();
        public static EmailService EmailServices = new();
    }
}

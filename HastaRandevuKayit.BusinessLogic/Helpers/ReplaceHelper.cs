namespace HastaRandevuKayit.BusinessLogic.Helpers
{
    public class ReplaceHelper
    {
        public static string PhoneReplace(string phone)
        {
            return "+90" + phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }
    }
}

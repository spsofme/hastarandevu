using HastaRandevuKayit.BusinessLogic.Helpers;
using HastaRandevuKayit.DataAccess;
using HastaRandevuKayit.DataAccess.Models;

namespace HastaRandevuKayit.BusinessLogic.Services
{
	public class SecretaryService
	{
		private DataAccessManager DataAccess = new();

		public SecretaryModel? LoginSecretary(string tc, string password)
		{
			var result = DataAccess.SecretaryDataManager.LoginSecretary(tc, PasswordHelper.EncryptPassword(password));
			if (result != null)
				SessionService.LoginSecretaryUser = result;
			return result;
		}

		public SecretaryModel? GetSecretaryByTC(string tc)
		{
			return DataAccess.SecretaryDataManager.GetSecretaryByTC(tc);
		}

		public List<SecretaryModel> GetAllSecretaries()
		{
			return DataAccess.SecretaryDataManager.GetAllSecretaries();
		}

		public bool AddSecretary(string tc, string name, string surname, string phone, string email, byte gender)
		{
			if (DataAccess.SecretaryDataManager.GetSecretaryByTC(tc) != null)
				throw new Exception("Secretary already exists!");

			string password = PasswordHelper.CreateRandomPassword();
            string _phone = ReplaceHelper.PhoneReplace(phone);

            bool result = DataAccess.SecretaryDataManager.AddSecretary(new SecretaryModel()
			{
				TC = tc,
				Email = email,
				Name = name,
				Surname = surname,
				Phone = _phone,
				Password = PasswordHelper.EncryptPassword(password),
				Gender = gender,
			});

			if (result)
				BusinessLogicManager.EmailServices.SendMail(email, $"Merhaba {name} {surname},\n\nHasta Randevu Sistemi'ne hoş geldiniz. Giriş bilgileriniz aşağıdaki gibidir.\n\nTC Kimlik Numarası: {tc}\nŞifre: {password}\n\nİyi günler dileriz.");
			
			return result;
		}

		public bool UpdateSecretary(string tc, string name, string surname, string phone, string email, string? password = null)
		{
			var secretary = GetSecretaryByTC(tc);
            string _phone = ReplaceHelper.PhoneReplace(phone);
            return DataAccess.SecretaryDataManager.UpdateSecretary(new SecretaryModel()
			{
				TC = tc,
				Email = email,
				Name = name,
				Surname = surname,
				Phone = _phone,
				Password = password != null ? PasswordHelper.EncryptPassword(password) : secretary!.Password,
				Gender = secretary!.Gender
            });
		}

		public bool RemoveSecretary(string tc)
		{
            return DataAccess.SecretaryDataManager.RemoveSecretary(tc);
        }
	}
}

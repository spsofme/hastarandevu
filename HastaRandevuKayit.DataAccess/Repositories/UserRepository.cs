using HastaRandevuKayit.DataAccess.Enums;
using HastaRandevuKayit.DataAccess.Models;

namespace HastaRandevuKayit.DataAccess.Repositories
{
    public class UserRepository
    {
        private static List<UserModel> Users =
        [
            new()
            {
                Id = 1,
                TC = "10390852288",
                Name = "Kerim",
                Surname = "ER",
                Phone = "+905320638626",
                Email = "kerimer@hotmail.com",
                Gender = 0,
                Password = "123456",
                Role = (byte)UserRoleEnum.Secretary
            }
        ];

        public bool AddUser(UserModel user)
        {
            if (Users.Exists(x => x.TC == user.TC))
                return false;
            if (Users.Count == 0)
                user.Id = 1;
            else
                user.Id = Users[^1].Id + 1;
            Users.Add(user);
            return true;
        }

        public UserModel? GetUserById(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel? GetUserByTC(string tc)
        {
            return Users.FirstOrDefault(x => x.TC == tc);
        }

        public List<UserModel> GetUsersByDepartmentId(int departmentId)
        {
            return [];
        }

        public List<UserModel> GetUserByRole(byte role)
        {
            return Users.FindAll(x => x.Role == role);
        }

        public bool UpdateUser(UserModel user)
        {
            var index = Users.FindIndex(x => x.TC == user.TC);
            if (index != -1)
                Users[index] = user;
            return index != -1;
        }

        public List<UserModel> GetAllUsers()
        {
            return Users;
        }

        public UserModel? Login(string tc, string password)
        {
            return Users.FirstOrDefault(x => x.TC == tc && x.Password == password, null);
        }

        public bool RemoveUserById(int id)
        {
            return Users.RemoveAll(x => x.Id == id) > 0;
        }

        public bool RemoveUserByTc(string tc)
        {
            return Users.RemoveAll(x => x.TC == tc) > 0;
        }
    }
}

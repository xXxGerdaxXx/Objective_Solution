
using System.Collections.Generic;
using Application.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public interface IUserService
        {
            void AddUser(UserBase user);
            UserBase GetUserById(int id);
            List<UserBase> GetAllUsers();
        }
    }
}

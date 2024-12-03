using System;
using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Application.Services
{


    public class UserService : IUserService
    {
        private readonly List<UserBase> _users = new();

        public void AddUser(UserBase user)
        {
            _users.Add(user);
        }

        public UserBase GetUserById(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
                throw new Exception("User not found.");
            return user;
        }
        public List<UserBase> GetAllUsers() => _users;
    }
}

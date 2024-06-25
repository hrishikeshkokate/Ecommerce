﻿using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
        Users GetUserByEmail(string Email);
        int AddUser(Users user);
        int EditUser(Users user);
        int DeleteUser(int id);
        Users UpdateUserStatus(int userId, int isActive);
    }
}

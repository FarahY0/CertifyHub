﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;

namespace CertifyHub.Core.Repository
{
    public interface IUsersRepository
    {

        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void UpdateUserPhone(int userId, string newPhoneNumber);
        void UpdateUserImage(int userId, string newImagePath);
        void UpdateUserIsActive(int userId, int isActive);


    }
}

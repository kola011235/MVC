using System;
using System.Collections.Generic;
using task_3_DB.Entities;

namespace task_3_DB.BLL
{
    interface IUserLogic
    {
        void AddUser(string name, DateTime dateOfBirth, int age);
        void DeleteUserByID(int ID);
        ICollection<User> GetAllUsers();
        User GetUserByID(int ID);
        void UpdateUser(int ID, string name, DateTime dateOfBirth, int age);
    }
}
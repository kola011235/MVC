using System.Collections.Generic;
using task_3_DB.Entities;

namespace task_3_DB.DAL
{
    interface IUserDAO
    {
        void AddUser(User user);
        void DeleteUserByID(int ID);
        ICollection<User> GetAllUsers();
        User GetUserdByID(int ID);
        void UpdateUser(User user);
    }
}
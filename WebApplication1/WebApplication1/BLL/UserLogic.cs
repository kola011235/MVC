using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_3_DB.DAL;
using task_3_DB.Entities;
using task_3_DB.Util;

namespace task_3_DB.BLL
{
    class UserLogic : IUserLogic
    {
        IUserDAO userDAO;
        public UserLogic()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
            userDAO = ninjectKernel.Get<IUserDAO>();
        }
        public ICollection<User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        public User GetUserByID(int ID)
        {
            return userDAO.GetUserdByID(ID);
        }

        public void AddUser(string name, DateTime dateOfBirth, int age)
        {
            if(age<0 || age > 100)
            {
                throw new Exception("некорректный возрас задан");
            }
            if ((DateTime.Now - dateOfBirth).Days<0)
            {
                throw new Exception("некорректная дата рождения");
            }
            if ((DateTime.Now - dateOfBirth).Days / 365 != age)
            {
                throw new Exception("дата рождения и возраст не соответсвуют друг другу");
            }

            User user = new User();
            user.Name = name;
            user.Age = age;
            user.DateIfBirth = dateOfBirth;

            userDAO.AddUser(user);
        }

        public void UpdateUser(int ID, string name, DateTime dateOfBirth, int age)
        {
            User user = new User();
            user.ID = ID;
            user.Name = name;
            user.Age = age;
            user.DateIfBirth = dateOfBirth;
            userDAO.UpdateUser(user);
        }

        public void DeleteUserByID(int ID)
        {
            userDAO.DeleteUserByID(ID);
        }
    }
}

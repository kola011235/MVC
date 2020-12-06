using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_3_DB.BLL;
using task_3_DB.Util;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        static IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
        static IUserLogic userLogic = ninjectKernel.Get<IUserLogic>();
        public ActionResult Index()
        {
            ViewBag.Message = "User List";
            var listOfEntities = userLogic.GetAllUsers();
            List<UserModel> listOfModels = new List<UserModel>();
            foreach(var item in listOfEntities)
            {
                listOfModels.Add(new UserModel
                {
                    ID = item.ID,
                    Age = item.Age,
                    DateIfBirth = item.DateIfBirth,
                    Name = item.Name
                });
            }
            return View(listOfModels);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.Message = "AddUser";

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserModel model)
        {
            ViewBag.Message = "AddUser";
            if (ModelState.IsValid)
            {
                userLogic.AddUser(model.Name, model.DateIfBirth, model.Age);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            ViewBag.Message = "EditUser";
            var user = userLogic.GetUserByID(id);
            return View(new UserModel
            {
                Name = user.Name,
                ID = user.ID,
                Age = user.Age,
                DateIfBirth = user.DateIfBirth
                
            });
        }
        [HttpPost]
        public ActionResult EditUser(UserModel model)
        {
            ViewBag.Message = "EditUser";
            if (ModelState.IsValid)
            {
                userLogic.UpdateUser(model.ID, model.Name, model.DateIfBirth, model.Age);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            ViewBag.Message = "DeleteUser";
            var user = userLogic.GetUserByID(id);
            return View(new UserModel
            {
                Name = user.Name,
                ID = user.ID,
                Age = user.Age,
                DateIfBirth = user.DateIfBirth

            });
        }
        [HttpPost]
        [ActionName("DeleteUser")]
        public ActionResult DeleteUserConfirm(int id)
        {
            ViewBag.Message = "DeleteUser";
            if (ModelState.IsValid)
            {
                userLogic.DeleteUserByID(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
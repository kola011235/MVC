using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_3_DB.BLL;
using task_3_DB.Entities;
using task_3_DB.Util;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        static IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
        static IUserLogic userLogic = ninjectKernel.Get<IUserLogic>();
        static IAwardLogic awardLogic = ninjectKernel.Get<IAwardLogic>();
        static IUserAwardRelationLogic userAndAwardLogic = ninjectKernel.Get<IUserAwardRelationLogic>();
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
        public ActionResult ShowUserAwards(int id)
        {
            ViewBag.User = userLogic.GetUserByID(id);
            var listOfEntities = userAndAwardLogic.GetAwardsOfUserByID(id);
            List<AwardModel> listOfModels = new List<AwardModel>();
            foreach (var item in listOfEntities)
            {
                listOfModels.Add(new AwardModel
                {
                    ID = item.ID,
                    Title = item.Title
                });
            }
            return View(listOfModels);
        }
        public ActionResult ShowPotentialUserAwards(int id)
        {
            ViewBag.User = userLogic.GetUserByID(id);
            List<Award> listOfEntities = (List<Award>)awardLogic.GetAllAwards();
            List<Award> alreadyAwarded = (List<Award>)userAndAwardLogic.GetAwardsOfUserByID(id);
            List<AwardModel> listOfModels = new List<AwardModel>();
            foreach (var item in listOfEntities)
            {
                if (alreadyAwarded.Find(x=>x.ID==item.ID)==null)
                {
                    listOfModels.Add(new AwardModel
                    {
                        ID = item.ID,
                        Title = item.Title
                    });
                }
                
            }
            return View(listOfModels);
        }
        public ActionResult AddAwardToUser(int awardID, int userID)
        {
            userAndAwardLogic.AwardUsers(awardID, new List<int>(){ userID});
            return RedirectToAction("ShowUserAwards",new { id = userID });
        }
    }
}
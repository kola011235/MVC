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
    [HandleError]
    public class AwardController : Controller
    {
        static IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
        static IAwardLogic awardLogic = ninjectKernel.Get<IAwardLogic>();
        
        public ActionResult Index()
        {
            ViewBag.Message = "Award List";
            var listOfEntities = awardLogic.GetAllAwards();
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
        
        [HttpGet]
        public ActionResult AddAward()
        {
            ViewBag.Message = "AddAward";

            return View();
        }
        [HttpPost]
        public ActionResult AddAward(AwardModel model)
        {
            ViewBag.Message = "AddAward";
            if (ModelState.IsValid)
            {
                awardLogic.AddAward(model.Title, new List<int>());
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditAward(int id)
        {
            ViewBag.Message = "EditAward";
            var award = awardLogic.GetAwardByID(id);
            return View(new AwardModel
            {
                ID = award.ID,
                Title = award.Title

            });
        }
        [HttpPost]
        public ActionResult EditAward(AwardModel model)
        {
            ViewBag.Message = "EditAward";
            if (ModelState.IsValid)
            {
                awardLogic.UpdateAwardTitle(model.ID, model.Title) ;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteAward(int id)
        {
            ViewBag.Message = "DeleteUser";
            var award = awardLogic.GetAwardByID(id);
            return View(new AwardModel
            {
                ID = award.ID,
                Title = award.Title

            });
        }
        [HttpPost]
        [ActionName("DeleteAward")]
        public ActionResult DeleteAwardConfirm(int id)
        {
            ViewBag.Message = "DeleteUser";
            if (ModelState.IsValid)
            {
                awardLogic.DeleteAwardByID(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
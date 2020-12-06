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
    class AwardLogic : IAwardLogic
    {
        IAwardDAO awardDAO;
        public AwardLogic()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
            awardDAO = ninjectKernel.Get<IAwardDAO>();
        }
        public ICollection<Award> GetAllAwards()
        {
            return awardDAO.GetAllAwards();
        }
        public Award GetAwardByID(int ID)
        {
            return awardDAO.GetAwardByID(ID);
        }
        public int AddAward(string title, List<int> winnersID)
        {
            Award award = new Award();
            award.Title = title;
            return(awardDAO.AddAward(award));
        }
        public void UpdateAwardTitle(int ID, string title)
        {
            Award award = new Award();
            award.Title = title;
            award.ID = ID;
            awardDAO.UpdateAward(award);
        }
        public void DeleteAwardByID(int ID)
        {
            awardDAO.DeleteAwardByID(ID);
        }
    }
}

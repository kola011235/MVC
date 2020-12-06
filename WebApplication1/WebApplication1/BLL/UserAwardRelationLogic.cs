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
    
    class UserAwardRelationLogic : IUserAwardRelationLogic
    {
        IUserAwardRelationDAO relationDAO;
        public UserAwardRelationLogic()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectRegistrations());
            relationDAO = ninjectKernel.Get<IUserAwardRelationDAO>();
        }
        public void AwardUsers(int awardID, List<int> winnersID)
        {
            relationDAO.AwardUsers(awardID, winnersID);
        }
        public ICollection<Award> GetAwardsOfUserByID(int ID)
        {
            return relationDAO.GetAwardsOfUserByID(ID);
        }
    }
}

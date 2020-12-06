using System.Collections.Generic;
using task_3_DB.Entities;

namespace task_3_DB.DAL
{
    interface IUserAwardRelationDAO
    {
        void AwardUsers(int awardID, List<int> winnersID);
        ICollection<Award> GetAwardsOfUserByID(int ID);
    }
}
using System.Collections.Generic;
using task_3_DB.Entities;

namespace task_3_DB.DAL
{
    interface IAwardDAO
    {
        int AddAward(Award award);
        void DeleteAwardByID(int ID);
        ICollection<Award> GetAllAwards();
        Award GetAwardByID(int ID);
        void UpdateAward(Award award);
    }
}
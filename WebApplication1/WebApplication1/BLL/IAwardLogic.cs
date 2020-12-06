using System.Collections.Generic;
using task_3_DB.Entities;

namespace task_3_DB.BLL
{
    interface IAwardLogic
    {
        int AddAward(string title, List<int> winnersID);
        void DeleteAwardByID(int ID);
        ICollection<Award> GetAllAwards();
        Award GetAwardByID(int ID);
        void UpdateAwardTitle(int ID, string title);
    }
}
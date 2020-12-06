using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_3_DB.BLL;
using task_3_DB.DAL;

namespace task_3_DB.Util
{
    class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAwardDAO>().To<AwardDAO>();
            Bind<IUserDAO>().To<UserDAO>();
            Bind<IUserAwardRelationDAO>().To<UserAwardRelationDAO>();
            Bind<IAwardLogic>().To<AwardLogic>();
            Bind<IUserLogic>().To<UserLogic>();
            Bind<IUserAwardRelationLogic>().To<UserAwardRelationLogic>();
        }
    }
}

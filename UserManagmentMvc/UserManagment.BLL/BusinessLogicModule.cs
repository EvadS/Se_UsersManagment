using Ninject.Modules;
using UserManagment.BLL.Abstract;
using UserManagment.BLL.Concrete;

namespace UserManagment.BLL
{
    public class BusinessLogicModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IBusinessLogic>().To<BusinessLogic>();
        }
    }
}

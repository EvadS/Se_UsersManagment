using Ninject.Modules;
using System.Web.ModelBinding;
using UserManagment.BLL.Abstract;
using UserManagment.BLL.Concrete;
using UserManagment.DAL.Abstract;
using UserManagment.DAL.Concrete;
using UserManagment.DataEntities;

namespace UserManagmentMvc.App_Start
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {          
            Bind<IDbContext>().To<UserManagmentContext>();

            Bind<IUserRepository>().To<UserRepository>();
            Bind<IUserService>().To<UserService>();

            // async
            Bind<IUserRepositoryAsync>().To<UserRepositoryAsync>();
            Bind<IUserServiceAsync>().To<UserServiceAsync>();
        }
    }
}
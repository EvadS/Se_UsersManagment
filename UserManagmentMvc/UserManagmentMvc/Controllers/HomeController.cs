using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagmentMvc.Models.ViewModel;
using UserManagmentMvc.Services;

namespace UserManagmentMvc.Controllers
{
    public class HomeController : Controller
    {
        private UserService userService;

        public HomeController()
        {
            userService = new UserService();
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            IEnumerable<UserVM> usersList = await userService.GetUsersList();
            return View(usersList);
        }
    }
}
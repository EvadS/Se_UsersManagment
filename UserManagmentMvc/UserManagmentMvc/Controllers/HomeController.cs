using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagmentMvc.Abstract;
using UserManagmentMvc.EF.Entities;
using UserManagmentMvc.Repositories;

namespace UserManagmentMvc.Controllers
{
    public class HomeController : Controller
    {
        private BaseRepository<User> repo;

        public HomeController()
        {
            repo = new UserRepository();
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            IEnumerable<User> usersList = await repo.GetListAsync();
            return View(usersList);
        }
    }
}
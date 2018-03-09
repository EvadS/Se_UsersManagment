using System.Net;
using System.Web.Mvc;
using UserManagment.BLL.Abstract;
using UserManagment.Models;

namespace UserManagmentMvc.Controllers
{
    public class HomeController : Controller
    {
        private IUserService businesService;

        public HomeController(IUserService _businesService)
        {
            businesService = _businesService;           
        }

        // GET: Home
        public  ActionResult Index()
        {

            var usersList = businesService.GetUsersList();
            return  View(usersList);
        }

        public ActionResult Create()
        {
            var user = new UserVM();
            ViewBag.ModalTitle = "Create new customer";

            return PartialView("_EditPerson", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,MidleName,PhoneNumber,IsEmployed,OrganisationName,StartOnUTc")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Action("Index", "Home");
                var res = businesService.CreateUser(user);
                if (res)
                {
                    return Json(new { success = true, url = url });
                }

                return   Json(new { success = false, url = url });
            }


            return PartialView("_EditPerson", user);
        }


        #region edit actions 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int intValue = id.Value;
            var user =  businesService.GetUser(intValue);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.ModalTitle = "Edit customer";
            return PartialView("_EditPerson", user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "Id,Name,LastName,MidleName,PhoneNumber,IsEmployed,OrganisationName,StartOnUTc")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Action("Index", "Home");
                if ( businesService.UpdateUser(user))
                {
                    return Json(new { success = true, url = url });
                }

                return Json(new { success = false, url = url });
            }

            return PartialView("_EditPerson", user);
        }

        #endregion

        #region delete 
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }

              int intValue = id.Value;
              var user =   businesService.GetUser(intValue);

              if (user == null)
              {
                  return HttpNotFound();
              }

              return PartialView("_Delete", user);
          }

      
        [HttpPost, ActionName("Delete")] 
        public ActionResult DeleteConfirmed(int id)
        {
            var res = businesService.DeleteUser(id);
         
            string url = Url.Action("Index", "Home");

            TempData["Message"] = "Record was deleted.";

            return Json(new { success = true, url = url });
        }

        #endregion 
    }
}

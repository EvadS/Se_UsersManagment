using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

        public ActionResult Create()
        {
            var user = new UserVM();
            ViewBag.ModalTitle = "Create new customer";

            return PartialView("_Edit", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Action("Index", "Home", new { id = user.ID });
                if (userService.CreateUser(user))
                {
                    return Json(new { success = true, url = url });
                }

                return Json(new { success = false, url = url });

            }


            return PartialView("_Edit", user);
        }


        #region edit actions 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int intValue = id.Value;
            var user = userService.GetUserSync(intValue);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.ModalTitle = "Edit customer";
            return PartialView("_Edit", user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(address).State = EntityState.Modified;
                // db.SaveChanges();

                string url = Url.Action("Index", "Home", new { id = user.ID });
                return Json(new { success = true, url = url });
            }


            return PartialView("_Edit", user);
        }

        #endregion

        #region delete 
        /*  public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }

              int intValue = id.Value;
              var user = userService.GetUserSync(intValue);

              if (user == null)
              {
                  return HttpNotFound();
              }

              return PartialView("_Delete", user);
          }

      */
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var res = userService.Delete(id);

            return RedirectToAction("Index");

        }

        #endregion 

    }
}

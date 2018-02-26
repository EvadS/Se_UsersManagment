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



        #region edit actions 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int intValue = id.Value;
            var res = userService.GetUserSync(intValue);

            if (res == null)
            {
                return HttpNotFound();
            }

            return PartialView("_Edit", res);
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
        public ActionResult EditUser(UserVM user)
        {
            try
            {
                var res =  userService.UpdateUser(user);

                if (res)
                    return RedirectToAction("Index");
                else
                    return View(user);
            }
            catch (DataException  dex )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(user);
        }

    }
}
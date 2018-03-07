using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagment.BLL.Abstract;
using UserManagment.BLL.Concrete;
using UserManagment.Models;
using UserManagmentMvc.Services;

namespace UserManagmentMvc.Controllers
{
    public class HomeController : Controller
    {
        private UserService userService;

        private IBusinessLogic businesService;


        public HomeController()
        {
            businesService = new BusinessLogic();           
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
           
            return View(new List<UserVM>());
        }

        public ActionResult Create()
        {
            var user = new UserVM();
            ViewBag.ModalTitle = "Create new customer";

            return PartialView("_EditPerson", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,LastName,MidleName,PhoneNumber,IsEmployed,OrganisationName,StartOnUTc")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Action("Index", "Home");
                var res =   userService.CreateUserAsync(user);
                if (res.Result)
                {
                    return Json(new { success = true, url = url });
                }

                return   Json(new { success = false, url = url });
            }


            return PartialView("_EditPerson", user);
        }


        #region edit actions 
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int intValue = id.Value;
            var user = await userService.GetUserAsync(intValue);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.ModalTitle = "Edit customer";
            return PartialView("_EditPerson", user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LastName,MidleName,PhoneNumber,IsEmployed,OrganisationName,StartOnUTc")] UserVM user)
        {
            if (ModelState.IsValid)
            {
                string url = Url.Action("Index", "Home");
                if (await userService.UpdateUserAsync(user))
                {
                    return Json(new { success = true, url = url });
                }

                return Json(new { success = false, url = url });
            }

            return PartialView("_EditPerson", user);
        }

        #endregion

        #region delete 
          public async  Task<ActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }

              int intValue = id.Value;
              var user =  await userService.GetUserAsync(intValue);

              if (user == null)
              {
                  return HttpNotFound();
              }

              return PartialView("_Delete", user);
          }

      
        [HttpPost, ActionName("Delete")] 
        public ActionResult DeleteConfirmed(int id)
        {
            var res = userService.DeleteAsync(id);
         
            string url = Url.Action("Index", "Home");

            TempData["Message"] = "Record was deleted.";

            return Json(new { success = true, url = url });
        }

        #endregion 
    }
}

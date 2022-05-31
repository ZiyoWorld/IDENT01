using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDENT01.Controllers
{
    public class BSTUController : Controller
    {

        Models.ApplicationDbContext ity_context = new Models.ApplicationDbContext();
        // GET: BSTU
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.IsAuth = this.HttpContext.User.Identity.IsAuthenticated;
            ViewBag.UserName = this.HttpContext.User.Identity.Name;
            ViewBag.IsAdmin = this.HttpContext.User.IsInRole("Administrator");
            ViewBag.IsEmployer = this.HttpContext.User.IsInRole("Employer");
            return View();
        }
        [Authorize(Roles = "Administrator,Employer")]
        public ActionResult IT()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult LH()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult OH()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult IE()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Conf()
        {
            return View();

        }
        
    }
}
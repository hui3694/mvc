using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.ViewModels.SPA;
using OldViewModel = mvc.ViewModels;

namespace mvc.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        // GET: SPA/Main
        public ActionResult Index()
        {
            MainViewModel v = new MainViewModel();
            v.UserName = User.Identity.Name;
            v.FooterData = new OldViewModel.FooterViewModel();
            v.FooterData.CompanyName = "StepByStepSchools";
            v.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", v);
        }
    }
}
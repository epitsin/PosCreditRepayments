using System;
using System.Linq;
using System.Web.Mvc;

namespace POSCreditRepayments.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult InputError()
        {
            return View();
        }
    }
}
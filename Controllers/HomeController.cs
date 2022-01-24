using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using XapiensTest.Services;

namespace XapiensTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public async Task<ActionResult> LoadData()
        {
            XapiensTestService xapiensTest = new XapiensTestService();
            var result = await xapiensTest.GetList();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetData(int id)
        {
            XapiensTestService xapiensTest = new XapiensTestService();
            var result = await xapiensTest.GetById(id);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Login(string username, string password)
        {
            XapiensTestService xapiensTest = new XapiensTestService();
            var result = await xapiensTest.SignIn(username, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
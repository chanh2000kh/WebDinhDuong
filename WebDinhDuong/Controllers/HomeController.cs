using System;
using System.Linq;
using System.Web.Mvc;
using WebDinhDuong.Models;

namespace WebDinhDuong.Controllers
{


    public class HomeController : Controller
    {
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
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

        public ActionResult MenuMon()
        {
            //Truy vấn lấy list Món
            var lstMon = db.MonAns;
            return PartialView(lstMon);
        }

        public ActionResult TimKiem(string searchString)
        {
            var links = from l in db.MonAns
                        select l;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.Name.Contains(searchString));
            }

            return View(links);
        }

        
    }
}
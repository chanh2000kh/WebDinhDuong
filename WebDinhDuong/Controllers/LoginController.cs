using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class LoginController : Controller
    {
        private SqlLogin db = new SqlLogin();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult Login(FormCollection model)
        {        
            string password = model["Password"];
            string email = model["Mail"];
          
            var acc = db.GetAcc(password, email);
            if (db.checkMailExist(email))
            {
                if (acc != null)
                {
                    Session["Email"] = email; ;
                    Session["ID"] = acc.Id;
                    if (acc.Role == 0)
                        return Content("/Admin/Index");
                    if (acc.Role == 1)
                        return Content("/Home/Index");
                }
                else
                {
                    int temp = 0;
                    return Content(temp.ToString());
                }    
            }

            int temp2 = 1;
            return Content(temp2.ToString());
        }
        


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }


}
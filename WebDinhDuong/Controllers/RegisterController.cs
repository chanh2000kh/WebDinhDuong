using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class RegisterController : Controller
    {

        private SqlLogin dbLogin = new SqlLogin();
        private SqlUserInfo dbUser = new SqlUserInfo();
        // GET: Home

        //GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection model)//(Register model)
        {

            string name = model["Name"];
            string password = model["Password"];
            string email = model["Mail"];
            string confirmpass = model["Confirmpassword"];
            if (!dbLogin.checkMailExist(email))
            {
                if (password.Equals(confirmpass))
                {
                    string iduser = (dbUser.getCount() + 1).ToString();
                    string idlogin = (dbLogin.getCount() + 1).ToString();

                    //Add a account in table Login                   
                    Login acc = new Login();
                    acc.Id = idlogin;
                    acc.Email = email;
                    acc.Password = password;
                    acc.Role = 1;
                    dbLogin.Add(acc);

                    //Add a User in table NguoiDung
                    NguoiDung nguoi = new NguoiDung();
                    nguoi.Id = iduser;
                    nguoi.Name = name;
                    nguoi.GioiTinh = "";
                    nguoi.MucTieu = "";
                    nguoi.CanNang = 0;
                    nguoi.CanNangMongMuon = 0;
                    nguoi.ChieuCao = 0;
                    nguoi.TanSuatHoatDong = "";
                    nguoi.Thang = 0;
                    nguoi.IdLogin = idlogin;
                    dbUser.Add(nguoi);

                    //   TempData["Message"] = "Register successfully!";
                    return Content("/Login/Login");
                }
                else
                {
                    int temp = 1;
                    return Content(temp.ToString());
                }
            }
            int temp2 = 0;
            return Content(temp2.ToString());
        }
    }
}

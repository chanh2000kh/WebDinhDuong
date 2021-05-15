using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Enum;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class UserInformationController : Controller
    {
        SqlUserInfo dbUser = new SqlUserInfo();
        SqlLogin dbLogin = new SqlLogin();

         public ActionResult Index()
        {
            var model = dbUser.GetUser(Session["ID"].ToString());
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]  
        public ActionResult Edit()
        {
            var modeluser = dbUser.GetUser(Session["ID"].ToString());
            var modellogin=dbLogin.GetAccFormId(Session["ID"].ToString());
            UserView user = new UserView();
            user.id = modeluser.Id;
            user.name = modeluser.Name;
            user.email = modellogin.Email;
            user.password = modellogin.Password;
            user.height = (int)modeluser.ChieuCao;
            user.weight = (int)modeluser.CanNang;
            user.gender = modeluser.GioiTinh;
            user.goal = modeluser.MucTieu;
            user.gweight = (int)modeluser.CanNangMongMuon;
            user.time = (int)modeluser.Thang;
            user.frequanecy = modeluser.TanSuatHoatDong;
            user.idlogin = "1";


            return View(user);
        }

        [HttpPost]  //use to post, write restaurant       
        public ActionResult Edit(FormCollection model)
        {
            //List<String> tansuat = new List<string>();
            //tansuat.Add("High");
            //tansuat.Add("Medium");
            //tansuat.Add("Slow");

            //List<String> muctieu = new List<string>();
            //tansuat.Add("Losing_weight");
            //tansuat.Add("Gaining_weight");
            //tansuat.Add("Put_on_weight");

            //List<String> gioitinh = new List<string>();
            //tansuat.Add("Femaie");
            //tansuat.Add("Male");
            //tansuat.Add("Other");

            //ViewBag.TanSuatHoatDong = new SelectList(tansuat,nguoiDung.TanSuatHoatDong);
            //ViewBag.MucTieu = new SelectList(muctieu,nguoiDung.MucTieu);
            //ViewBag.GioiTinh = new SelectList(gioitinh, nguoiDung.GioiTinh);

            string name = model["Name"];
            string gioitinh = model["Gender"];
            string tansuat = model["Frequency"];
            string height = model["Height"];
            string weight = model["Weight"];
            string goal = model["Goal"];
            string goalweight = model["Goalweight"];
            string time = model["Time"];

            NguoiDung user = new NguoiDung();
            user.Id = Session["ID"].ToString();
            user.Name = name;
            user.MucTieu = goal;
            user.TanSuatHoatDong = tansuat;
            user.CanNang = int.Parse(weight.ToString());
            user.ChieuCao = int.Parse(height.ToString());
            user.CanNangMongMuon= int.Parse(goalweight.ToString());
            user.Thang = int.Parse(time.ToString());
            user.GioiTinh = gioitinh;
            user.IdLogin = "1";

            dbUser.Update(user);
         
           return RedirectToAction("Details");
         }
                   
        public ActionResult Details()
        {
            var model = dbUser.GetUser(Session["ID"].ToString());
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class QuanLyKeHoachController : Controller
    {
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        private SqlThucDon dbthucdon = new SqlThucDon();
        private SqlKeHoach dbkehoach = new SqlKeHoach();
        // GET: QuanLyKeHoach
        public ActionResult ThemMoi(string id, FormCollection model)
        {
            //kiểm tra tham số truyền vào có rổng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //nếu không truy xuất csdl lấy ra sản phẩm tướng ứng
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.Id == id);
            if (monAn == null)
            {
                //Thôn báo nếu không có sản phẩm đó
                return HttpNotFound();
            }
            //ViewBag.Thu = new SelectList(db.Thus.OrderBy(n => n.Name), "Id", "Name");
            //ViewBag.Buoi = new SelectList(db.Buois.OrderBy(n => n.Name), "Id", "Name");
            if (model["Name"] == null)
            {
                Session["IDMon"] = id;
            }
            else
            {
                string name = model["Name"];
                string ghichu = model["GhiChu"];
                string soluong = model["SoLuong"];
                string date = model["datepicker"];
                string buoi = model["select"];
                string thu = model["select2"];
                string idthucdon = (dbthucdon.getCount() + 1).ToString();
                //add thực đơn
                //Add a thuc don in table Login                   
                ThucDon thucdon = new ThucDon();
                thucdon.Id = idthucdon;
                thucdon.IdMonAn = (string)Session["IDMon"];
                thucdon.IdNguoiDung = (string)Session["ID"];
                thucdon.Name = name;
                thucdon.SoLuong = int.Parse(soluong.ToString());               
                thucdon.GhiChu = ghichu;
                dbthucdon.Add(thucdon);
                //Add a ke hoach in table Login
                KeHoach kehoach = new KeHoach();
                kehoach.IdThucDon = idthucdon;
                kehoach.IdThu = thu;
                kehoach.IdBuoi = buoi;
                kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
                kehoach.GhiChu = ghichu;
                dbkehoach.Add(kehoach);               
                
            }
            //Session["IDMon"] = id;
            return View();
        }
        //[HttpGet]
        //public ActionResult ThemMoi(FormCollection model)
        //{
        //    string name = model["Name"];
        //    string ghichu = model["GhiChu"];
        //    string soluong = model["SoLuong"];
        //    string idthucdon = (dbthucdon.getCount() + 1).ToString();
        //    //add thực đơn
        //    //Add a account in table Login                   
        //    ThucDon thucdon = new ThucDon();
        //    thucdon.Id = idthucdon;
        //    thucdon.IdMonAn = (string)Session["IDMon"];
        //    thucdon.IdNguoiDung = (string)Session["ID"];
        //    thucdon.Name = (string)Session["Name"];
        //    thucdon.SoLuong = 2;
        //    //thucdon.SoLuong = int.Parse(soluong.ToString());
        //    thucdon.GhiChu = ghichu;
        //    dbthucdon.Add(thucdon);
        //    return View();
        //}

        public ActionResult LoadKeHoach(FormCollection model)
        {
           
            
            
            return View();
            
        }

        public ActionResult Buoi()
        {
            //Truy vấn lấy list Món
            var lstMon = db.Buois;
            return PartialView(lstMon);
        }

        public ActionResult Thu()
        {
            //Truy vấn lấy list Món
            var lstMon = db.Thus;
            return PartialView(lstMon);
        }
    }
}
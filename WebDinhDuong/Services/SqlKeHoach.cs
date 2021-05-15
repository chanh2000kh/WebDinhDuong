using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlKeHoach
    {
        private QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public SqlKeHoach(QuanLyDinhDuongEntities db)
        {
            this.db = db;
        }
        public SqlKeHoach() { }
        public void Add(KeHoach Kehoach)
        {
            db.KeHoaches.Add(Kehoach);
            db.SaveChanges();

        }
        public int getCount()
        {
            int size = db.KeHoaches.Count();
            return size;
        }
        public void Delete(String id)
        {
            var kehoach = db.KeHoaches.Find(id);
            db.KeHoaches.Remove(kehoach);
            db.SaveChanges();
        }
        public KeHoach GetAccFormId(string id)
        {
            return db.KeHoaches.Where(s => s.ThucDon.Equals(id)).FirstOrDefault();
        }
        

        public void Update(KeHoach kehoach)
        {
            var entry = db.Entry(kehoach);   //provides information, ability to perform actions on the entity
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }
        
    }
}
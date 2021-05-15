using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlThucDon
    {
        private QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public SqlThucDon(QuanLyDinhDuongEntities db)
        {
            this.db = db;
        }
        public SqlThucDon() { }
        public void Add(ThucDon thucdon)
        {
            db.ThucDons.Add(thucdon);
            db.SaveChanges();

        }
        public int getCount()
        {
            int size = db.ThucDons.Count();
            return size;
        }
        public void Delete(String id)
        {
            var thucdon = db.ThucDons.Find(id);
            db.ThucDons.Remove(thucdon);
            db.SaveChanges();
        }
        public ThucDon GetAccFormId(string id)
        {
            return db.ThucDons.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }
        

        public void Update(ThucDon thucdon)
        {
            var entry = db.Entry(thucdon);   //provides information, ability to perform actions on the entity
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }
        
    }
}
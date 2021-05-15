using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlLogin
    {
        private QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public SqlLogin(QuanLyDinhDuongEntities db)
        {
            this.db = db;
        }
        public SqlLogin() { }
        public void Add(Login login)
        {
            db.Logins.Add(login);
            db.SaveChanges();

        }
        public int getCount()
        {
            int size = db.Logins.Count();
            return size;
        }
        public void Delete(String id)
        {
            var login = db.Logins.Find(id);
            db.Logins.Remove(login);
            db.SaveChanges();
        }
        public Login GetAccFormId(string id)
        {
            return db.Logins.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }
        public Login GetAcc(string pass, string mail)
        {
            return db.Logins.Where(s => s.Email.Equals(mail) && s.Password.Equals(pass)).FirstOrDefault();
        }

        public void Update(Login login)
        {
            var entry = db.Entry(login);   //provides information, ability to perform actions on the entity
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }
        public bool checkMailExist(string mail)
        {
            var login= db.Logins.Where(s => s.Email.Equals(mail)).FirstOrDefault();
            if (login != null) return true;
            return false;
        }
    }
}
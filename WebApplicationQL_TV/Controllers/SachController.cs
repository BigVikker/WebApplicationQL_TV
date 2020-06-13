using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebApplicationQL_TV.Model_new;
using PagedList.Mvc;

namespace WebApplicationQL_TV.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        public ActionResult ThongTinSach(string sortBy,string search,int? page)
        {
            if (sortBy != null) ViewBag.Current_sortBy = sortBy;
            else sortBy = ViewBag.Current_sortBy;
            if (search != null) ViewBag.Current_search = search;
            else search = ViewBag.Current_search;
            
            Model2 db = new Model2();
            var query = "Select * from Sach";
            var list = db.Saches.SqlQuery(query).ToList();
            if(search != null )
            {
                query = query + " where maSach = '"+search+"'";
                list = db.Saches.SqlQuery(query).ToList();
            }
            if(sortBy == "maSach")
            {
                query = query + " order by maSach";
                list = db.Saches.SqlQuery(query).ToList();
            }
            if (sortBy == "tenSach")
            {
                query = query + " order by tenSach";
                list = db.Saches.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1,5));
        }
        
        public ActionResult Create()
        {
            return View();
        }
       
        public ActionResult ThongTinSachDangMuon(int? page)
        {
            Model2 db = new Model2();
            string query = "select * from Sach where "
                +"maSach not in (select maSach from YeuCauMuon) or maSach in"
                +" (select maSach from YeuCauMuon where maPhieuYeuCau in "
                +" (select maPhieuYeuCau where maPhieuYeuCau in " 
                +"(select maPhieuYeuCau from HoaDonMuon where TrangThai=1)))";
            var list = db.Saches.SqlQuery(query).ToList();
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult Details(string id)
        {
            if (id == null) return RedirectToAction("ThongTinSach");
            Model2 db = new Model2();
            Sach sach_have_been_found = db.Saches.Find(id);
            return View(sach_have_been_found);
        }
        
        public ActionResult Edit(string id)
        {
            if (id == null) return RedirectToAction("ThongTinSach"); 
            Model2 db = new Model2();
            Sach sach = db.Saches.Find(id);
            return View(sach);
        }
        public ActionResult Delete(string id)
        {
            if (id == null) return RedirectToAction("ThongTinSach");
            Model2 db = new Model2();
            Sach sach = db.Saches.Find(id);
            return View(sach);
        }
        public ActionResult BangSach()
        {
            Model2 db = new Model2();
            var list = db.Saches.SqlQuery("exec BangSach").ToList();
            return View(list);
        }
        [HttpPost, ActionName("Create")]
        public ActionResult CreateConFirm(Sach sach)
        {
            Model2 db = new Model2();
            var sach_finder = db.Saches.Find(sach.maSach);
            if (sach_finder != null)
            {
                db.Saches.Add(sach_finder);
                db.SaveChanges();
                return RedirectToAction("ThongTinSach");
            }
            else
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("ThongTinSach");
            }
            
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Model2 db = new Model2();
            Sach delete_sach = db.Saches.SqlQuery("select * from Sach where ( maSach in " +
                "(select maSach from YeuCauMuon where maPhieuYeuCau in " +
                "(select maPhieuYeuCau from PhieuYeuCau where maPhieuYeuCau in " +
                "(select maPhieuYeuCau from HoaDonMuon where trangThai = 1))) " +
                " and maSach = '"+id+ "') " +
                "OR (maSach not in (select maSach from YeuCauMuon) " +
                "and maSach = '"+id+ "')").SingleOrDefault();
            if (delete_sach == null) return RedirectToAction("ThongTinSach");
            else
            {
                db.Database.ExecuteSqlCommand("delete from Sach where maSach = '"+id+"'");
                db.SaveChanges();
            }
            return RedirectToAction("ThongTinSach");
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Sach sach)
        {
            Model2 db = new Model2();
            Sach editor_Sach = db.Saches.Find(sach.maSach);
            editor_Sach.ghiChu = sach.ghiChu;
            editor_Sach.maLoaiSach = sach.maLoaiSach;
            if (TryUpdateModel(editor_Sach))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("ThongTinSach");
                }
                catch
                {
                    return RedirectToAction("ThongTinSach");
                }
            }
            return RedirectToAction("ThongTinSach");
        }
    }
}

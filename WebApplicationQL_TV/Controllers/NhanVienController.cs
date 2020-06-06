using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using WebApplicationQL_TV.Models;

namespace WebApplicationQL_TV.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult ThongTinNhanVien(int? page, string search,string sortBy)
        {
            Model1 db = new Model1();
            List<NhanVien> list = db.NhanViens.SqlQuery("Select * from NhanVien").ToList();
            if (search != null)
            {
                ViewBag.Current_search = search;
                list = list.Where(x => x.maNV.StartsWith(search)).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                list = list.OrderBy(x => x.maNV).ToList();
            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                list = list.OrderBy(x => x.tenNV).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinNhanVienChuaVietDonHang(int? page, string search, string sortBy)
        {
            Model1 db = new Model1();
            List<NhanVien> list = db.NhanViens.SqlQuery("Select * from NhanVien where maNV not in " +
                "(select maNV  from PhieuYeuCau)").ToList();
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                list = list.OrderBy(x => x.maNV).ToList();
            }
            if (search != null)
            {
                ViewBag.Current_search = search;
                list = list.Where(x => x.maNV.StartsWith(search)).ToList();
            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                list = list.OrderBy(x => x.tenNV).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult Create ()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model1 db = new Model1();
            NhanVien obj_have_been_found = db.NhanViens.Find(id);
            return View(obj_have_been_found);
        }

        public ActionResult Edit(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model1 db = new Model1();
            NhanVien obj = db.NhanViens.Find(id);
            return View(obj);
        }
        public ActionResult Delete(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model1 db = new Model1();
            NhanVien obj = db.NhanViens.Find(id);
            return View(obj);
        }
        [HttpPost, ActionName("Create")]

        public ActionResult Create(NhanVien nhanVien)
        {
            Model1 db = new Model1();
            var sach_finder = db.NhanViens.Find(nhanVien.maNV);
            if (sach_finder != null)
            {
                return RedirectToAction("ThongTinNhanVien");
            }
            else
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("ThongTinNhanVien");
            }

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Model1 db = new Model1();
            var NhanVien = db.NhanViens.SqlQuery("Select * from NhanVien where " +
                "maNV not in (select maNV from PhieuYeuCau) and" +
                " maNV = '"+id+"'").SingleOrDefault();
            if (NhanVien == null)
                return RedirectToAction("ThongTinNhanVien");
            else
            {
                db.Database.ExecuteSqlCommand("delete from NhanVien where maNV = '"+ id +"'");
                db.SaveChanges();
            }
            return RedirectToAction("ThongTinNhanVien");
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(string id)
        {
            Model1 db = new Model1();
            NhanVien editor = db.NhanViens.Find(id);
            if (TryUpdateModel(editor))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("ThongTinNhanVien");
                }
                catch
                {
                    return RedirectToAction("ThongTinNhanVien");
                }
            }
            return RedirectToAction("ThongTinNhanVien");
        }
    }
}
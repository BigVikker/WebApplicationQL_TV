using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using WebApplicationQL_TV.Model_new;

namespace WebApplicationQL_TV.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult ThongTinNhanVien(int? page, string search, string sortBy)
        {
            Model2 db = new Model2();
            var query = "select * from nhanVien ";
            List<NhanVien> list = db.NhanViens.SqlQuery(query).ToList();
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " where maNV like N'%"+search+"%'";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by maNV";
                list = db.NhanViens.SqlQuery(query).ToList();

            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by tenNV";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinNhanVienThuocBoPhan001(int? page, string search, string sortBy)
        {
            Model2 db = new Model2();
            var query = "Select * from NhanVien where maBP = 'BP001' ";

            List<NhanVien> list = db.NhanViens.SqlQuery(query).ToList();

            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maNV like N'%" + search + "%'";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by maNV";
                list = db.NhanViens.SqlQuery(query).ToList();

            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by tenNV";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinNhanVienThuocBoPhan002(int? page, string search, string sortBy)
        {
            Model2 db = new Model2();
            var query = "Select * from NhanVien where maBP = 'BP002' ";

            List<NhanVien> list = db.NhanViens.SqlQuery(query).ToList();

            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maNV like N'%" + search + "%'";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by maNV";
                list = db.NhanViens.SqlQuery(query).ToList();

            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by tenNV";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinNhanVienThuocBoPhan003(int? page, string search, string sortBy)
        {
            Model2 db = new Model2();
            var query = "Select * from NhanVien where maBP = 'BP003' ";

            List<NhanVien> list = db.NhanViens.SqlQuery(query).ToList();

            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maNV like N'%" + search + "%'";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by maNV";
                list = db.NhanViens.SqlQuery(query).ToList();

            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by tenNV";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinNhanVienChuaVietDonHang(int? page, string search, string sortBy)
        {
            Model2 db = new Model2();
            List<NhanVien> list = db.NhanViens.SqlQuery("Select * from NhanVien where maNV not in " +
                "(select maNV  from PhieuYeuCau)").ToList();

            var query = "Select * from NhanVien where maNV not in " +
                "(select maNV  from PhieuYeuCau)";
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maNV like N'%" + search + "%'";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            if (sortBy == "maNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by maNV";
                list = db.NhanViens.SqlQuery(query).ToList();

            }
            if (sortBy == "tenNV")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by tenNV";
                list = db.NhanViens.SqlQuery(query).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult BangNhanVien()
        {
            Model2 db = new Model2();
            var list = db.NhanViens.SqlQuery("exec bangNhanVien").ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost , ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConFirm(NhanVien nhanVien)
        {
            Model2 db = new Model2();
            var NhanVien_Found = db.NhanViens.SqlQuery("select * from " +
                " NhanVien Where maNV = '"+nhanVien.maNV+"'").SingleOrDefault();
            if (NhanVien_Found != null) return RedirectToAction("Create");
            else
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
            }
            
            return RedirectToAction("ThongTinNhanVien");
        }
        public ActionResult Details(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model2 db = new Model2();
            NhanVien obj_have_been_found = db.NhanViens.Find(id);
            return View(obj_have_been_found);
        }

        public ActionResult Edit(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model2 db = new Model2();
            NhanVien obj = db.NhanViens.Find(id);
            return View(obj);
        }
        public ActionResult Delete(string id)
        {
            if (id == null) return RedirectToAction("ThongTinNhanVien");
            Model2 db = new Model2();
            NhanVien obj = db.NhanViens.Find(id);
            return View(obj);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Model2 db = new Model2();
            var NhanVien_found = db.NhanViens.SqlQuery("Select * from NhanVien where " +
                "maNV not in (select maNV from PhieuYeuCau) and" +
                " maNV = '"+id+"'").SingleOrDefault();
            if (NhanVien_found == null)
                return View();
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
            Model2 db = new Model2();
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
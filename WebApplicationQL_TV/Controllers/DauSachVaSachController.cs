using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebApplicationQL_TV.Model_new;

namespace WebApplicationQL_TV.Controllers
{
    public class DauSachVaSachController : Controller
    {
        Model2 db = new Model2();
        // GET: DauSachVaSach
        public ActionResult TatCaDauSachVaSach(int? page, string sortBy, string search)
        {
            Model2 db = new Model2();

            var query = "SELECT DS.maDauSach,tenDauSach,maTacGia,maNgonNgu" +
                ",maNhaXuatBan,S.maSach,S.tenSach,S.soTrang,S.namXuatBan,S.giaSach" +
                ",S.ghiChu,S.maLoaiSach,S.maKhoSach from Sach S inner join DauSach DS ON " +
                " DS.maDauSach = S.maDauSach ";
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " where DS.maDauSach like '%" + search + "%'";
            }
            if (sortBy == "maDauSach")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by DS.maDauSach";
            }
            if (sortBy == "tenDauSach")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by DS.tenDauSach";
            }
            var list = db.BangDauSachVaSaches.SqlQuery(query).ToList();
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult BangDauSach(int ? page,string sortBy ,string search)
        {
            var query = "select * from DauSach";
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " where DS.maDauSach like '%" + search + "%'";
            }
            if (sortBy == "maDauSach")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by DS.maDauSach";
            }
            if (sortBy == "tenDauSach")
            {
                ViewBag.Current_sortBy = sortBy;
                query = query + " order by DS.tenDauSach";
            }
            var list = db.DauSaches.SqlQuery(query).ToList();
            return View(list.ToPagedList(page ?? 1,5));
        }
        public ActionResult Details(string id)
        {
            var query = "Select * from DauSach where maDauSach = '" + id + "'";
            var obj_found = db.DauSaches.SqlQuery(query).SingleOrDefault();
            return View(obj_found);
        }
        public ActionResult Edit(string id)
        {
            var query = "Select * from DauSach where maDauSach = '" + id + "'";
            var obj_found = db.DauSaches.SqlQuery(query).SingleOrDefault();
            return View(obj_found);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(DauSach obj)
        {
            var statment1 = db.TacGias.SqlQuery("select * from TacGia where maTacGia = '" + obj.maTacGia + "'").SingleOrDefault();
            var statment2 = db.NhaXuatBans.SqlQuery("select * from NhaXuatBan where maNhaXuatBan = '" + obj.maNhaXuatBan + "'").SingleOrDefault();
            var statment3 = db.NgonNgus.SqlQuery("select maNgonNgu,NgonNgu,ghiChu from NgonNgu WHERE maNgonNgu = '" + obj.maNgonNgu + "'").SingleOrDefault();
            if (statment1 != null && statment2 != null && statment3 != null)
            {
                var query = "update DauSach set maTacGia = '" + obj.maTacGia + "' ," +
                    "maNgonNgu = '" + obj.maNgonNgu + "',maNhaXuatBan = '" + obj.maNhaXuatBan + "' " +
                    " ,tenDauSach = '" + obj.tenDauSach + "' where maDauSach = '" + obj.maDauSach + "'";
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return RedirectToAction("TatCaDauSachVaSach");
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public ActionResult Create(DauSach obj)
        {

            var statment1 = db.TacGias.SqlQuery("select * from TacGia where maTacGia = '" + obj.maTacGia + "'").SingleOrDefault();
            var statment2 = db.NhaXuatBans.SqlQuery("select * from NhaXuatBan where maNhaXuatBan = '" + obj.maNhaXuatBan + "'").SingleOrDefault();
            var statment4 = db.DauSaches.SqlQuery("select * from DauSach where maDauSach = '" + obj.maDauSach + "'").SingleOrDefault();
            var statment3 = db.NgonNgus.SqlQuery("select * from NgonNgu WHERE maNgonNgu = '" + obj.maNgonNgu + "'").SingleOrDefault();
            
            if (statment1 != null && statment2 != null && statment3 != null)
            {
                if (statment4 == null)
                {
                    var query = "insert into DauSach(maDauSach,tenDauSach,maTacGia,maNgonNgu,maNhaXuatBan) values('" + obj.maDauSach + "','" + obj.tenDauSach + "','" + obj.maTacGia + "','" + obj.maNgonNgu + "','" + obj.maNhaXuatBan + "')";
                    db.Database.ExecuteSqlCommand(query);
                    db.SaveChanges();
                    return RedirectToAction("TatCaDauSachVaSach");
                }
            }
            return View();

        }
        public ActionResult Delete(string id)
        {
            var query = "Select * from DauSach where maDauSach = '" + id + "'";
            var obj_found = db.DauSaches.SqlQuery(query).SingleOrDefault();
            return View(obj_found);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirm(string id)
        {
            var query = "SELECT DS.maDauSach,tenDauSach,maTacGia,maNgonNgu" +
                ",maNhaXuatBan,S.maSach,S.tenSach,S.soTrang,S.namXuatBan,S.giaSach" +
                ",S.ghiChu,S.maLoaiSach,S.maKhoSach from Sach S inner join DauSach DS ON " +
                " DS.maDauSach = S.maDauSach where DS.maDauSach = '"+id+"'";
            var obj_found = db.BangDauSachVaSaches.SqlQuery(query).SingleOrDefault();
            if(obj_found == null) {
                db.Database.ExecuteSqlCommand("delete DauSach where maDauSach = '"+id+"'");
                db.SaveChanges();
                return RedirectToAction("TatCaDauSachVaSach");
            }
            return View();
        }
    }
}